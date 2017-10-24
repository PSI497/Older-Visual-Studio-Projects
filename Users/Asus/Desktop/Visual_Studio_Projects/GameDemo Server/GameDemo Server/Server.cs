using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Packets;
namespace GameDemo_Server
{
    public class Server
    {
        private Listener _listener;
        private List<Client> _clients;
        private List<Chatroom> _chatrooms;
        private List<GameLobby> _gameLobbies;
        private MainForm mf;
        public enum ClientStatus { Unverified, Online, InLobby, InGame };

        private Client ClientWithID(string ID)
        {
            foreach (Client client in _clients)
            {
                if (client.ID == ID)
                {
                    return client;
                }
            }
            return null;
        }
        private byte[] Serialize(object anySerializableObject)
        {
            using (var memoryStream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(memoryStream, anySerializableObject);
                return memoryStream.ToArray();
            }
        }
        private object Deserialize(byte[] data)
        {
            using (var memoryStream = new MemoryStream(data))
                return (new BinaryFormatter()).Deserialize(memoryStream);
        }

        public Server(MainForm formi)
        {
            mf = formi;
            _clients = new List<Client>();
            _chatrooms = new List<Chatroom>();
            _gameLobbies = new List<GameLobby>();
            _listener = new Listener(8000);
            _listener.SocketAccepted += new Listener.SocketAcceptedHandler(Listener_SocketAccepted);
            _chatrooms.Add(new Chatroom(new List<Client>()));

        }
       
        private void Listener_SocketAccepted(System.Net.Sockets.Socket e)
        {
            mf.Invoke((MethodInvoker)delegate
            {
                DataReceiver dataReceiver = new DataReceiver(e);
                dataReceiver.Received += new DataReceiver.ClientReceiveHandler(DataReceived);
                dataReceiver.Disconnected += new DataReceiver.ClientDisconnectedHandler(Disconnected);

                Client client = new Client(e, dataReceiver.ID);
                client.ClientStatus = ClientStatus.Unverified;
                _clients.Add(client);

                Console.WriteLine(String.Format("Client({0}) connected, current amount of clients:{1}", client.ID,_clients.Count));
            });
        }
        private void Disconnected(DataReceiver sender)
        {
            mf.Invoke((MethodInvoker)delegate
            {
                sender.Close();
                _clients.Remove(ClientWithID(sender.ID));               
                Console.WriteLine(String.Format("Client({0}) disconnected, current amount of clients:{1}", sender.ID, _clients.Count));
            });
        }
        private void DataReceived(DataReceiver sender, byte[] data)
        {
            mf.Invoke((MethodInvoker)delegate
            {
                object dataObject = Deserialize(data);
                Client senderClient = ClientWithID(sender.ID);
                if (dataObject is LoginPacket)
                {
                    VerifyLogin(senderClient, dataObject as LoginPacket);
                }
                if (dataObject is CreateChatRoomRequestPacket)
                {
                    CreateChatRoom(dataObject as CreateChatRoomRequestPacket);
                }
                if (dataObject is ChatMessagePacket)
                {
                    ChatMessageReceived(dataObject as ChatMessagePacket);
                }
                if (dataObject is GameLobbyUpdatePacket)
                {
                    GameLobbyUpdate(dataObject as GameLobbyUpdatePacket);
                }
            });
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine("Server started, listening for connections...");
        }
        private void SendPacket(Client client, object packet)
        {
            byte[] data = Serialize(packet);
            client.Socket.Send(BitConverter.GetBytes(data.Length));
            client.Socket.Send(data);
        }
        public void SendTextToClient(string ID, string text)
        {
            Client client = ClientWithID(ID);
            if (client == null) { Console.WriteLine("Client with the was ID not found"); return; }

            ClientWithID(ID).Socket.Send(Encoding.Default.GetBytes(text));
        }

        private void VerifyLogin(Client client, LoginPacket loginPacket)
        {

            bool foundMatch = false;
            foreach (Client c in _clients)
            {
                if (c.Username == loginPacket.Username)
                {
                    foundMatch = true;
                }
            }
            LoginVerificationPacket loginVP = new LoginVerificationPacket();
            if (foundMatch)
            {
                loginVP.Granted = false;
                SendPacket(client, loginVP);
            }
            else
            {
                loginVP.Granted = true;
                client.Username = loginPacket.Username;             
                client.ClientStatus = ClientStatus.Online;
                
                SendPacket(client, loginVP);
               
                ClientLoggedIn(client);
                Console.WriteLine(String.Format("Client({0}) logged in with name: {1}", client.ID, loginPacket.Username));
            }
           
        }
        private void ClientLoggedIn(Client client)
        {
            System.Threading.Thread.Sleep(1);       
            JoinChatroom(client, _chatrooms[0]); // join the public chatroom
            ChatMessagePacket chatMessagePacket = new ChatMessagePacket();
            chatMessagePacket.ChatRoomID = _chatrooms[0].ID;
            chatMessagePacket.Message = "You have joined to this chatroom...";           
        }
        private void CreateChatRoom(CreateChatRoomRequestPacket ccrrp)
        {
            List<Client> clients = new List<Client>();
            foreach (string username in ccrrp.Members)
            {
                foreach(Client client in _clients)
                {
                    if(client.Username == username)
                    {
                        clients.Add(client);
                    }
                }
            }
            Chatroom cr = new Chatroom(clients);
            _chatrooms.Add(cr);

        }
        private void JoinChatroom(Client client, Chatroom chatroom)
        {
            chatroom.Clients.Add(client);
        }
        private void ChatMessageReceived(ChatMessagePacket chatMessagePacket)
        {
            foreach (Chatroom chatroom in _chatrooms)
            {
                if (chatroom.ID == chatMessagePacket.ChatRoomID)
                {
                    foreach (Client client in chatroom.Clients)
                    {
                        SendPacket(client, chatMessagePacket);
                    }
                }
            }
        }

        private void GameLobbyUpdate(GameLobbyUpdatePacket gameLobbyUP)
        {
            foreach(Client client in _clients)
            {
                if (client.ClientStatus == ClientStatus.Online || client.ClientStatus == ClientStatus.InLobby) ;
                {
                    SendPacket(client, gameLobbyUP);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{

    [Serializable]
    public class LoginPacket
    {
        public string Username;
        public LoginPacket(string username)
        {
            Username = username;
        }
    }
    [Serializable]
    public class LoginVerificationPacket
    {
        public bool Granted;
    }
    [Serializable]
    public class PingPacket
    {
        public string Date;
    }
    [Serializable]
    public class ChatMessagePacket
    {
        public string Message;
        public string SenderUsername;
        public string ChatRoomID;
    }
    [Serializable]
    public class CreateChatRoomRequestPacket //client to server, requesting to create a new chatroom with the given members
    {
        public List<string> Members;
    }
    [Serializable]
    public class GameLobbyUpdatePacket
    {
        public Type Type;
        public List<string> Players = new List<string>();
        public int CurrentPlayers;
        public int MaxPlayers;
        public string Creator;
        public string RoomName;
        public string ID;
       
    }
    public enum Type { Update, Create, Delete };

}

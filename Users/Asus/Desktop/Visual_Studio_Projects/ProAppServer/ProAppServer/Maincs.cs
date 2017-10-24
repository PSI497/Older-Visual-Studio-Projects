using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace ProAppServer
{
    public partial class Maincs : Form
    {
        Listener listener;
        User[] user = new User[100];
        Socket[] sck = new Socket[100];
        int ConnectedUsers = 0;
        int UserQueue = -1;
        string color = "0";
        public Maincs()
        {

            InitializeComponent();
            listener = new Listener(8);
            listener.SocketAccepted += new Listener.SocketAcceptedHandler(listener_SocketAccepted);
            Load += new EventHandler(Maincs_Load);
            
        }

        private void SendText(string text, string colore)
        {
            
            MsgBox.SelectionStart = MsgBox.TextLength;
            MsgBox.SelectionLength = 0;
            Color color= new Color();
            if (colore == "0")
            {
                color = Color.Black;
            }
            else if (colore == "1")
            {
                color = Color.Red;
            }
            else if (colore == "2")
            {
                color = Color.Blue;
            }
            else if (colore == "9")
            {
                color = Color.Gray;
            }

            MsgBox.SelectionColor = color;
            MsgBox.AppendText(System.Environment.NewLine + text);
            
        }

        void listener_SocketAccepted(System.Net.Sockets.Socket e)
        {
            ConnectedUsers += 1;
            Client client = new Client(e);
            
            sck[ConnectedUsers] = e;
            client.Received += new Client.ClientReceiveHandler(client_Received);
            client.Disconnected += new Client.ClientDisconnectedHandler(client_Disconnected);
            
            Invoke((MethodInvoker)delegate
            {
               
       
                ListViewItem i = new ListViewItem();
                i.Text = "Somebody";

                UserQueue += 1;
                user[ConnectedUsers] = new User();
                user[ConnectedUsers].UID = client.ID;
                user[ConnectedUsers].Connected = true;
                user[ConnectedUsers].ListNum = ConnectedUsers - 1;
                i.Tag = client.ID;
                this.Text = client.ToString(); ;
                OnlineUsers.Items.Add(i);
                for (int i2 = 1; i2 < ConnectedUsers ; i2++)
                {
                    sck[ConnectedUsers].Send(Encoding.Default.GetBytes("0"+ "9" + user[i2].Username));
                    System.Threading.Thread.Sleep(10);
                }
            });
        }
        void client_Disconnected(Client sender)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 1; i < ConnectedUsers + 1; i++)
                {


                    if (user[i].UID == sender.ID)
                    {

                        SendText("Server:  " + user[i].Username + " Disconnected.....", "9");

                        for (int i3 = ConnectedUsers - 1; i3 > -1; i3--)
                        {
                            try
                            {
                                if (OnlineUsers.Items[i3].Tag.ToString() == sender.ID)
                                {
                                    OnlineUsers.Items.RemoveAt(i3);
                                    user[i].Connected = false;
                                    for (int i2 = 1; i2 < ConnectedUsers + 1; i2++) // sending the dc data to the clients
                                    {

                                        try
                                        {
                                            sck[i2].Send(Encoding.Default.GetBytes("2" + "9" + (i3)));
                                        }
                                        catch
                                        {
                                        }

                                    }

                                }
                            }

                            catch
                            {
                            }
                        }
                     
                        break;
                    }

                }
                
            });
        }
        void client_Received(Client sender, byte[] data)
        {
            Invoke((MethodInvoker)delegate
            {
              
                string msg = Encoding.Default.GetString(data);

                string type = Convert.ToString(msg[0]);
                string color = Convert.ToString(msg[1]);
                msg = msg.Remove(0, 2);
                if (type == "0")//somebody connected
                {
                    
                    for (int i = 1; i < ConnectedUsers + 1; i++)
                    {
                        
                       
                        if (user[i].UID == sender.ID)
                        {
                            
                            user[i].Username = msg;
                            OnlineUsers.Items[i - 1].Text = user[i].Username;
                            SendText("Server:  " + user[i].Username + " Connected.....", "9");
                            for (int i2 = 1; i2 < ConnectedUsers + 1; i2++)
                            {
                                try
                                {
                                    sck[i2].Send(Encoding.Default.GetBytes("0" + "9" + user[i].Username));
                                }
                                catch
                                {
                                }
                            }
                           
                            
                            break;
                            
                        }

                    }
                }
                else if (type == "1")//somebody sent a msg
                {
                    for (int i = 1; i < ConnectedUsers + 1; i++)
                    {
                     

                        if (user[i].UID == sender.ID)
                        {


                            SendText(user[i].Username + ":" + msg, color);
                            for (int i2 = 1; i2 < ConnectedUsers + 1; i2++)
                            {
                                try
                                {
                                    sck[i2].Send(Encoding.Default.GetBytes("1" +  color + user[i].Username + ":" + msg));
                                }
                                catch
                                {
                                }
                            }
                            break;
                        }

                    }
                    
                }
                else if (type == "3")
                {
                    for (int i = 1; i < ConnectedUsers + 1; i++)
                    {


                        if (user[i].UID == sender.ID)
                        {


                            SendText(user[i].Username + " played sound:" + msg, "9");
                            for (int i2 = 1; i2 < ConnectedUsers + 1; i2++)
                            {
                                try
                                {
                                    sck[i2].Send(Encoding.Default.GetBytes("3" + "9" + user[i].Username + " played sound:" + msg));
                                }
                                catch
                                {
                                }
                            }
                            break;
                        }

                    }
                }
            });

        }

        private void Maincs_Load(object sender, EventArgs e)
        {
            listener.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
           
           
        }

        

        
    }
}

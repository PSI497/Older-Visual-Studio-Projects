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

namespace ProAppClient
{

    public partial class Main : Form
    {
        
        Socket sck;
        string color = "0";//Client's color
        string colorr = "0";//other Client's color
        public Main()
        
        {

            InitializeComponent();
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }


        private void SendMsgToServer(string msg)
        {
            string type = "1";
            string firstletter = Convert.ToString(msg[0]);

            if (firstletter == "/")
            {
                type = "3";
                msg = msg.Remove(0, 1);
            }
            else
            {
                type = "1";
            }
            sck.Send(Encoding.Default.GetBytes(type + color + msg));
            txtMsgSend.Clear(); 



        }



        private void PlaySound(string sound)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            if (sound == "gaz")
            {
                player.SoundLocation = "gaz.wav";
            }
            else if (sound == "gems")
            {
                player.SoundLocation = "gems.wav";
            }
            else if (sound == "troll")
            {
                player.SoundLocation = "troll.wav";
            }
            else if (sound == "t Fizz")
            {
                Random rand = new Random();
                int whichone = rand.Next(1,3);
                if (whichone == 1)
                {
                    player.SoundLocation = "Fizz.taunt.wav";
                }
                else if (whichone == 2)
                {
                    player.SoundLocation = "Fizz.taunt2.wav";
                }
            }


            else if (sound == "dc")
            {
                player.SoundLocation = "female1_OnQuit_1.wav";
            }


            else if (sound == "conn")
            {
                Random rand = new Random();
                int whichone = rand.Next(1, 3);
                if (whichone == 1)
                {
                    player.SoundLocation = "female1_OnReconnect_1.wav";
                }
                else if (whichone == 2)
                {
                    player.SoundLocation = "female1_OnReconnect_2.wav";
                }

            }

            else if (sound == "l Zed")
            {
                Random rand = new Random();
                int whichone = rand.Next(1, 5);
                if (whichone == 1)
                {
                    player.SoundLocation = "Zed.laugh1.wav";
                }
                else if (whichone == 2)
                {
                    player.SoundLocation = "Zed.laugh2.wav";
                }
                else if (whichone == 3)
                {
                    player.SoundLocation = "Zed.laugh3.wav";
                }
                else if (whichone == 4)
                {
                    player.SoundLocation = "Zed.laugh4.wav";
                }
            }
            else if (sound == "j KogMaw")
            {
                player.SoundLocation = "KogMaw.joke.wav";   
            }
            else if (sound == "l Hecarim")
            {
                Random rand = new Random();
                int whichone = rand.Next(1, 5);
                if (whichone == 1)
                {
                    player.SoundLocation = "Hecarim.laugh1.wav";
                }
                else if (whichone == 2)
                {
                    player.SoundLocation = "Hecarim.laugh2.wav";
                }
                else if (whichone == 3)
                {
                    player.SoundLocation = "Hecarim.laugh3.wav";
                }
                else if (whichone == 4)
                {
                    player.SoundLocation = "Hecarim.laugh4.wav";
                }
            }
            else if (sound == "l Cho")
            {
                Random rand = new Random();
                int whichone = rand.Next(1, 4);
                if (whichone == 1)
                {
                    player.SoundLocation = "Greenterror.laugh1.wav";
                }
                else if (whichone == 2)
                {
                    player.SoundLocation = "Greenterror.laugh2.wav";
                }
                else if (whichone == 3)
                {
                    player.SoundLocation = "Greenterror.laugh3.wav";
                }
                
            }
            else if (sound == "j Cho")
            {
                Random rand = new Random();
                int whichone = rand.Next(1, 3);
                if (whichone == 1)
                {
                    player.SoundLocation = "Greenterror.joke2.wav";
                }
                else if (whichone == 2)
                {
                    player.SoundLocation = "Greenterror.joke3.wav";
                }
            }
            else if (sound == "d Ashe")
            {
                Random rand = new Random();
                int whichone = rand.Next(1, 4);
                if (whichone == 1)
                {
                    player.SoundLocation = "Bowmaster.dying1.wav";
                }
                else if (whichone == 2)
                {
                    player.SoundLocation = "Bowmaster.dying2.wav";
                }
                else if (whichone == 3)
                {
                    player.SoundLocation = "Bowmaster.dying3.wav";
                }

            }
            else if (sound == "penta")
            {
                Random rand = new Random();
                int whichone = rand.Next(1, 3);
                if (whichone == 1)
                {
                    player.SoundLocation = "female1_OnChampionPentaKillYo (2).wav";
                }
                else if (whichone == 2)
                {
                    player.SoundLocation = "female1_OnChampionPentaKillYo.wav";
                }
               

            }
            else if (sound == "legendary")
            {
                Random rand = new Random();
                int whichone = rand.Next(1, 4);
                if (whichone == 1)
                {
                    player.SoundLocation = "female1_OnKillingSpreeSet6You (3).wav";
                }
                else if (whichone == 2)
                {
                    player.SoundLocation = "female1_OnKillingSpreeSet6You (4).wav";
                }
                else if (whichone == 3)
                {
                    player.SoundLocation = "female1_OnKillingSpreeSet6You (5).wav";
                }

            }
            else if (sound == "l Gay")
            {
                Random rand = new Random();
                int whichone = rand.Next(1, 5);
                if (whichone == 1)
                {
                    player.SoundLocation = "GemKnight.laugh1.wav";
                }
                else if (whichone == 2)
                {
                    player.SoundLocation = "GemKnight.laugh2.wav";
                }
                else if (whichone == 3)
                {
                    player.SoundLocation = "GemKnight.laugh3.wav";
                }
                else if (whichone == 4)
                {
                    player.SoundLocation = "GemKnight.laugh4.wav";
                }
            }

            player.Play();

        }
        private void SendText(string text, string colore)
        {

            MsgBox.SelectionStart = MsgBox.TextLength;
            MsgBox.SelectionLength = 0;
            Color colord= new Color();
            if (colore == "0")
            {
                colord = Color.Black;
            }
            else if (colore == "1")
            {
                colord = Color.Red;
            }
            else if (colore == "2")
            {
                colord = Color.Blue;
            }
            else if (colore == "9")
            {
                colord = Color.Gray;
            }

            MsgBox.SelectionColor = colord;
            MsgBox.AppendText(System.Environment.NewLine + text);

        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            sck.Connect("127.0.0.1", 8);
            this.Text = "Connected";
              sck.Send(Encoding.Default.GetBytes(0+"0"+UserName.Text));
              Client client = new Client(sck);
              client.Received += new Client.ClientReceiveHandler(client_Received);
              client.Disconnected += new Client.ClientDisconnectedHandler(client_Disconnected);
              SendText("Connected to the Server...", "9");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            SendMsgToServer(txtMsgSend.Text);
            
           
        }



        void client_Disconnected(Client sender)
        {
            Invoke((MethodInvoker)delegate
            {
               

            });
        }

        void client_Received(Client sender, byte[] data)
        {
            Invoke((MethodInvoker)delegate
            {

                string msg = Encoding.Default.GetString(data);

                string type = Convert.ToString(msg[0]);
                colorr = Convert.ToString(msg[1]);
                msg = msg.Remove(0, 2);

                if (type == "0") //somebody connected
                {

                    OnlineUsers.Items.Add(msg);
                    SendText("Server:  " + msg + " Connected.....", colorr);
                    PlaySound("conn");
                }
                if (type == "2") //somebody dced
                {
                    PlaySound("dc");
                    OnlineUsers.Items.RemoveAt(Convert.ToInt32(msg));
                    SendText("Server:  " + OnlineUsers.Items[Convert.ToInt32(msg)].Text + " Disconnected.....", colorr);
                   
                }
                if (type == "1")//receiving message from the server
                {
                  
                    SendText(msg, colorr);
                }
                if (type == "3")//receiving message from the server
                {

                    SendText(msg, colorr);
                    string[] msg_splitted = msg.Split(':');
                    PlaySound(msg_splitted[1]);
                }
            });

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void txtMsgSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMsgToServer(txtMsgSend.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            color = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            color = "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            color = "2";
        }

        private void MsgBox_TextChanged(object sender, EventArgs e)
        {
            MsgBox.ScrollToCaret();
        }

      

       

       


    }
}

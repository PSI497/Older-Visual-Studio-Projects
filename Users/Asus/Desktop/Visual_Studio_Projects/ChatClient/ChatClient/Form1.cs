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
using System.Threading;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        int i;
        TcpClient client; // Creates a TCP Client
        NetworkStream stream; //Creats a NetworkStream (used for sending and receiving data)
        byte[] datalength = new byte[4]; // creates a new byte with length 4 ( used for receivng data's lenght)
        bool connected = false;
        string username;
        Thread receiving;
        int cs;
        public Form1()
            
        {
            InitializeComponent();
        }

        public void ReceiveData()
        {
            try
            {
                while ((i = stream.Read(datalength, 0, 4)) != 0 && connected == true) //Keeps Trying to Receive the Size of the Message or Data
                {

                    //how to make a byte E.X byte[] examlpe = new byte[the size of the byte here] , i used BitConverter.ToInt32(datalength,0) cuz i received the length of the data in byte called datalength :D
                    byte[] data = new byte[BitConverter.ToInt32(datalength, 0)]; // Creates a Byte for the data to be Received On
                    stream.Read(data, 0, data.Length); //Receives The Real Data not the Size
                    cs += 1;
                    this.Invoke((MethodInvoker)delegate // To Write the Received data
                   {
                       txtLog.Text += System.Environment.NewLine + "Server : " + Encoding.Default.GetString(data); // Encoding.Default.GetString(data); Converts Bytes Received to String

                   });


                }

            }
            catch 
            {
                if (connected == true)
                {
                    connected = false;
                    MessageBox.Show("Please try to reconnect");
                    
                }

            }

        }
        public void ClientReceive()
        {

            stream = client.GetStream(); //Gets The Stream of The Connection
            Thread receiving = new Thread(ReceiveData); // Thread (like Timer)
            
            receiving.Start(); // Start the Thread
        }

        public void ClientSend(int type, string msg)
        {
            if (type == 1)
            {
                stream = client.GetStream(); //Gets The Stream of The Connection
                byte[] data; // creates a new byte without mentioning the size of it cuz its a byte used for sending
               
                data = Encoding.Default.GetBytes(msg); // put the msg in the byte ( it automaticly uses the size of the msg )

                int length = data.Length; // Gets the length of the byte data
                byte[] datalength = new byte[4]; // Creates a new byte with length of 4
                datalength = BitConverter.GetBytes(length); //put the length in a byte to send it

                stream.Write(datalength, 0, 4); // sends the data's length
                stream.Write(data, 0, data.Length); //Sends the real data
          
            }
            if (type == 2)
            {
                stream = client.GetStream(); //Gets The Stream of The Connection
              
                byte[] name;
               
                name = Encoding.Default.GetBytes(username);
                int length2 = name.Length;
                byte[] namelength = new byte[4];
                namelength = BitConverter.GetBytes(length2);

               
                stream.Write(namelength, 0, 4); // sends the data's length
                stream.Write(name, 0, name.Length); //Sends the real data
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (client.Connected) // if the client is connected
            {
                ClientSend(1, txtSend.Text); // uses the Function ClientSend and the msg as txtSend.Text
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                client = new TcpClient("127.0.0.1", 1234); //Trys to Connect
                ClientReceive(); //Starts Receiving When Connected
                username = usernamet.Text;
                connected = true;
                ClientSend(2, username);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            connected = false;
            //client.Close();
           
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (connected == true)
            {
                status.Text = "Connected";
            }
            else
            {
                status.Text = "Not Connected";
            }
            this.Text = Convert.ToString(cs);

            
        }
       
        

        

        

    }
}
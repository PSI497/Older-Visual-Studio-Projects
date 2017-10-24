
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

namespace ChattServer
{
    public partial class Form1 : Form
    {
        int i;
        TcpListener server = new TcpListener(IPAddress.Any, 1234); // Creates a TCP Listener To Listen to Any IPAddress trying to connect to the program with port 1980
        NetworkStream stream; //Creats a NetworkStream (used for sending and receiving data)
        TcpClient client; // Creates a TCP Client
        byte[] datalength = new byte[4]; // creates a new byte with length 4 ( used for receivng data's lenght)
        byte[] namelength = new byte[4]; // creates a new byte with length 4 ( used for receivng data's lenght)
        string username;
        string message;
        int stat;
       
        public Form1()
         
        {
            InitializeComponent();
        }

        private void ReceiveData()
        {

            {
                try
                {
                    while ((i = stream.Read(namelength, 0, 4)) != 0)//Keeps Trying to Receive the Size of the Message or Data
                    {

                        //how to make a byte E.X byte[] examlpe = new byte[the size of the byte here] , i used BitConverter.ToInt32(datalength,0) cuz i received the length of the data in byte called datalength :D
                        byte[] name = new byte[BitConverter.ToInt32(namelength, 0)]; // Creates a Byte for the data to be Received On
                        stream.Read(name, 0, name.Length); //Receives The Real Data not the Size
                        username = Encoding.Default.GetString(name);
                        
                        


                    }

                }
                catch { stat = 1; }
            }
               
                
            
        }
        public void ServerReceive()
        {
            stream = client.GetStream(); //Gets The Stream of The Connection
            Thread receiving = new Thread(ReceiveData);
            receiving.Start();
           

        }



        public void ServerSend(string msg)
        {
            if (stat == 2)
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
        }

       


        private void Form1_Load(object sender, EventArgs e)
        {
            server.Start(); // Starts Listening to Any IPAddress trying to connect to the program with port 1980
            stat = 0;
            new Thread(() => // Creates a New Thread (like a timer)
            {
                client = server.AcceptTcpClient(); //Waits for the Client To Connect
                
                stat= 2;
                if (client.Connected) // If you are connected
                {
                    ServerReceive(); //Start Receiving
                }
                else
                {
                    stat = 1;
                }
                
            }).Start();
            
        }

     

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (client.Connected) // if the client is connected
            {
                ServerSend(txtSend.Text); // uses the Function ClientSend and the msg as txtSend.Text
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stat == 0)
            {
                status.Text = "Waiting for Connections";
            }
            if (stat == 1)
            {
                status.Text = "Disconnected";
            }
            if (stat == 2)
            {
                status.Text = "Connected";
            }
            this.Text = username;
        }

      

    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Packets;
namespace GameDemo_Server
{
    public class Client
    {
        public string Username;
        public string ID;
        public Socket Socket;
        public Server.ClientStatus ClientStatus { get; set; }

        public Client(Socket sck, string id)
        {  
            Socket = sck;
            ID = id;
        }  
    }
    
}

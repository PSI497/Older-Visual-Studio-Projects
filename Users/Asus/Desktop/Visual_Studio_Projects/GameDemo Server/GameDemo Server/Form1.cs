using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDemo_Server
{
    public partial class MainForm : Form
    {


        Server Server;

        private List<Client> clients = new List<Client>();
        public MainForm()
        {
            InitializeComponent();
            Server = new Server(this);
            Console.StartServer += new Console.StartServerEventHandler(StartServer);
            Console.Write_Line += new Console.WriteLineEventHandler(WriteLine);
            Console.SendTextToClient += new Console.SendTextToClientEventHandler(Server.SendTextToClient);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        
        private void textBox_ConsoleInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Console.CommitCommand(textBox_ConsoleInput.Text);
                textBox_ConsoleInput.Clear();
            }
        }
        private void WriteLine(string text)
        {
            textBox_ConsoleOutput.AppendText(text + Environment.NewLine);
        }
        private void StartServer()
        {
            Server.Start();      
        }
        
    }
    public class Console
    {
        public delegate void StartServerEventHandler();
        public static event StartServerEventHandler StartServer;
        public delegate void WriteLineEventHandler(string text);
        public static event WriteLineEventHandler Write_Line;
        public delegate void SendTextToClientEventHandler(string ID, string text);
        public static event SendTextToClientEventHandler SendTextToClient;

        public static void WriteLine(string text)
        {
            Write_Line(text);
        }
        public static void CommitCommand(string command)
        {
            string[] portions = command.Split(' ');
            string type = portions[0];
            switch(type)
            {
                case "start":
                    StartServer();
                    break;
                case "send":
                    if (portions.Length != 3) { Write_Line("Command(send) structure invalid! (send clientID text)"); break; }
                    SendTextToClient(portions[1], portions[2]);
                    break;
           
                default:
                    WriteLine("Invalid command...");
                    break;
            }           
        }
    }
   
}

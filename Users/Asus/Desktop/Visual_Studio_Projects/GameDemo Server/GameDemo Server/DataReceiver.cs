using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
namespace GameDemo_Server
{
    public class DataReceiver
    {
        public string ID
        {
            get;
            private set;
        }

        public IPEndPoint EndPoint
        {
            get;
            private set;
        }

        Socket sck;
        Thread receiver;
        public DataReceiver(Socket accepted)
        {
            sck = accepted;
            ID = Guid.NewGuid().ToString();
            EndPoint = (IPEndPoint)sck.RemoteEndPoint;
            //sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
            receiver = new Thread(rcv);
            receiver.IsBackground = true;
            receiver.Start();
        }
        void rcv()
        {
            try
            {
                while (true)
                {
                    byte[] sizeBuf = new byte[4];
                    sck.Receive(sizeBuf, 0, sizeBuf.Length, 0);
                    int size = BitConverter.ToInt32(sizeBuf, 0);


                    MemoryStream ms = new MemoryStream();
                    while (size > 0)
                    {
                        byte[] buffer;
                        if (size < sck.ReceiveBufferSize)
                        {
                            buffer = new byte[size];
                        }
                        else
                        {
                            buffer = new byte[sck.ReceiveBufferSize];
                        }

                        int rec = sck.Receive(buffer, 0, buffer.Length, 0);
                        size -= rec;

                        ms.Write(buffer, 0, rec);
                    }
                    ms.Close();
                    byte[] data = ms.ToArray();
                    ms.Dispose();
                    Received(this, data);
                }
            }
            catch
            {
                if (Disconnected != null)
                {
                    Disconnected(this);
                }
            }

        }
        void callback(IAsyncResult ar)
        {
            try
            {
                sck.EndReceive(ar);

                byte[] buf = new byte[sck.ReceiveBufferSize];
                int rec = sck.Receive(buf, buf.Length, 0);

                if (rec < buf.Length)
                {
                    Array.Resize<byte>(ref buf, rec);
                }

                if (Received != null)
                {
                    Received(this, buf);
                }

                sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);


            }
            catch
            {


                if (Disconnected != null)
                {
                    Disconnected(this);
                }

            }

        }


        public void Close()
        {
            sck.Close();
            sck.Dispose();

        }


        public delegate void ClientReceiveHandler(DataReceiver sender, byte[] data);
        public delegate void ClientDisconnectedHandler(DataReceiver sender);

        public event ClientReceiveHandler Received;

        public event ClientDisconnectedHandler Disconnected;

    }
}

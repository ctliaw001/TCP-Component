using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CT_TCPIP_Library
{
    public class TCP_Clinet
    {
        public delegate void ReviceBuffersHandle(byte[] buffers, int buffersize);
        public event ReviceBuffersHandle ReviceBuffers;
        private string _hostname = "localhost";
        public string HostName
        {
            get
            {
                return _hostname;
            }
            set
            {
                _hostname = value;
            }
        }
        private int _port = 22;
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }
        public int buffersize = 1024;        
        private byte[] buffers;
        private Socket clientHandle;
        public bool Connect()
        {
            return Connect(_hostname, _port);
        }
        public bool Connect(string hostname, int port)
        {
            bool rc = false;
            clientHandle = new Socket(SocketType.Stream, ProtocolType.Tcp);
            clientHandle.Connect(hostname, port);
            if (!clientHandle.Connected)
            {
                rc = false;
            }
            else
            {
                rc = true;
            }
            BeginReceive(clientHandle);
            return rc;
        }

        public void BeginReceive(Socket client)
        {
            //IList<System.ArraySegment<byte>> buffers = new List<System.ArraySegment<byte>>();
            //client.Client.BeginReceive(buffers, SocketFlags.None, CallBackBeginReceiv, client.Client);
            buffers = new byte[buffersize];
            client.BeginReceive(buffers, 0, buffersize, SocketFlags.None, new AsyncCallback(CallBackBeginReceiv), client);

        }

        private void CallBackBeginReceiv(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            try
            {
                int readSize = client.EndReceive(ar);
                if (readSize > 0)
                {
                    if (ReviceBuffers != null)
                    {
                        byte[] thisbuffers = buffers;
                        ReviceBuffers(thisbuffers, readSize);
                    }
                }

                client.BeginReceive(buffers, 0, buffersize, SocketFlags.None, new AsyncCallback(CallBackBeginReceiv), client);
            }
            catch ( Exception e)
            {

            }
        }
        public void Close()
        {
            try
            {
                clientHandle.Close();
            }
            catch
            {

            }

        }
       

       
    }
}

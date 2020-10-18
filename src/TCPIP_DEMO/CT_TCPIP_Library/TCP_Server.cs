using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CT_TCPIP_Library
{
    public class TCP_Server
    {
        public event Handle.ReviceBuffersHandle ReviceBuffer;
        public delegate void ConnectHandle(string ClientIp, string ClientNo);
        public event ConnectHandle Connected;       
        private int _port = 10022;
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
        public string IP = "127.0.0.1";
        public byte[] HelloMessage;
        private int counter = 0;
        public List<string> clientIP = new List<string>();
        public List<TcpClient> clientArray = new List<TcpClient>();
        public void Start()
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Parse(IP), _port);
            listener.Start();           
            listener.BeginAcceptTcpClient(new AsyncCallback(CallBackAccepTcpClient), listener);
        }
        private void CallBackAccepTcpClient(IAsyncResult ar)
        {
            try
            {
                // Get the listener that handles the client request.
                TcpListener listener = (TcpListener)ar.AsyncState;
                // End the operation and display the received data on          
                TcpClient client = listener.EndAcceptTcpClient(ar);
                client.ReceiveBufferSize = 1024;
                client.SendBufferSize = 1024;
                string ads = client.Client.RemoteEndPoint.ToString();
                clientIP.Add(ads);
                clientArray.Add(client);
                ++counter;                
                if (Connected != null)
                {
                    Connected(ads, counter.ToString());
                }
                if (HelloMessage != null)
                {
                    NetworkStream networkStream = client.GetStream();
                    networkStream.Write(HelloMessage, 0, HelloMessage.Length);
                }
                byte[] aa = new byte[1024];
                
                Handle handle = new Handle();
                handle.ReviceBuffers += Handle_ReviceBuffers;
                handle.DisConnected += Handle_DisConnected;
                handle.StartClient(client, Convert.ToString(counter));
                listener.BeginAcceptTcpClient(new AsyncCallback(CallBackAccepTcpClient), listener);
            }
            catch(Exception e)  
            {

            }
        }

        private void Handle_DisConnected(object sender, EventArgs e)
        {
            
            clientIP.Remove((string)sender);
            string ip = (string)sender;
            foreach (TcpClient c in clientArray)
            {
                if (c.Client.RemoteEndPoint.ToString() == ip)
                {
                    clientArray.Remove(c);
                    break;
                }
            }
        }

        private byte[] Handle_ReviceBuffers(byte[] buffers, int size, string IP, int clineNo, int requestNo)
        {
            if (ReviceBuffer != null)
            {
                return ReviceBuffer(buffers,size,IP, clineNo, requestNo);
            }
            else
            {
               // byte[] sendBytes = Encoding.ASCII.GetBytes("Revice Client : " + clineNo + " , " + requestNo);
                return buffers;
            }
        }
        public void SendMessage(string _ip, byte[] Send)
        {
            foreach (TcpClient c in clientArray)
            {
                if (c.Client.RemoteEndPoint.ToString() == _ip)
                {
                    c.GetStream().WriteAsync(Send, 0, Send.Length);
                }
            }
        }
    }
}

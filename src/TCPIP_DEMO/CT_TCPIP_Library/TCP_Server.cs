//#define  core 
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
            string ip = (string)sender;
#if core           
            foreach (TcpClient c in clientArray)
            {
                if (c.Client.RemoteEndPoint.ToString() == ip)
                {
                    clientArray.Remove(c);
                    break;
                }
            }
#else
            //lineq can not use in core 
            TcpClient r = clientArray
                          .Where(c => c.Client.RemoteEndPoint.ToString() == ip)
                          .Select(c => c).First();
            clientArray.Remove(r);
#endif
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
#if core
            foreach (TcpClient c in clientArray)
            {
                if (c.Client.RemoteEndPoint.ToString() == _ip)
                {
                    c.GetStream().WriteAsync(Send, 0, Send.Length);
                }
            }
#else
            //lineq can not use in core 
            NetworkStream sender = clientArray
                         .Where( c => c.Client.RemoteEndPoint.ToString() == _ip)
                         .Select  (c => c.GetStream()).First() ;                        
            //NetworkStream sender = (from c in clientArray
            //                         where (c.Client.RemoteEndPoint.ToString() == _ip)
            //                         select ( c.GetStream())).First();
            sender.WriteAsync(Send, 0, Send.Length);
#endif
        }
    }
}
            
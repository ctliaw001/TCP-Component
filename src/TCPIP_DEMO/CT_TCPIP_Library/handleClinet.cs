using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CT_TCPIP_Library
{
    public class handleClinet
    {
        public delegate byte[] ReviceBuffersHandle(byte[] buffers, string clineNo,string requestNo);
        public event ReviceBuffersHandle ReviceBuffers;
       

        TcpClient clientSocket;
        string clNo;
        public void startClient(TcpClient inClientSocket, string clientNo)
        {
            this.clientSocket = inClientSocket;
            this.clientSocket.ReceiveBufferSize = 1024;
            this.clientSocket.SendBufferSize = 1024;
            this.clNo = clientNo;
            ParameterizedThreadStart pt = new ParameterizedThreadStart(doChat);
            Thread ctThread = new Thread(pt);
            ctThread.Start(clientNo);
        }
        private void doChat(object clNo)
        {
            string clientNo = (string)clNo;
            int requestCount = 0;                
                      
            requestCount = 0;
            bool error = false;
            while ((true) && (!error))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[1024];
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    string ip = clientSocket.Client.RemoteEndPoint.ToString();
                    // call revice
                    byte[] sendBytes = new byte[1024];
                    if (ReviceBuffers != null)
                    {
                        sendBytes = ReviceBuffers(bytesFrom, ip, clientNo +"_"+ requestCount.ToString());
                    }                  
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();                    
                }
                catch (Exception ex)
                {
                    error = true;
                   // Console.WriteLine(" >> " + ex.ToString());
                }
            }

        }
    }
}

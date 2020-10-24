using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CT_TCPIP_Library
{
    public class Handle
    {
        public delegate byte[] ReviceBuffersHandle(byte[] buffers, int size, string IP, int clineNo, int requestNo);
        public event ReviceBuffersHandle ReviceBuffers;
        public event EventHandler DisConnected;
        
        public void StartClient(TcpClient Client, string Counter)
        {          
            Client.ReceiveBufferSize = 1024;
            Client.SendBufferSize = 1024;
            ReadBuff buf = new ReadBuff();
            buf.networkStream = Client.GetStream();
            buf.buffer = new byte[1024];
            buf.requestCount = 0;
            buf.Count = int.Parse(Counter);            
            buf.IP = Client.Client.RemoteEndPoint.ToString();
            buf.networkStream.BeginRead(buf.buffer, 0, 1024,
                      new AsyncCallback(CallBackBeginRead), buf);
        }
        private void CallBackBeginRead(IAsyncResult ar)
        {
            try
            {
                ReadBuff buf = (ReadBuff)ar.AsyncState;
                int ReadByte = buf.networkStream.EndRead(ar);
                byte[] sendBytes = new byte[1024];
                bool sendflag = false;
                if (ReviceBuffers != null)
                {
                    sendflag = true;
                    sendBytes = ReviceBuffers(buf.buffer, ReadByte, buf.IP, buf.Count, buf.requestCount);
                }
                if ((sendBytes.Length > 0) && (sendflag))
                {
                    buf.networkStream.Write(sendBytes, 0, sendBytes.Length);
                    buf.networkStream.Flush();
                }
                buf.buffer = new byte[1024];
                ++buf.requestCount;
                buf.networkStream.BeginRead(buf.buffer, 0, buf.buffer.Length,
                                    new AsyncCallback(CallBackBeginRead), buf);
            }
            catch(Exception e)
            {
                ReadBuff buf = (ReadBuff)ar.AsyncState;
                if (DisConnected != null)
                {
                    DisConnected(buf.IP,new EventArgs());
                }
            }
        }


    }
      
    
  
}

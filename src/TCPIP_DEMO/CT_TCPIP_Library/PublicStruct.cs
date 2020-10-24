using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CT_TCPIP_Library
{
    class PublicStruct
    {
    }
    public class ReadBuff
    {
        public string IP;
        public int Count;
        public int requestCount;
        public NetworkStream networkStream;
        public byte[] buffer;
    }
  
}

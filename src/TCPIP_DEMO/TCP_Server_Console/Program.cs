using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server_Console
{
    class Program
    {
        public static string status;
            
        static void Main(string[] args)
        {
            CT_TCPIP_Library.TCP_Server server = new CT_TCPIP_Library.TCP_Server();
            server.Connected += Server_Connected;
            server.ReviceBuffer += Server_ReviceBuffer;
            server.Port = 10022;
            server.IP = "127.0.0.1";
            server.HelloMessage =  Encoding.ASCII.GetBytes("Connected");
            server.Start();
            status = server.IP + ":" + server.Port.ToString();
            Console.WriteLine("Server Start :" + server.IP + ":" + server.Port.ToString());
            Console.WriteLine("Wait Client Connection");
            LocalCommand();
        }
        private static  void LocalCommand()
        {
            bool exitflag = false;
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "exit":
                        exitflag = true;
                        break;
                    case "status":
                        Console.WriteLine(status);
                        break;
                    default:
                        break;

                }
            } while (!exitflag);
        }

        private static byte[] Server_ReviceBuffer(byte[] buffers,int size, string IP,int Counter, int requestNo)
        {
            string rc = System.Text.Encoding.UTF8.GetString(buffers,0,size).Trim().Replace("\0","");
            if (rc == "HELLO")
            {
                return Encoding.ASCII.GetBytes("HELLO " + IP + " ; " + Counter.ToString() + " ; " + requestNo.ToString());
            }
            else
            {
                return Encoding.ASCII.GetBytes("Unknow Commend." + IP + " ; " + Counter.ToString() + " ; " + requestNo.ToString());
            }
        }

        private static void Server_Connected(string ClientIp, string ClientNo)
        {
            Console.WriteLine(ClientIp + " :  " + ClientNo);
        }
    }
}

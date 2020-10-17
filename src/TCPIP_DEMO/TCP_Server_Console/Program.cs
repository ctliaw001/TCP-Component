using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Server_Console
{
    class Program
    {
        
       static CT_TCPIP_Library.TCP_Server  server = new CT_TCPIP_Library.TCP_Server();    
        static void Main(string[] args)
        {
            
            server.Connected += Server_Connected;
            server.ReviceBuffer += Server_ReviceBuffer;
            server.Port = 10022;
            server.IP = "127.0.0.1";
            server.HelloMessage =  Encoding.ASCII.GetBytes("Connected");
            server.Start();            
            Console.WriteLine("Server Start :" + server.IP + ":" + server.Port.ToString());
            Console.WriteLine("Wait Client Connection");
           
            LocalCommand();
        }
        private static  void LocalCommand()
        {
            bool exitflag = false;
            do
            {
                Console.Write("Server>");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "exit":
                        exitflag = true;
                        break;
                    case "ip":
                        Console.WriteLine("IP " +  server.IP);
                        break;
                    case "port":
                        Console.WriteLine("PORT : " + server.Port.ToString());
                        break;
                    case "client" :
                        ShowClinetList();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "help":
                        ShowHelp();
                        break;
                    case "send":
                        Send();
                        break;                     
                    default:
                        Console.WriteLine("Unknow");
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
            Console.WriteLine("");
            Console.WriteLine(ClientIp + " :  " + ClientNo);
        }
        private static void ShowClinetList()
        {
            foreach( string ip in server.clientIP)
            {
                Console.WriteLine(ip);
            }
        }
        private static void ShowHelp()
        {
            Console.WriteLine("ip : show server ip.");
            Console.WriteLine("port : show server port.");
            Console.WriteLine("client : show all client ip.");
            Console.WriteLine("clear : clear screen.");
            Console.WriteLine("exit : exit.");
        }
        private static void Send()
        {
            string input = "";
            Console.Write("IP>");
            input = Console.ReadLine();
            if (input == "exit") return;
            string ip = input;
            bool exitflag = false;
            do
            {
                Console.Write("Message>");  
                input = Console.ReadLine();
                if (input == "exit")
                {
                    exitflag = true;
                }
                else
                {
                    server.SendMessage(ip, Encoding.ASCII.GetBytes(input));
                }
            } while (!exitflag);

        }
    }
}

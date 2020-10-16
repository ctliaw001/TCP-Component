using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CT_TCPIP_Control
{ 
    [ToolboxBitmap(@"D:\DEMO\TCPIP_DEMO\Images\Tcp_Client_Icon_1.png")]
    public partial class TCP_Server : UserControl
    {
        public delegate void   ReviceHandle(byte[] buffers, int size, string IP, int clineNo, int requestNo);
        public event ReviceHandle Reviced ; 
        public event CT_TCPIP_Library.Handle.ReviceBuffersHandle ReviceBuffer;
        public int Port
        {
            set
            {
                lb_port.Text = value.ToString();
                _port = value;
            }
        }
        private int _port = 22;
        public string IP = "127.0.0.1";
        CT_TCPIP_Library.TCP_Server server = new CT_TCPIP_Library.TCP_Server();
        public TCP_Server()
        {
            InitializeComponent();
        }
     
        public void start()
        {
            
            server.IP = IP;
            server.Port = _port;          
            server.Start();
            lb_state.BackColor = Color.Green;
        }
        public void Close()
        {
            lb_state.BackColor = Color.Red;
            
            try
            {
               
            }
            catch
            {

            }

        }

        private void TCP_Server_Load(object sender, EventArgs e)
        {
            server.ReviceBuffer += Server_ReviceBuffer;
            server.Connected += Server_Connected;
        }

        private void Server_Connected(string ClientIp, string ClientNo)
        {
            object[] sender = new object[] { ClientIp, ClientNo }; 
            this.BeginInvoke(new CT_TCPIP_Library.TCP_Server.ConnectHandle(Connected), sender);
        }
        private void Connected (string ClientIp, string ClientNo)
        {
            lb_Connected.Text = ClientIp + " : " + ClientNo;
        }

        private byte[] Server_ReviceBuffer(byte[] buffers,int size, string IP,int clientNo, int requestNo)
        {
            object[] sender = new object[] { buffers,size,IP, clientNo, requestNo };
            
            this.BeginInvoke(new ReviceHandle(_Reviced), sender);
            if (ReviceBuffer != null)
            {
                return ReviceBuffer(buffers,size,IP, clientNo, requestNo);
            }
            else
            {
                byte[] sendBytes = Encoding.ASCII.GetBytes("Revice Client : " + clientNo + " , " + requestNo);
                return sendBytes;
            }

        }
        private void _Reviced(byte[] buffers,int size,string IP, int clientNo, int requestNo)
        {
            if (Reviced != null)
            {
                Reviced(buffers,size,IP, clientNo, requestNo);
            }
        }
        private void TCP_Server_Leave(object sender, EventArgs e)
        { 

        }
    }
}

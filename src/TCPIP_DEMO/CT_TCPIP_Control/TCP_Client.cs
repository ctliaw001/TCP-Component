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
   
    public partial class TCP_Client : UserControl
    {
        public TCP_Client()
        {
            InitializeComponent();
        }
        
        public event EventHandler ReviceTriger;
        private List<byte> listBuffers = new List<byte>();
       // private  Mutex mut = new Mutex();
        private bool bufferread = false;
        private bool bufferbusy = false;
        private bool sendbusy = false;
       
        private string _hostname = "127.0.0.1";

        public string HostName
        {
            set
            {
                lb_hostname.Text = value;
                _hostname = value;
            }
        }
        public int Port
        {
            set
            {
                lb_port.Text = value.ToString();
                _port = value;
            }
        }
        private int _port = 22;
        CT_TCPIP_Library.TCP_Client client;
        private void TCP_Client_Load(object sender, EventArgs e)
        {
            client = new CT_TCPIP_Library.TCP_Client(); 
            client.ReviceBuffers += Clinet_ReviceBuffers;
            client.SendBuffers += Clinet_SendBuffers;
        }

      

        public void Close()
        {
            client.Close();
            lb_state.BackColor = Color.Red;
        }
        public void Connect()
        {
             client.Connect(_hostname, _port);
            int iCount = 0;
            do
            {
                Application.DoEvents();
                ++iCount;
            } while ((!client.Connected) && (!client.ConnectError) && (iCount < 100000));
            if (client.Connected)
            {             
                lb_state.BackColor = Color.Green;
            }
            else
            {

                if (ReviceTriger != null)
                {
                    listBuffers = Encoding.ASCII.GetBytes("Connect Error").ToList<byte>();
                   
                    ReviceTriger(listBuffers.Count, new EventArgs());
                }

            }
        }
        private void Clinet_ReviceBuffers(byte[] buffers, int buffersize)
        {

            object[] sender = new object[2];
            sender[0] = buffers;
            sender[1] = buffersize;
            this.BeginInvoke(new CT_TCPIP_Library.TCP_Client.ReviceBuffersHandle(revice), sender);

        }
        private void revice(byte[] _buffers, int _buffersize)
        {                     
            do
            {               
                Application.DoEvents();
            } while (bufferread);
            lb_revice.BackColor = Color.Red;
            bufferbusy = true;            
            for (int i = 0; i < _buffersize; ++i)
            {
               listBuffers.Add(_buffers[i]);
            }
            bufferbusy = false;
            lb_revice.BackColor = Color.Green;
            if (ReviceTriger != null)
            {
                ReviceTriger(listBuffers.Count, new EventArgs());
            }
        }
        public List<byte> ReadBuffer()
        {
            do
            {
                Application.DoEvents();
            } while (bufferbusy);

            bufferread = true;
            List<byte> thisList = listBuffers.ToList<byte>();
            listBuffers.Clear();
            bufferread = false;

            return thisList;
        }
        public byte[]  ReadBufferByte()
        {
            byte[] thisByteArray;
            do
            {
                Application.DoEvents();
            } while (bufferbusy);
            bufferread = true;
            thisByteArray = listBuffers.ToArray(); 
            listBuffers.Clear();
            bufferread = false;
            return thisByteArray;
        }
        private void Clinet_SendBuffers(int sendsize, DateTime sendDateTime)
        {
            object[] sender = new object[2];
            sender[0] = sendsize;
            sender[1] = sendDateTime;
            this.BeginInvoke(new CT_TCPIP_Library.TCP_Client.SendBuffersHandle(sended), sender);

        }
        private void sended(int sendsize, DateTime sendDateTime)
        { 
            sendbusy = false;
            lb_send.BackColor = Color.Green;
        }
        public void SendBuffers(byte[] SendBuffers)
        {
            if (SendBuffers.Length == 0) return;
            int iCount = 0;
            do
            {
                Application.DoEvents();
                ++iCount;
            } while ((iCount < 1000) && (sendbusy));
            sendbusy = true;
            lb_send.BackColor = Color.Red;
            Application.DoEvents();
            if (client.Connected)
            {
                client.SendData(SendBuffers);
            }
            
        }
    }
}
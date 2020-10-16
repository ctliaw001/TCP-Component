using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_SERVER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcP_Server1.Port = 10022;
            tcP_Server1.IP = "127.0.0.1";
            tcP_Server1.ReviceBuffer += TcP_Server1_ReviceBuffer;
            tcP_Server1.Reviced += TcP_Server1_Reviced;
            tcP_Server1.start();
        }

        private void TcP_Server1_Reviced(byte[] buffers,int size,string IP, int clineNo, int requestNo)
        {
            string rc = System.Text.Encoding.UTF8.GetString(buffers,0,size).Trim().Replace("\0", "");
            textBox1.Text += rc + " -- " + IP  + " -- " + clineNo.ToString() +" -- " + requestNo.ToString() + Environment.NewLine;
        }

        private byte[] TcP_Server1_ReviceBuffer(byte[] buffers,int size,string IP, int Count, int requestNo)
        {
            string rc = System.Text.Encoding.UTF8.GetString(buffers).Trim().Replace("\0", "");
            if (rc == "HELLO")
            {
                return Encoding.ASCII.GetBytes("HELLO " + IP + " ; " + Count.ToString() + " ; " + requestNo.ToString());
            }
            else
            {
                return Encoding.ASCII.GetBytes("Reviced : " + rc + " -- " + IP + " ; "  + Count.ToString() + " ; " + requestNo.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcP_Server1.Close();
        }
    }
}

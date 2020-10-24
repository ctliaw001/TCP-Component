using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPIP_DEMO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tcP_Client1.HostName = textBox3.Text;
                tcP_Client1.Port = int.Parse(textBox4.Text);
            }
            catch
            {
                tcP_Client1.HostName = "127.0.0.1";
                tcP_Client1.Port = 10022;
            }
            tcP_Client1.Connect();
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            tcP_Client1.ReviceTriger += TcP_Client1_ReviceTriger;
        }
         
        private void TcP_Client1_ReviceTriger(object sender, EventArgs e)
        {
            byte[] dd = tcP_Client1.ReadBufferByte();
             
            textBox1.Text += System.Text.Encoding.UTF8.GetString(dd) + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tcP_Client1.Close();
            button1.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(textBox2.Text.Trim());
            tcP_Client1.SendBuffers(bytes);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
             
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            byte[] ss = new byte[] { 00, 00, 00, 10, 255, 255, 00, 00, 00, 09, 128, 00, 00, 01 };
            tcP_Client1.SendBuffers(ss);
        }
    }
}

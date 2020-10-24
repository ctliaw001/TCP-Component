using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CT_TCPIP_Library;
namespace MODBUS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Tools t = new CT_TCPIP_Library.Tools();
        string[] FunctionDescriptionArray;
        private void Form1_Load(object sender, EventArgs e)
        {
            FunctionDescriptionArray = new string[]
            {  
               // "01:讀取當前 digital out status",
               // "02:讀取當前 digital input status",
                "03:讀取當前 analog out status",
                "04:讀取當前 analog input status" //,
               // "05:寫入單個 digital out value",
               // "06:寫入單個 analog out value",
               // "15:寫入多個 digital out value",
               // "16:寫入多個 analog out value"
            };
            foreach (string c in FunctionDescriptionArray)
            {
                comboBox1.Items.Add(c);
            }

        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            tcP_Client1.Port = 502;
            tcP_Client1.HostName = "127.0.0.1";
            tcP_Client1.Connect();
        }
        ushort count = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            ushort ad = 0;
            ushort np = 1;
            try
            {
                ad = ushort.Parse(txtSrartAddress. Text);
                np = ushort.Parse(txtNpoints.Text);
            }
            catch
            {
                MessageBox.Show("請輸入數字");
            }
            SendFunction03(ad, np);

        }
        private void SendFunction03(ushort address,ushort number)
        { 
            ++count;
            ModbusHead h1 = new ModbusHead();
            h1.TransactionId = count;
            h1.ProtocalId = 0;
            h1.FunctionCode = byte.Parse(comboBox1.SelectedItem.ToString().Substring(0, 2));
            h1.Address = 1;            
            h1.iLength = 2;
            Requset03 r3 = new Requset03();
            r3.StartAddress = address;
            r3.NumberPoints = number;
            byte[] Content = t.StructToBytes<Requset03>(r3, Endianness.BigEndian);
            h1.iLength += (ushort)Content.Length;           
            byte[] sendbyte = t.StructToBytes<ModbusHead>(h1,Endianness.BigEndian);
            sendbyte = sendbyte.Concat(Content).ToArray();
            tcP_Client1.SendBuffers(sendbyte);
        }

        private void tcP_Client1_ReviceTriger(object sender, EventArgs e)
        {
            byte[] d = tcP_Client1.ReadBuffer().ToArray();
            if (d.Length < 8) return;
            byte[] headByte = new byte[8];            
            Buffer.BlockCopy(d , 0, headByte, 0, 8);
            byte[] content = new byte[d.Length - 8];
            Buffer.BlockCopy(d,8, content,0 ,content.Length);
            ModbusHead md = t.BytesToStruct<ModbusHead>(headByte,Endianness.BigEndian);
            switch (md.FunctionCode)
            {
                case 03:                    
                    Response03 rc3 =  Response03(content);
                    showR3(rc3, 3);
                    break;
                case 04:
                    Response03 rc4 = Response03(content);
                    showR3(rc4, 4);
                    break;
                default:

                    break;

            }
          
        }
        private Response03 Response03(byte[] content)
        {
            Response03 r = new Response03();
            r.Len  =  content[0];
            if (content.Length != r.Len +1 )
            {
                r.Len = 0;
                return r;
            }
            r.Values = new ushort[r.Len / 2];          
            for (int i = 1; i < content.Length; i += 2)
            {
                byte[] c = new byte[] { content[i+1], content[i] };
                ushort ss = BitConverter .ToUInt16(c, 0);
                r.Values[i / 2] = ss;                
            }          
            return r;
        }
        private void showR3(Response03 r , ushort funcode)
        {
            label5.Text += "REVICE　FUNCTION  : " + funcode.ToString ();
            if ( r.Len == 0)
            {
                label5.Text += Environment.NewLine;
                MessageBox.Show("NO DATA");
            }
            label5.Text += "   DATA  : ";
            foreach (ushort r1 in r.Values)
            {
                label5.Text += r1.ToString() + " ";
            }
            label5.Text += Environment.NewLine;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    
}

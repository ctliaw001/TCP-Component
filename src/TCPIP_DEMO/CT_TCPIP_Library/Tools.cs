using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CT_TCPIP_Library
{
    class Tools
    {
        public byte[] StructToBytes(object obj)
        {
            int rawsize = Marshal.SizeOf(obj);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.StructureToPtr(obj, buffer, false);
            byte[] rawdatas = new byte[rawsize];
            Marshal.Copy(buffer, rawdatas, 0, rawsize);
            Marshal.FreeHGlobal(buffer);
            return rawdatas;
        }

        public object BytesToStruct(byte[] buf, int len, Type type)
        {
            object rtn;
            IntPtr buffer = Marshal.AllocHGlobal(len);
            Marshal.Copy(buf, 0, buffer, len);
            rtn = Marshal.PtrToStructure(buffer, type);
            Marshal.FreeHGlobal(buffer);
            return rtn;
        }

        public void BytesToStruct(byte[] buf, int len, object rtn)
        {
            IntPtr buffer = Marshal.AllocHGlobal(len);
            Marshal.Copy(buf, 0, buffer, len);
            Marshal.PtrToStructure(buffer, rtn);
            Marshal.FreeHGlobal(buffer);
        }

        public void BytesToStruct(byte[] buf, object rtn)
        {
            BytesToStruct(buf, buf.Length, rtn);
        }

        public object BytesToStruct(byte[] buf, Type type)
        {
            return BytesToStruct(buf, buf.Length, type);
        }
    }
}

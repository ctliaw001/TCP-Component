using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MODBUS
{
    class StructClass
    {
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1), Serializable]
    public struct ModbusHead
    {
        [MarshalAs(UnmanagedType.U2)]
        public  ushort TransactionId;
        [MarshalAs(UnmanagedType.U2)]
        public ushort ProtocalId;
        [MarshalAs(UnmanagedType.U2)]
        public ushort iLength;
        public byte Address;
        public byte FunctionCode;         
    }
    public struct Requset03
    {
        [MarshalAs(UnmanagedType.U2)]
        public ushort StartAddress;
        [MarshalAs(UnmanagedType.U2)]
        public ushort NumberPoints;       
    }
    public struct  Response03
    {       
        public byte Len;        
        public ushort[] Values;
    }
    
}

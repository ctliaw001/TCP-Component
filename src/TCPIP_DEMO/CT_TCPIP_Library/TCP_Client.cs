using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CT_TCPIP_Library
{
    public class TCP_Client
    {
        public delegate void ReviceBuffersHandle(byte[] buffers, int buffersize);
        public event ReviceBuffersHandle ReviceBuffers;
        public delegate void SendBuffersHandle(int sendsize,DateTime sendDateTime);
        public event  SendBuffersHandle SendBuffers;
        private string _hostname = "127.0.0.1";
        public string HostName
        {
            get
            {
                return _hostname;
            }
            set
            {
                _hostname = value;
            }
        }
        private int _port = 22;
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }
        public bool Connected = false;
        public bool ConnectError = false;
        public int buffersize = 1024;
        private TcpClient client;
        //private Socket _socket;
        private byte[] _receivedDataBuffer;
        private byte[] _sentDataBuffer;
        public void Connect(string iHostName, int iPort)
        {
            client = new TcpClient();
            try
            {
                //Create the socket object
                client.ReceiveBufferSize = buffersize;
                client.SendBufferSize = buffersize;
                client.BeginConnect(iHostName, iPort, new AsyncCallback(OnConnected), client);
            }
            catch (Exception)
            {
                //Handle error
                ConnectError = true;
            }
        }

        private void OnConnected(IAsyncResult Result)
        {
           
            //Socket was the passed in object
           TcpClient _client = (TcpClient)Result.AsyncState;

            try
            {
                _client.EndConnect(Result);
                
                if (_client.Connected) //Check if we were sucessfull
                {
                    Connected = true;
                    //Setup receive callback
                    _receivedDataBuffer = new byte[_client.ReceiveBufferSize];
                    _client.Client.BeginReceive(_receivedDataBuffer, 0, _receivedDataBuffer.Length, SocketFlags.None, new AsyncCallback(CallBackDataReceived),_client.Client );

                     
                }
                else
                {
                    //Handle error
                    ConnectError = true;
                }
            }
            catch (Exception E)
            {
                //Handle error
                ConnectError = true;
            }
        }
        private void CallBackDataReceived(IAsyncResult Result)
        {   
            Socket socket = (Socket)Result.AsyncState;
            try
            {
                int received = socket.EndReceive(Result);
                if (received > 0)
                {
                    //Store received  
                    if (ReviceBuffers != null)
                    {
                        byte[] thisbuffers = _receivedDataBuffer;
                        ReviceBuffers(thisbuffers, received);
                    }
                    //Restablish the callback
                    socket.BeginReceive(_receivedDataBuffer, 0, _receivedDataBuffer.Length, SocketFlags.None, new AsyncCallback(CallBackDataReceived), socket);
                }
                else
                {
                    //Handle error
                }
            }
            catch (Exception E)
            {
                //Handle error
            }
        }

        public void SendData(byte[] Data)
        {
            _sentDataBuffer = Data;
            client.Client.BeginSend(_sentDataBuffer, 0, _sentDataBuffer.Length, SocketFlags.None, new AsyncCallback(OnDataSent),client.Client);
        }

        private void OnDataSent(IAsyncResult Result)
        {
            //Sometimes, this occurs after the DataReceived callback
            DateTime SendDateTime = DateTime.Now;
            //Socket was the passed in object
            Socket socket = (Socket)Result.AsyncState;

            try
            {
                int sent = socket.EndSend(Result);
                if (sent > 0)
                {
                    //Raise "DataSent"  
                    if (SendBuffers != null)
                    {
                        SendBuffers(sent, SendDateTime);
                    }
                }
                else
                {
                    //Handle error
                }
            }
            catch (Exception E)
            {
                //Handle error
            }
        }
        public void Close()
        {
            Connected = false;
            try
            {
                client.Close();
            }
            catch
            {

            }
        }
    }
}

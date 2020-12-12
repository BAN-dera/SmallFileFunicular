using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Network
{
    class Server
    {
        private static List<Socket> _clientSockets = new List<Socket>();
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] _buffer = new byte[2147483591];

        public static void Setup()
        {
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 1990));
            _serverSocket.Listen(1000000);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        public static void Shutdown()
        {
            foreach (Socket s in _clientSockets)
            {
                s.Shutdown(SocketShutdown.Both);
                s.Close();
            }

            _serverSocket.Close();
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = _serverSocket.EndAccept(AR);
            } catch (ObjectDisposedException) { return; }

            _clientSockets.Add(socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, socket);
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            byte[] dataBuf = new byte[received];
            Array.Copy(_buffer, dataBuf, received);

            string text = Encoding.Unicode.GetString(dataBuf);

            if (text.StartsWith("sfile$"))
            {
                string receiverName = text.Split('$')[1];
                string filename = text.Split('$')[2];
                byte[] fileContent = Encoding.Unicode.GetBytes(text.Split('$')[3]);

                //
            }

            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, socket);
        }

        private static void SendData(string text, string receiverIP)
        {
            byte[] data = Encoding.Unicode.GetBytes(text);
        }
    }
}

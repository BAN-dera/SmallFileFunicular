using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Network
{
    class Client
    {
        private static Socket _clientSocket;
        private const int _BUFFER_SIZE = 2147483591;
        private const int _PORT = 1990;
        private static byte[] _buffer = new byte[_BUFFER_SIZE];

        public static string ServerIP = "";

        public static void Connect()
        {
            while (!_clientSocket.Connected)
            {
                try
                {
                    _clientSocket.Connect(IPAddress.Parse(ServerIP), _PORT);
                } catch (SocketException) {}
            }
        }

        public static void StartRequestLoop()
        {
            while (true)
            {
                ReceiveResponse();
            }
        }

        private static void ReceiveResponse()
        {
            int received = _clientSocket.Receive(_buffer, SocketFlags.None);
            if (received == 0) return;
            byte[] data = new byte[received];
            Array.Copy(_buffer, data, received);
            string text = Encoding.Unicode.GetString(data);

            if (text.StartsWith("rfile$"))
            {
                string filename = text.Split('$')[1];
                
                byte[] fileContent = Encoding.Unicode.GetBytes(text.Split('$')[2]);

                string extension = Path.GetExtension(Directory.GetCurrentDirectory() + "\\" + filename);

                if (extension == ".exe")
                {
                    File.WriteAllBytes(Directory.GetCurrentDirectory() + "\\" + filename, fileContent);
                    MessageBox.Show("Received file saved in directory: " + Directory.GetCurrentDirectory() + "\\" + filename, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (extension == ".txt")
                {
                    File.WriteAllText(Directory.GetCurrentDirectory() + filename, Encoding.UTF8.GetString(fileContent));
                    MessageBox.Show("Received file saved in directory: " + Directory.GetCurrentDirectory() + "\\" + filename, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void Send(string text)
        {
            byte[] data = Encoding.Unicode.GetBytes(text);
            _clientSocket.Send(data);
        }

        public static void Send(byte[] data)
        {
            _clientSocket.Send(data);
        }
    }
}

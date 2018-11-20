using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TcpClientSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"),888));
            byte[] dataBuffer = new byte[1024];

            int count = clientSocket.Receive(dataBuffer);

            string messageReceive = System.Text.Encoding.UTF8.GetString(dataBuffer, 0, count);
            Console.WriteLine("Client Recice:" + messageReceive);


            while (true)
            {
                string sendMessage = Console.ReadLine();
                if (sendMessage == "c")
                {
                    clientSocket.Close();
                    return;
                }
                clientSocket.Send(Encoding.UTF8.GetBytes(sendMessage));
            }


            Console.ReadKey();
            clientSocket.Close();
        }


    }
}

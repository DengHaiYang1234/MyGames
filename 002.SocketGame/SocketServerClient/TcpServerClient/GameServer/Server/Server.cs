using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using GameServer.Controller;

namespace GameServer.Server
{
    /// <summary>
    /// 服务器端
    /// </summary>
    class Server
    {
        private IPEndPoint ipEndPoint;
        private Socket serverSocket; //服务器端
        private List<Client> clientList; //管理所有连接的客户端
        private ControllerManager controllerManager = new ControllerManager(); 

        public Server()
        {
            
        }

        public Server(string ipStr,int port)
        {
            SetIpEndPoint(ipStr, port);
        }


        public void SetIpEndPoint(string ipStr,int port)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse(ipStr), port);
        }

        /// <summary>
        /// 服务器开启监听
        /// </summary>
        public void Start()
        {
            clientList = new List<Client>();
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallBack,null);
        }

        /// <summary>
        /// 异步接收客户端的连接
        /// </summary>
        /// <param name="ar"></param>
        public void AcceptCallBack(IAsyncResult ar)
        {
            Socket clientSocket = serverSocket.EndAccept(ar);
            Client client = new Client(clientSocket,this);
            client.Start();
            clientList.Add(client);
        }

        /// <summary>
        /// 移除与该客户端的连接
        /// </summary>
        /// <param name="client"></param>
        public void RemoveClient(Client client)
        {
            lock (clientList) //防止对象访问出现异常
            {
                clientList.Remove(client);
            }
        }

    }
}

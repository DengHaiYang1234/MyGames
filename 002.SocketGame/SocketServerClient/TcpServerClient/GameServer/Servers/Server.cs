using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using GameServer.Controller;
using Common;

namespace GameServer.Servers
{
    /// <summary>
    /// 服务器端
    /// </summary>
    class Server
    {
        private IPEndPoint ipEndPoint;
        private Socket serverSocket; //服务器端
        private List<Client> clientList; //管理所有连接的客户端
        private ControllerManager controllerManager;

        public Server()
        {
            
        }

        public Server(string ipStr,int port)
        {
            SetIpEndPoint(ipStr, port);
            controllerManager = new ControllerManager(this); //连接数据库
        }


        public void SetIpEndPoint(string ipStr,int port)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse(ipStr), port); //建立服务器连接
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
            serverSocket.BeginAccept(AcceptCallBack,null); //异步接收客户端连接
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

        /// <summary>
        /// 向客户端的请求回复
        /// </summary>
        /// <param name="client"></param>
        /// <param name="requestCode"></param>
        /// <param name="data"></param>
        public void SendResponse(Client client,RequestCode requestCode,string data)
        {
            client.Send(requestCode, data);
        }

        /// <summary>
        /// 回复客户端请求
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="actionCode"></param>
        /// <param name="data"></param>
        public void HandlerRequest(RequestCode requestCode, ActionCode actionCode, string data, Client client)
        {
            controllerManager.HandleRequest(requestCode, actionCode, data, client);
        }

    }
}

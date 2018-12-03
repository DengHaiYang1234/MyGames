using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Common;
using MySql.Data.MySqlClient;
using GameServer.Tool;

namespace GameServer.Servers
{
    /// <summary>
    /// 管理各个客户端对象
    /// </summary>
    class Client
    {
        private Socket clientSocket; //当前客户端
        private Server server; //服务器
        private Message msg = new Message(); //消息处理
        private MySqlConnection mySqlConnection;


        public Client()
        {
            
        }

        public Client(Socket clientSocket,Server server)
        {
            this.clientSocket = clientSocket;
            this.server = server;
            mySqlConnection = ConnHelper.Connect();
        }

        /// <summary>
        /// 开始接收消息
        /// </summary>
        public void Start()
        {
            clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallBack,null);
        }
        /// <summary>
        /// 接收消息回调
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                int count = clientSocket.EndReceive(ar); //消息的字节数量
                if (count == 0)
                {
                    Close();
                }


                msg.ReadMessage(count,OnProcessMessage);  //获取客户端的消息之后。是否需要回复客户端请求

                //TODO 处理接收到的数据
                Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Close();
            }
        }

        /// <summary>
        /// 回复客户端请求
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="actionCode"></param>
        /// <param name="data"></param>
        private void OnProcessMessage(RequestCode requestCode,ActionCode actionCode,string data)
        {
            server.HandlerRequest(requestCode,actionCode,data,this);
        }

        private void Close()
        {
            ConnHelper.CloseConnection(mySqlConnection);
            if (clientSocket != null)
                clientSocket.Close();

            server.RemoveClient(this);
        }

        /// <summary>
        /// 向客户端发送数据
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="data"></param>
        public void Send(RequestCode requestCode, string data)
        {
            byte[] bytes = Message.PackData(requestCode, data);
            clientSocket.Send(bytes);
        }
    }
}

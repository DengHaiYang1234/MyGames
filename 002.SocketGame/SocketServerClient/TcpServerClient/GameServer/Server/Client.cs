using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace GameServer.Server
{
    /// <summary>
    /// 管理各个客户端对象
    /// </summary>
    class Client
    {
        private Socket clientSocket; //当前客户端
        private Server server; //服务器
        private Message msg = new Message(); //消息处理


        public Client()
        {
            
        }

        public Client(Socket clientSocket,Server server)
        {
            this.clientSocket = clientSocket;
            this.server = server;
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


                msg.ReadMessage(count);

                //TODO 处理接收到的数据
                Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Close();
            }
        }



        private void Close()
        {
            if (clientSocket != null)
                clientSocket.Close();

            server.RemoveClient(this);
        }
    }
}

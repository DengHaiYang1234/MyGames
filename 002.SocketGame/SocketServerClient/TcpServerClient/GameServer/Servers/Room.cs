using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace GameServer.Servers
{
    enum RoomState
    {
        WaitingJoin,
        WaitingBattle,
        Battle,
        End
    }

    /// <summary>
    /// 房间类
    /// </summary>
    class Room
    {
        //管理房间中的科幻段
        private List<Client> clientRoom = new List<Client>();
        //房间状态
        private RoomState roomState = RoomState.WaitingJoin;
        //服务器
        private Server server;

        /// <summary>
        /// 房间状态
        /// </summary>
        /// <returns></returns>
        public bool IsWaitingJoin()
        {
            return roomState == RoomState.WaitingJoin;
        }

        public Room(Server server)
        {
            this.server = server;
        }

        /// <summary>
        /// 添加客户端
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client)
        {
            clientRoom.Add(client);
            client.Room = this;
            if (clientRoom.Count >= 2)
            {
                roomState = RoomState.WaitingBattle;
            }
        }

        /// <summary>
        /// 删除房间中的客户端
        /// </summary>
        /// <param name="client"></param>
        public void RemoveClient(Client client)
        {
            client.Room = null;
            clientRoom.Remove(client);
            if (clientRoom.Count >= 2)
            {
                roomState = RoomState.WaitingBattle;
            }
            else
                roomState = RoomState.WaitingJoin;
        }

        /// <summary>
        /// 获取房主
        /// </summary>
        /// <returns></returns>
        public string GetHouseOwnerData()
        {
            return clientRoom[0].GetUserData();
        }

        /// <summary>
        /// 关闭房间
        /// </summary>
        /// <param name="clinet"></param>
        public void Close(Client clinet)
        {
            if (clinet == clientRoom[0])
            {
                server.RemoveRoom(this);
            }
            else
            {
                clientRoom.Remove(clinet);
            }
            
        }

        /// <summary>
        /// 获取房间ID
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            if (clientRoom.Count > 0)
            {
                return clientRoom[0].GetUserId();
            }
            return -1;
        }

        /// <summary>
        /// 获取房间信息
        /// </summary>
        /// <returns></returns>
        public string GetRoomData()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var client in clientRoom)
            {
                sb.Append(client.GetUserData() + "|");
            }

            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1,1);
            }
            return sb.ToString();
        }
        
        /// <summary>
        /// 广播房间信息
        /// </summary>
        /// <param name="excludeClient"></param>
        /// <param name="actionCode"></param>
        /// <param name="data"></param>
        public void BroadcastMessage(Client excludeClient,ActionCode actionCode,string data)
        {
            foreach (var client in clientRoom)
            {
                if (client != excludeClient)
                {
                    server.SendResponse(client, actionCode, data);
                }
            }
        }

        /// <summary>
        /// 是否是房主
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool IsHouseOwner(Client client)
        {
            return client == clientRoom[0];
        }

        /// <summary>
        /// 关闭房间
        /// </summary>
        public void Close()
        {
            foreach (Client client in clientRoom)
            {
                client.Room = null;
            }
            server.RemoveRoom(this);
        }
    }
}

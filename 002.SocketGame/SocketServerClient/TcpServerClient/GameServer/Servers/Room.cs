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

    class Room
    {
        private List<Client> clientRoom = new List<Client>();
        private RoomState roomState = RoomState.WaitingJoin;
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
        /// 当前房间人数
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

        public int GetId()
        {
            if (clientRoom.Count > 0)
            {
                return clientRoom[0].GetUserId();
            }
            return -1;
        }

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
    }
}

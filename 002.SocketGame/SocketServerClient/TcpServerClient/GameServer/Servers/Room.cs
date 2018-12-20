using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

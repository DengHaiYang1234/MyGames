using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer.Servers;

namespace GameServer.Controller
{
    class RoomController : BaseController
    {
        public RoomController()
        {
            requestCode = RequestCode.Room;
        }

        /// <summary>
        /// 获取客户端请求.创建房间
        /// </summary>
        /// <param name="data">  </param>
        /// <param name="client"> 客户端 </param>
        /// <param name="server">  </param>
        /// <returns></returns>
        public string CreatRoom(string data, Client client, Server server)
        {
            server.CreatRoom(client);
            return ((int)ReturnCode.Success).ToString();
        }

        /// <summary>
        /// 获取房间列表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="client"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public string ListRoom(string data, Client client, Server server)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Room room in server.GetRoomList())
            {
                if (room.IsWaitingJoin())
                {
                    sb.Append(room.GetHouseOwnerData() + "|");
                }
            }

            if (sb.Length == 0)
            {
                sb.Append("0");
            }
            else
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }
    }
}

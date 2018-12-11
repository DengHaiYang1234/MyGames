using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer.Servers;
using GameServer.DAO;
using GameServer.Model;
using Common;


namespace GameServer.Controller
{
    class UserController : BaseController
    {
        private UserDAO userDAO = new UserDAO();

        public UserController()
        {
            requestCode = RequestCode.User;
        }

        /// <summary>
        /// 注：  该方法是由反射调用 ControllerManager---->HandleRequest
        /// </summary>
        /// <param name="data"></param>
        /// <param name="client"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public string Login(string data, Client client, Server server)
        {
            string[] strs = data.Split(',');
            User user =  userDAO.VerifyUser(client.MySqlConnection,strs[0], strs[1]);
            if (user == null)
            {
                return ((int) ReturnCode.Fail).ToString();
            }
            else
            {
                return ((int) ReturnCode.Success).ToString();
            }
        }

        /// <summary>
        /// 注：  该方法是由反射调用 ControllerManager---->HandleRequest
        /// </summary>
        /// <param name="data"></param>
        /// <param name="client"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public string Register(string data, Client client, Server server)
        {
            string[] strs = data.Split(',');
            string userName = strs[0];
            string password = strs[1];
            bool isHasUser = userDAO.CheckHasUserByUserName(client.MySqlConnection, userName);
            if (isHasUser)
            {
                return ((int) ReturnCode.Fail).ToString();
            }
            userDAO.AddUser(client.MySqlConnection, userName, password);
            return ((int)ReturnCode.Success).ToString();
        }
    }
}

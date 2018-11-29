using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace GameServer.Controller
{
    /// <summary>
    /// 控制层   主要控制与数据库的数据交互?
    /// </summary>
    class ControllerManager
    {
        private Dictionary<RequestCode, BaseController> controllerDic = new Dictionary<RequestCode, BaseController>();


        public ControllerManager()
        {
            Init();
        }


        void Init()
        {
            
        }
    }
}

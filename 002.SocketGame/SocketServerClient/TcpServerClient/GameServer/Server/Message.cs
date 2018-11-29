using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Server
{
    /// <summary>
    /// 消息处理
    /// </summary>
    class Message
    {

        private int startIndex = 0;
        private byte[] data = new byte[1024];


        public byte[] Data
        {
            get { return data; }
        }

        public int StartIndex
        {
            get { return startIndex; }
        }

        public int RemainSize
        {
            get { return data.Length - startIndex; }
        }

        public void AddCount(int count)
        {
            //目前消息接收开始位置
            startIndex += count; 
        }

        /// <summary>
        /// 读取接收的消息。并做粘包处理
        /// </summary>
        /// <param name="newDataAmount"></param>
        public void ReadMessage(int newDataAmount)
        {
            startIndex += newDataAmount;
            while (true)
            {
                if (startIndex <= 4) return; //消息长度都未解析出来

                //获得消息的长度
                int count = BitConverter.ToInt32(data, 0); //从0开始解析4个字节.这是因为ToInt32默认是4个字节

                if ((startIndex - 4) >= count)
                {
                    string s = Encoding.UTF8.GetString(data, 4, count); //从第四个字节开始解析count长度的数据

                    Array.Copy(data, count + 4, data, 0, startIndex - (4 + count));

                    startIndex -= (count + 4);
                }
                else
                    return;

            }
        }
    }
}

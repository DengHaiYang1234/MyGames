using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using GameServer.Model;

namespace GameServer.DAO
{
    class UserDAO
    {
        public User VerifyUser(MySqlConnection conn,string userName,string passWord)
        {
            MySqlDataReader reader = null;
            try
            {
                MySqlCommand cmd =
                    new MySqlCommand("select * from user from where username = @username and password = @password", conn);
                cmd.Parameters.AddWithValue("username", userName);
                cmd.Parameters.AddWithValue("password", passWord);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    User user = new User(id, userName, passWord);
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("在VerifyUser时出现异常:" + e);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return null;
        }
    }
}

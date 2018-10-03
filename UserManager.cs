using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whos_that
{
    public class UserManager
    {
        public static List<User> onlineUserList = new List<User>();

        public static string[] ListOnlineUsers()
        {
            string[] usrListString = new string[onlineUserList.Count];
            int i = 0;

            using (IEnumerator<User> usrEnumerator = onlineUserList.GetEnumerator())
            {
                while (usrEnumerator.MoveNext())
                {
                    User usr = usrEnumerator.Current;
                    usrListString[i] = usr.username;
                }
            }
            return usrListString;
        }


        public User GetUserByUsername(string username) {
            User usr = new User("test","test", "test");

            return usr;
        }
    }
}

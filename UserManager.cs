using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whos_that
{
    public static class UserManager
    {
        public static List<User> userList = new List<User>();

        public static string[] ListUsers() {
            string[] usrListString = new string[userList.Count];
            int i = 0;
            /*
            foreach (User usr in userList) {
                usrListString[i] = String.Concat(usr.username, " ");
            }
            */

            //OR using IEnumerator:
            using (IEnumerator<User> usrEnumerator = userList.GetEnumerator()) {
                while (usrEnumerator.MoveNext()) {
                    User usr = usrEnumerator.Current;
                    usrListString[i] = usr.username;
                }
            }
            return usrListString;
        }
    }
}

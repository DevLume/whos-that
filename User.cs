using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whos_that
{
    public class User 
    {
        public String username;
        public String gender;

        private List<User> receivedFriendRequests;
        private List<User> sentFriendRequests;
        private List<User> friends;

        private String passwordHash;
        private String email;   

        public User(String username, String passHash, String email)
        {
            this.username = username;
            passwordHash = passHash;
            this.email = email;
        }

        public void SendFriendRequest(string username) {
            /*usr.receivedFriendRequests.Add(this);
            sentFriendRequests.Add(usr);*/
        }

        public void ListReceivedFriendRequests() {
            using (IEnumerator<User> usrEnumerator = receivedFriendRequests.GetEnumerator())
            {
                while (usrEnumerator.MoveNext()) {
                    User usr = usrEnumerator.Current;
                    Console.WriteLine(usr.username);
                }
            }
        }
    }
}

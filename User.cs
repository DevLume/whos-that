using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whos_that
{
    public class User : IEquatable<User>
    {
        public string username { get; set; }
        public string gender { get; set; }

        private List<User> receivedFriendRequests;
        private List<User> sentFriendRequests;
        private List<User> friends;

        private string passwordHash;
        private string email;   

        public User(string username, string passHash, string email)
        {
            this.username = username;
            passwordHash = passHash;
            this.email = email;
            receivedFriendRequests = new List<User>();
            sentFriendRequests = new List<User>();
            friends = new List<User>();
        }

        public void SendFriendRequest(User usr) {      
            if (usr != null)
            {
                usr.receivedFriendRequests.Add(this);
                sentFriendRequests.Add(usr);
            }     
        }

        public bool ReceiveRequest(User usr, bool approval) {          
            if (approval)
            {
                using (IEnumerator<User> usrEnumerator = receivedFriendRequests.GetEnumerator())
                {
                    while (usrEnumerator.MoveNext())
                    {
                        User temp = usrEnumerator.Current;
                        if (usr.Equals(temp)) {
                            receivedFriendRequests.Remove(temp);
                            usr.sentFriendRequests.Remove(this);
                            friends.Add(usr);
                            usr.friends.Add(this);
                            break;
                        }
                        //Console.WriteLine(usr.username);
                    }
                }
            }
            else {
            }
            return false;
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

        public void ListSentFriendRequests()
        {
            using (IEnumerator<User> usrEnumerator = sentFriendRequests.GetEnumerator())
            {
                while (usrEnumerator.MoveNext())
                {
                    User usr = usrEnumerator.Current;
                    Console.WriteLine(usr.username);
                }
            }
        }

        public void ListAllFriends() {
            using (IEnumerator<User> usrEnumerator = friends.GetEnumerator())
            {
                while (usrEnumerator.MoveNext())
                {
                    User usr = usrEnumerator.Current;
                    Console.WriteLine(usr.username);
                }
            }
        }

        public bool Equals(User other)
        {
            if (other == null) return false;

            return String.Equals(username, other.username) &&
                String.Equals(email, other.email) &&
                String.Equals(gender, other.gender) &&
                String.Equals(passwordHash, other.passwordHash);
            //throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals(obj as User);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}


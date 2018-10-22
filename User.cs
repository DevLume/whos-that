using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whos_that
{
    public class User : IEquatable<User>, IFriendManager
    {
        public int id;
        public string username;
        public string gender;
        private List<User> receivedFriendRequests;
        private List<User> sentFriendRequests;
        private List<User> friends;

        public string passwordHash;
        public string email;

        public User() { }
        public User(int id, string username, string email, string passhash, string gender) {
            this.id = id;
            this.username = username;
            this.email = email;
            this.gender = gender;
            passwordHash = passhash;
        }
        public User(string username, string email, string passhash, string gender)
        {
            this.username = username;
            this.email = email;
            this.gender = gender;
            passwordHash = passhash;
        }

        public User(string username, string passHash, string email)
        {
            this.username = username;
            passwordHash = passHash;
            this.email = email;

            /*receivedFriendRequests = new List<User>();
            sentFriendRequests = new List<User>();
            friends = new List<User>();*/
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

        public UserData ConvertToUserData() {
            return new UserData(0, username, email, passwordHash, "unspecified", false);
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

        //FriendManagement

        public List<User> ListFriends()
        {
            List<User> result = new List<User>();
            DataBaseManager dataMan = new DataBaseManager();
            UserManager userMan = new UserManager();
            List<UserRelData> rel = dataMan.GetUserRelDataDB(id);

            foreach (UserRelData dat in rel) {
                if (dat.approved)
                {
                    int tempID = dat.user2ID;
                    result.Add(userMan.GetUser(tempID));
                }
            }
            return result;
        }

        public List<User> ListFriendRequests()
        {
            List<User> result = new List<User>();
            DataBaseManager dataMan = new DataBaseManager();
            UserManager userMan = new UserManager();
            List<UserRelData> rel = dataMan.GetUserRelDataDB(id);

            foreach (UserRelData dat in rel)
            {
                if (dat.received)
                {
                    int tempID = dat.user2ID;
                    result.Add(userMan.GetUser(tempID));
                }
            }
            return result;
        }

        public bool AnswerFriendRq(int usrID, bool response)
        {            
            DataBaseManager dataMan = new DataBaseManager();          
            var dataSpace = new dataLinqDataContext();
            var usrTable = dataSpace.GetTable<usersRelTable>();

            var s = from a in usrTable where a.user1ID == usrID && a.user2ID == id select a;
            foreach (var i in s) {
                if (!(bool)i.received) {
                    Console.WriteLine("Such relationship already exists");
                    return false;
                }
            }

            if (!response)
            {
                List<UserRelData> reldat = new List<UserRelData>();
                var q = from a in usrTable where a.user2ID == usrID && a.user1ID == id select a;
                foreach (var i in q)
                {
                    reldat.Add(new UserRelData(i.Id, (int)i.user1ID, (int)i.user2ID, (bool)i.approved, DateTime.Today, (bool)i.received));
                }

                dataMan.RemoveUserRelDataDB(reldat);
            }
            else {
                var q = from a in usrTable where a.user2ID == usrID && a.user1ID == id select a;
                List<UserRelData> reldat = new List<UserRelData>();
                foreach (var i in q) {
                    i.approved = true;
                    i.received = false;
                    i.since = DateTime.Today;
                    reldat.Add(new UserRelData(i.Id, usrID, id, true, DateTime.Today, false));
                    dataMan.InsertUserRelDataDB(reldat);
                }
                try
                {
                    dataSpace.SubmitChanges();
                }
                catch (Exception e) {             
                    Console.WriteLine(e);
                    return false;
                }               
            }
            return true;
        }

        public bool SendFriendRq(int usrID)
        {
            if (usrID == id) {
                Console.WriteLine("friend request inception");
                return false;
            }
            DataBaseManager dataMan = new DataBaseManager();
            List<UserRelData> temp = dataMan.GetUserRelDataDB(usrID);

            foreach (UserRelData tmp in temp) {
                if (tmp.user1ID == usrID && tmp.user2ID == id) {
                    Console.WriteLine("Such relationship already exists");
                    return false;
                }
                else if (tmp.user2ID == usrID && tmp.user1ID == id)
                {
                    Console.WriteLine("Such relationship already exists");
                    return false;
                }
            }

            List<UserRelData> reldat = new List<UserRelData>();
            reldat.Add(new UserRelData(0, usrID, id, false, DateTime.Today, true));

            dataMan.InsertUserRelDataDB(reldat);
            return true;
        }
    }
}

public struct UserData
{
    public int id;
    public string name;
    public string email;
    public string passHash;
    public string gender;
    public bool online;

    public UserData(string name, string email, string passHash, string gender, bool online) : this()
    {
        this.name = name;
        this.email = email;
        this.passHash = passHash;
        this.gender = gender;
        this.online = online;
    }

    public UserData(int id, string name, string email, string passHash, string gender, bool online)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.passHash = passHash;
        this.gender = gender;
        this.online = online;
    }
    public override string ToString()
    {
        return String.Concat(id,"|",name,"|",email,"|",passHash, "|",gender, "|",online);
    }
}

public struct UserRelData {
    public int id;
    public int user1ID;
    public int user2ID;
    public bool approved;
    public System.DateTime date;
    public bool received;

    public UserRelData(int id, int id1, int id2, bool appr, DateTime date, bool received)
    {
        this.id = id;
        user1ID = id1;
        user2ID = id2;
        approved = appr;
        this.date = date;
        this.received = received;
    }

    public override string ToString()
    {
        return String.Concat(id, "|", user1ID, "|", user2ID, "|", approved, "|", date, "|", received);
    }
}
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
        private IDataManager dataman;
        
        public string passwordHash;
        public string email;
        private bool v;

        User() :this(DataManager.GetDataManager()){}
        User(IDataManager dataman)
        {
            this.dataman = dataman;
        }
        public User(int id, string username, string email, string passhash, string gender) : this(){
            
            this.id = id;
            this.username = username;
            this.email = email;
            this.gender = gender;
            passwordHash = passhash;
        }
        public User(string username, string email, string passhash, string gender) : this()
        {            
            this.username = username;
            this.email = email;
            this.gender = gender;
            passwordHash = passhash;
        }

        public User(string username, string passHash, string email) : this()
        {        
            this.username = username;
            passwordHash = passHash;
            this.email = email;

            /*receivedFriendRequests = new List<User>();
            sentFriendRequests = new List<User>();
            friends = new List<User>();*/
        }

        public User(int id, string username, string email, string passhash, string gender, bool v) : this(id, username, email, passhash, gender)
        {
            this.v = v;
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

        public void Unfriend(User u)
        {
            UnfriendDB(u);
            u.UnfriendDB(this);
        }

        private void UnfriendDB(User u)
        {
            int usrID = u.id;
            List<UserRelData> rel = dataman.GetUserRelData(id);
            List<UserRelData> unfriendRel = new List<UserRelData>();

            foreach (UserRelData r in rel)
            {               
                if ((r.user1ID == id) && (r.user2ID == usrID))
                {
                    unfriendRel.Add(r);
                }       
            }
            dataman.RemoveUserRelData(unfriendRel);        
        }
        public List<User> ListFriends()
        {
            List<User> result = new List<User>();
            UserManager userMan = new UserManager();
            List<UserRelData> rel = dataman.GetUserRelData(id);

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
            UserManager userMan = new UserManager();
            List<UserRelData> rel = dataman.GetUserRelData(id);

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
            if (dataman.CreateRelationship(id, usrID, response))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SendFriendRq(int usrID)
        {
            if (usrID == id) {
                Console.WriteLine("friend request inception");
                return false;
            }
            List<UserRelData> temp = dataman.GetUserRelData(usrID);

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
            DateTime date = DateTime.Today;
            UserRelData udat = new UserRelData(0, usrID, id, false, DateTime.Today, true);
            Console.WriteLine("sent rq date {0}", udat.date);
            reldat.Add(udat);

            dataman.InsertUserRelData(reldat);
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
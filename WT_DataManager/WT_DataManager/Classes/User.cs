using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    public class User : IEquatable<User>, IFriendManager
    {
        public int id;
        public string username;
        public string gender;
        private IDataManager dataman;

        public byte[] userpic;

        public string passwordHash;
        public string email;
        private bool v;

        public bool messageReceived { get; set; }
        private event MessageEventHandler messagingEvent;
        User() :this(DataManager.GetDataManager()){}
        User(IDataManager dataman)
        {
            this.dataman = dataman;
        }

        public User(int id, string username, string email, string passhash, string gender, byte[] userpic) : this()
        {

            this.id = id;
            this.username = username;
            this.email = email;
            this.gender = gender;
            this.userpic = userpic;
            passwordHash = passhash;
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
            return new UserData(0, username, email, passwordHash, "unspecified",null, false);
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

        public Tuple<bool, string> SendFriendRq(User u)
        {
            int usrID = u.id;
            if (usrID == id) {
                Console.WriteLine("friend request inception");
                return new Tuple<bool, string>(false, "friend request inception");
            }
            List<UserRelData> temp = dataman.GetUserRelData(usrID);

            foreach (UserRelData tmp in temp) {
                if (tmp.user1ID == usrID && tmp.user2ID == id) {
                    Console.WriteLine("Such relationship already exists");
                    return new Tuple<bool, string>(false, "Such relationship already exists");
                }
                else if (tmp.user2ID == usrID && tmp.user1ID == id)
                {
                    Console.WriteLine("Such relationship already exists");
                    return new Tuple<bool, string>(false, "Such relationship already exists!");
                }
            }

            List<UserRelData> reldat = new List<UserRelData>();
            DateTime date = DateTime.Today;
            UserRelData udat = new UserRelData(0, usrID, id, false, DateTime.Today, true);          
            reldat.Add(udat);

            dataman.InsertUserRelData(reldat);
            return new Tuple<bool, string>(true, "A relationship has been created succesfully!");
        }

        public bool SendMessage(User friend, string message)
        {
            List<UserRelData> relationships = dataman.GetUserRelData(this.id);
            SecurityManager secman = new SecurityManager();
            bool sent = false;
            string firstWord = message.Split(' ')[0];
            foreach (UserRelData u in relationships)
            {
                if (friend.id == u.user2ID)
                {
                    sent = dataman.InsertMessage(this.id, friend.id, string.Concat(firstWord," ", secman.HashString(message,firstWord)));
                    break;
                }
            }
            if (!sent)
            {
                Console.WriteLine("Message could not be sent, " +
                    "either you are not a friend to the recipient, or there is no such user");
                return false;
            }
            else
            {
                messagingEvent += EventManager.MessageSent;
                messagingEvent(friend);
                Console.WriteLine("Message has been sent succesfully");
                return true;
            }
        }

        public List<string> GetMessageData()
        {
            List<string> result = new List<string>();
            UserManager userMan = new UserManager();
            SecurityManager secman = new SecurityManager();
            List<UserRelData> rel = dataman.GetUserRelData(id);
            string temp;
            string ciph;
            foreach (UserRelData dat in rel)
            {
                if (dat.message != null)
                {
                    try
                    {
                        temp = dat.message.Split(' ')[0];
                        ciph = dat.message.Split(' ')[1];
                        result.Add(string.Concat(dat.user2ID.ToString()," ",secman.DehashString(ciph, temp)));
                        MarkMessageAsRead(dat.user2ID);
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine("something bad occured with messaging, ", ex);
                    }
                }
            }
            return result;
        }

        public List<string> ListMessages()
        {
            List<string> result = new List<string>();
            List<string> mesgData = GetMessageData();
            UserManager userman = new UserManager();
            foreach (string s in mesgData)
            {
                int uid = Int32.Parse(s.Split(' ')[0]);
                string resMesg = string.Concat(userman.GetUser(uid).username, ": ");
                IEnumerable<string> mesg = s.Split(' ').Skip(1);              
                StringBuilder sb = new StringBuilder();
                sb.Append(resMesg);
                foreach (string m in mesg)
                {
                    sb.Append(m);
                    sb.Append(' ');
                }
                resMesg = sb.ToString();
                result.Add(resMesg);
            }
            return result;
        }

        public bool MarkMessageAsRead(int senderID)
        {
            bool marked = false;
            try
            {
                marked = dataman.InsertMessage(senderID, this.id, null);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("something bad occured with messaging, ", ex);
            }
            return marked;
        }

        public bool ChangeProfilePic(byte[] userpic)
        {
            UserData udata = dataman.GetUserData(username);
            udata.userpic = userpic;

            dataman.ModifyUser(id, udata);

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
    public byte[] userpic;
    public bool online;

    public UserData(string name, string email, string passHash, string gender, bool online) : this()
    {
        this.name = name;
        this.email = email;
        this.passHash = passHash;
        this.gender = gender;
        this.online = online;
    }

    public UserData(int id, string name, string email, string passHash, string gender, byte[] userpic, bool online)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.passHash = passHash;
        this.gender = gender;
        this.online = online;
        this.userpic = userpic;
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
    public string message;

    public UserRelData(int id, int id1, int id2, bool appr, DateTime date, bool received) : this()
    {
        this.id = id;
        user1ID = id1;
        user2ID = id2;
        approved = appr;
        this.date = date;
        this.received = received;
    }

    public UserRelData(int id, int id1, int id2, bool appr, DateTime date, bool received, string message)
    {
        this.id = id;
        user1ID = id1;
        user2ID = id2;
        approved = appr;
        this.date = date;
        this.received = received;
        this.message = message;
    }

    public override string ToString()
    {
        return String.Concat(id, "|", user1ID, "|", user2ID, "|", approved, "|", date, "|", received);
    }
}
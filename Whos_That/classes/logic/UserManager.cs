using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whos_that
{
    public class UserManager : IUserManager
    {
        private IDataBaseManager dataman;
        public UserManager() : this(new TestDataBaseManager()) { }
        private UserManager(IDataBaseManager dataman)
        {
            this.dataman = dataman;
        }

        public User GetUser(int id)
        {    
            UserData userdat = dataman.GetUserDataDB(id);

            return new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender);
        }

        public User GetUser(string username)
        {
            UserData userdat = dataman.GetUserDataDB(username);

            return new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender);
        }
        public bool checkIfUserExists(string username)
        {
            UserData userdat = dataman.GetUserDataDB(username);
            if (userdat.name == username) return true;
            else return false;
        }

        public List<User> ListUsers()
        { 
            return dataman.GetAllUserDataDB();          
        }

        public List<User> ListOnlineUsers()
        {           
            return dataman.GetAllOnlineUserDataDB();
        }

        public bool NewUser(User usr)
        {
            User temp = GetUser(usr.username);
            if (temp.id == 0)
            {
                Console.WriteLine("Inserting new user " + usr.username);
                List<UserData> udata = new List<UserData>();
                udata.Add(usr.ConvertToUserData());
                dataman.InsertUserDataDB(udata);
                return true;
            }
            else return false;
        }

        public bool RemoveUser(string username) // pass username in order to check if such user exists
        {
            UserData userdat = dataman.GetUserDataDB(username);
            if (userdat.id == 0)
            {
                return false;
            }
            else
            {
                List<UserData> dataToDelete = new List<UserData>();
                dataToDelete.Add(userdat);
                dataman.RemoveUserDataDB(dataToDelete);
                return true;
            }
        }
    }
}
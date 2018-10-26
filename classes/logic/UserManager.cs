using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whos_that
{
    public class UserManager : IUserManager
    {
        private IDataBaseManager dataman;
        public UserManager()
        {
            dataman = new DataBaseManager();
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
            List<User> result = new List<User>();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table 
            var usrTable = dataSpace.GetTable<usersTable>();
            //query and parse here:
            var q = from a in usrTable select a;

            foreach (var i in q)
            {
                result.Add(new User(i.Id, i.Name, i.Email, i.PassHash, i.Gender));
            }

            return result;
        }

        public List<User> ListOnlineUsers()
        {
            List<User> result = new List<User>();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table 
            var usrTable = dataSpace.GetTable<usersTable>();
            //query and parse here:
            var q = from a in usrTable where a.Online == true select a;

            foreach (var i in q)
            {
                result.Add(new User(i.Id, i.Name, i.Email, i.PassHash, i.Gender));
            }

            return result;
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
    }
}
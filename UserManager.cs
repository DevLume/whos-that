using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whos_that
{
    public class UserManager : IUserManager
    {
        public User GetUser(int id)
        {
            DataBaseManager dataMan = new DataBaseManager();
            UserData userdat = dataMan.GetUserDataDB(id);
           
            return new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender);                    
        }

        public User GetUser(string username)
        {
            DataBaseManager dataMan = new DataBaseManager();
            UserData userdat = dataMan.GetUserDataDB(username);

            return new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender);
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

            foreach (var i in q) {
                result.Add(new User(i.Id, i.Name, i.Email, i.PassHash,i.Gender));
            }

            return result;
        }

        public bool NewUser(User usr) {
            DataBaseManager dataMan = new DataBaseManager();
            User temp = GetUser(usr.username);
            if (temp.id == 0)
            {
                Console.WriteLine("Inserting new user " + usr.username);
                List<UserData> udata = new List<UserData>();
                udata.Add(usr.ConvertToUserData());
                dataMan.InsertUserDataDB(udata);
                return true;
            }
            else return false;
        }
    }
}

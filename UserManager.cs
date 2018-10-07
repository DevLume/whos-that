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
            DataManager dataMan = new DataManager();
            List<UserData> usr = dataMan.GetUserDataDB(id);
            foreach (UserData userdat in usr)
            {
                return new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender);
            }
            return null;
        }

        public User GetUser(string username)
        {
            DataManager dataMan = new DataManager();
            List<UserData> usr = dataMan.GetUserDataDB(username);
            foreach (UserData userdat in usr)
            {
                return new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender);
            }
            return null;
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
    }
}

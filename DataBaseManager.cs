using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    class DataBaseManager : IDataBaseManager
    {
        //Database methods here:
        //TODO:Add exception handling
        public UserData GetUserDataDB(string username)
        {
            UserData result = new UserData();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersTable>();
            //query and parsing here:

            var q = from a in usrTable where a.Name == username select a;
            foreach (var i in q)
            {
                result = new UserData(i.Id, i.Name, i.Email, i.PassHash, i.Gender, false);               
            }
            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public UserData GetUserDataDB(int id)
        {
            UserData result = new UserData();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersTable>();
            //query and parsing here:

            var q = from a in usrTable where a.Id == id select a;
            foreach (var i in q)
            {
                result = new UserData(i.Id, i.Name, i.Email, i.PassHash, i.Gender, (bool)i.Online);
            }

            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public UserData GetUserDataByEmail(string email)
        {
            UserData result = new UserData();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersTable>();
            //query and parsing here:

            var q = from a in usrTable where a.Email == email select a;
            foreach (var i in q)
            {
                result = new UserData(i.Id, i.Name, i.Email, i.PassHash, i.Gender, (bool)i.Online);
            }

            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public List<UserRelData> GetUserRelDataDB(string username)
        {
            /*List<UserData> result = new List<UserData>();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersRelTable>();
            //query and parsing here:

            var q = from a in usrTable where a.Name == id select a;
            foreach (var i in q)
            {
                result.Add(new UserData(i.Id, i.Name, i.Email, i.PassHash, i.Gender, (bool)i.Online));
            }

            //Close data context
            dataSpace.Dispose();
            return result;*/
            throw new NotImplementedException();
        }

        public List<UserRelData> GetUserRelDataDB(int id)
        {
            List<UserRelData> result = new List<UserRelData>();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersRelTable>();
            //query and parsing here:

            var q = from a in usrTable where a.user1ID == id select a;
            foreach (var i in q)
            {
                result.Add(new UserRelData(i.Id, (int)i.user1ID, (int)i.user2ID, (bool)i.approved, (DateTime)i.since, (bool)i.received));
            }

            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public void InsertUserDataDB(List<UserData> data)
        {
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersTable>();
            usersTable tbl;
            bool online = false;

            //query and parsing here:
            foreach (UserData userdat in data)
            {                
                tbl = new usersTable(userdat.name,
                    userdat.email, userdat.passHash, userdat.gender, online);
                dataSpace.usersTables.InsertOnSubmit(tbl);
            }

            try
            {
                dataSpace.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //Close data context
            dataSpace.Dispose();
            // throw new NotImplementedException();
        }

        public void InsertUserRelDataDB(List<UserRelData> data)
        {
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersRelTable>();
            usersRelTable tbl;
            //query and parsing here:
            foreach (UserRelData userdat in data)
            {
                Console.WriteLine(userdat.date);
                tbl = new usersRelTable(userdat.user1ID,
                    userdat.user2ID, userdat.approved, userdat.date, userdat.received);
                dataSpace.usersRelTables.InsertOnSubmit(tbl);
            }

            try
            {
                dataSpace.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //Close data context
            dataSpace.Dispose();
        }

        public void RemoveUserDataDB(List<UserData> data)
        {
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersTable>();
            //query and parsing here:

            foreach (UserData userdat in data)
            {
                var q = from a in usrTable where a.Id == userdat.id select a;
                foreach (var i in q)
                {
                    usrTable.DeleteOnSubmit(i);
                }
            }

            try
            {
                dataSpace.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //Close data context
            dataSpace.Dispose();
        }

        public void RemoveUserRelDataDB(List<UserRelData> data)
        {
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersRelTable>();
            //query and parsing here:
            foreach (UserRelData userdat in data)
            {                
                var q = from a in usrTable where a.Id == userdat.id select a;
                foreach (var i in q)
                {
                    usrTable.DeleteOnSubmit(i);
                }
            }

            try
            {
                dataSpace.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //Close data context
            dataSpace.Dispose();
        }
    }
}

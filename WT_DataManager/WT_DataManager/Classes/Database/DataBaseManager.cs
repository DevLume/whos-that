﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT_DataManager.Classes;
using WT_DataManager.Models;

namespace Whos_that
{
    public class DataBaseManager : IDataManager
    {
        //Database methods here:               
        public UserData GetUserData(string username)
        {
            UserData result = new UserData();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersTable>();
            //query and parsing here:

            byte[] pic = new byte[1];
            pic[0] = 1;

            var q = from a in usrTable where a.Name == username select a;
            foreach (var i in q)
            {
                result = new UserData(i.Id, i.Name, i.Email, i.PassHash, i.Gender, i.Userpic.ToArray(), (bool)i.Online, i.Description);
            }
            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public UserData GetUserData(int id)
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
                result = new UserData(i.Id, i.Name, i.Email, i.PassHash, i.Gender, i.Userpic.ToArray(), (bool)i.Online, i.Description);
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
                result = new UserData(i.Id, i.Name, i.Email, i.PassHash, i.Gender, i.Userpic.ToArray(), (bool)i.Online, i.Description);
            }

            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public List<UserRelData> GetUserRelData(string username)
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

        public List<UserRelData> GetUserRelData(int id)
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
                result.Add(new UserRelData(i.Id, (int)i.user1ID, (int)i.user2ID, (bool)i.approved, (DateTime)i.since, (bool)i.received, i.message));
            }

            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public void InsertUserData(List<UserData> data)
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
                    userdat.email, userdat.passHash, userdat.gender, userdat.userpic, online, userdat.description);
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

        public void InsertUserRelData(List<UserRelData> data)
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

                tbl.since = userdat.date;
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

        public void RemoveUserData(List<UserData> data)
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

        public void RemoveUserRelData(List<UserRelData> data)
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

        public List<User> GetAllOnlineUserData()
        {
            List<User> result = new List<User>();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersTable>();
            //query and parsing here:

            var q = from a in usrTable where a.Online == true select a;
            foreach (var i in q)
            {
                result.Add(new User(i.Id, i.Name, i.Email, i.PassHash, i.Gender, true));
            }
            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public List<User> GetAllUserData()
        {
            List<User> result = new List<User>();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersTable>();
            //query and parsing here:

            var q = from a in usrTable select a;
            foreach (var i in q)
            {
                result.Add(new User(i.Id, i.Name, i.Email, i.PassHash, i.Gender, true));
            }
            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public bool CreateRelationship(int uid1, int uid2, bool approved)
        {
            var dataSpace = new dataLinqDataContext();
            var usrTable = dataSpace.GetTable<usersRelTable>();

            var s = from a in usrTable where a.user1ID == uid2 && a.user2ID == uid1 select a;
            foreach (var i in s)
            {
                if (!(bool)i.received)
                {
                    Console.WriteLine("Such relationship already exists");
                    return false;
                }
            }
            List<UserRelData> userdat = GetUserRelData(uid1);
            foreach (var i in userdat)
            {
                if (!(bool)i.received && i.user1ID == uid2 && i.user2ID == uid1)
                {
                    Console.WriteLine("Such relationship already exists");
                    return false;
                }
            }
            if (!approved)
            {
                List<UserRelData> reldat = new List<UserRelData>();
                var q = from a in usrTable where a.user2ID == uid2 && a.user1ID == uid1 select a;
                foreach (var i in q)
                {
                    if (i.user2ID == uid2 && i.user1ID == uid1)
                    {
                        reldat.Add(new UserRelData(i.Id, (int)i.user1ID, (int)i.user2ID, (bool)i.approved, DateTime.Today, (bool)i.received));
                    }
                }

                RemoveUserRelData(reldat);
            }
            else
            {
                var q = from a in usrTable where a.user2ID == uid2 && a.user1ID == uid1 select a;
                List<UserRelData> reldat = new List<UserRelData>();
                foreach (var i in q)
                {
                    i.approved = true;
                    i.received = false;
                    i.since = DateTime.Today;
                    reldat.Add(new UserRelData(i.Id, uid2, uid1, true, (DateTime)i.since, false));
                    Console.WriteLine("Adding with since date {0}", i.since);
                    InsertUserRelData(reldat);
                }
                try
                {
                    dataSpace.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
            return true;
        }

        public bool InsertMessage(int uid1, int uid2, string message)
        {          
            if (!CreateRelationship(uid1, uid2, true))
            {
                var dataSpace = new dataLinqDataContext();
                var usrTable = dataSpace.GetTable<usersRelTable>();
              
                (from a in usrTable where a.user1ID == uid2 && a.user2ID == uid1 select a).ToList().ForEach(x => x.message = message);

                dataSpace.SubmitChanges();
                dataSpace.Dispose();
                return true;
            }
            return false;
        }


        public bool ModifyOnline(int usrID, bool isOnline)
        {        
            var dataSpace = new dataLinqDataContext();
            var usrTable = dataSpace.GetTable<usersTable>();

            (from a in usrTable where a.Id == usrID select a).ToList().ForEach(x => x.Online = isOnline);

            dataSpace.SubmitChanges();
            dataSpace.Dispose();
            return true;                     
        }

        public void ModifyUser(int usrID, UserData udata)
        {
            var dataSpace = new dataLinqDataContext();
            var usrTable = dataSpace.GetTable<usersTable>();

            var obj = usrTable.Single(x => x.Id == usrID);

            obj.Id = udata.id;
            obj.Name = udata.name;
            obj.Email = udata.email;
            obj.PassHash = udata.passHash;
            obj.Gender = udata.gender;
            obj.Userpic = udata.userpic;
            obj.Online = udata.online;
            obj.Description = udata.description;

            dataSpace.SubmitChanges();          
        }

        public bool ModifyUserProfile(int usrID, UserProfile profile)
        {
            var dataSpace = new dataLinqDataContext();
            var usrTable = dataSpace.GetTable<usersTable>();

            var obj = usrTable.Single(x => x.Id == usrID);

            if (profile.username != null)
            {
                obj.Name = profile.username;
            }

            if (profile.description != null && profile.description != "none")
            {
                obj.Description = profile.description;
            }

            if (profile.picBase64 != null && profile.picBase64 != "" && profile.picBase64 != "none")
            {
                obj.Userpic = Convert.FromBase64String(profile.picBase64);
            }
            dataSpace.SubmitChanges();

            return true;
        }
    }
}
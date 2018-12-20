using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WT_DataManager.Classes;

namespace Whos_that
{
    public class UserManager : IUserManager
    {       
        private IDataManager dataman;
        public UserManager() : this(DataManager.GetDataManager()) { }
        private UserManager(IDataManager dataman)
        {
            this.dataman = dataman;
        }

        public User GetUser(int id)
        {    
            UserData userdat = dataman.GetUserData(id);

            return new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender, userdat.userpic);
        }
        
        public User GetUserByEmail(string email)
        {
           // DataBaseManager dataMan = new TestDataBaseManager();
            UserData userdat = dataman.GetUserDataByEmail(email);

            return new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender, userdat.userpic);
        }

        public async Task<UserProfile> GetUserProfile(string username)
        {
            UserProfile uprofile = null;
            UserData userdat = dataman.GetUserData(username);
            User u = GetUser(username);

            HttpClient client = new HttpClient();

            List<string> testList;
            HttpResponseMessage response = await client.GetAsync("http://10.3.1.158:8086/api/userTest/List?author=" + username);

            try
            {
                response.EnsureSuccessStatusCode();

                using (HttpContent content = response.Content)
                {
                    string respBody = await response.Content.ReadAsStringAsync();

                    testList = JsonConvert.DeserializeObject<List<string>>(respBody);
                }
            }
            catch (Exception)
            {
                testList = new List<string>();
            }        

            uprofile = new UserProfile(Convert.ToBase64String(u.userpic), username, u.description, testList);

            return uprofile;
        }

        public bool SetUserProfile(UserProfile profile)
        {
            User u = GetUser(profile.username);         
            int id = u.id;

            return dataman.ModifyUserProfile(id, profile);
        }
        public User GetUser(string username)
        {
            UserData userdat = dataman.GetUserData(username);

            return new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender, userdat.userpic, userdat.description);
        }
        public bool checkIfUserExists(string username)
        {
            UserData userdat = dataman.GetUserData(username);
            if (userdat.name == username) return true;
            else return false;
        }

        public List<User> ListUsers()
        { 
            return dataman.GetAllUserData();          
        }

        public List<User> ListOnlineUsers()
        {           
            return dataman.GetAllOnlineUserData();
        }

        public bool NewUser(User usr)
        {
            User temp = GetUser(usr.username);
            if (temp.id == 0)
            {
                Console.WriteLine("Inserting new user " + usr.username);
                List<UserData> udata = new List<UserData>();
                udata.Add(usr.ConvertToUserData());
                dataman.InsertUserData(udata);
                return true;
            }
            else return false;
        }

        public bool RemoveUser(string username) // pass username in order to check if such user exists
        {
            UserData userdat = dataman.GetUserData(username);
            if (userdat.id == 0)
            {
                return false;
            }
            else
            {
                List<UserData> dataToDelete = new List<UserData>();
                dataToDelete.Add(userdat);
                dataman.RemoveUserData(dataToDelete);
                return true;
            }
        }

        public bool SignUser(int id, SigningEventHandler sg)
        {
            if (GetUser(id) == null)
            {
                return false;
            }
            else
            {
                dataman.ModifyOnline(id, true);
                return true;
            }
        }

        public bool UnsignUser(int id, SigningEventHandler sg)
        {
            if (this.GetUser(id) == null)
            {
                return false;
            }
            else
            {
                dataman.ModifyOnline(id, false);
                return true;
            }
        }
    }
}

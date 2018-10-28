using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    interface IDataManager : IDataBaseManager, IDataFileManager
    { }


    public interface IDataBaseManager
    {
        //methods for DB
        //TODO: User Data must be returned as User object
        UserData GetUserDataDB(string username);
        UserData GetUserDataDB(int id);
        UserData GetUserDataByEmail(string email);
        List<User> GetAllOnlineUserDataDB();
        List<User> GetAllUserDataDB();
        List<UserRelData> GetUserRelDataDB(string username);
        List<UserRelData> GetUserRelDataDB(int id);
        void InsertUserDataDB(List<UserData> data);
        void InsertUserRelDataDB(List<UserRelData> data);
        void RemoveUserDataDB(List<UserData> data);
        void RemoveUserRelDataDB(List<UserRelData> data);      
    }

    public interface IDataFileManager
    {
        //Change return values when not operating on strings only
        string[] GetDataLine(string username);
        string[] GetDataLine(string username, string email);
        bool InsertUniqueDataLine(string username, string email, string passwordHash);
    }
}

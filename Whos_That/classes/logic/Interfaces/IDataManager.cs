using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    public interface IDataManager
    {
        UserData GetUserData(string username);
        UserData GetUserData(int id);
        UserData GetUserDataByEmail(string email);
        List<User> GetAllOnlineUserData();
        List<User> GetAllUserData();
        List<UserRelData> GetUserRelData(string username);
        List<UserRelData> GetUserRelData(int id);
        void InsertUserData(List<UserData> data);
        void InsertUserRelData(List<UserRelData> data);
        void RemoveUserData(List<UserData> data);
        void RemoveUserRelData(List<UserRelData> data);
        bool CreateRelationship(int uid1, int uid2, bool approved);
    }


    public interface IDataBaseManager : IDataManager
    {  
    }

    public interface IDataFileManager : IDataManager 
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    interface IDataManager
    {
        //Change return values when not operating on strings only
        string[] GetDataLine(string username);
        string[] GetDataLine(string username, string email);
        bool InsertUniqueDataLine(string username, string email, string passwordHash);

        //methods for DB
        List<UserData> GetUserDataDB(string username);
        List<UserData> GetUserDataDB(int id);
        List<UserRelData> GetUserRelDataDB(string username);
        List<UserRelData> GetUserRelDataDB(int id);
        void InsertUserDataDB(List<UserData> data);
        void InsertUserRelDataDB(List<UserRelData> data);
    }
}

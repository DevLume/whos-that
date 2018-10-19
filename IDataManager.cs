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
    }
}

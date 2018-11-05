using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    interface IUserManager
    {
        List<User> ListOnlineUsers();
        User GetUser(int id);
        User GetUser(string username);
        bool NewUser(User usr);
        bool RemoveUser(string username);
        bool SignUser(int id, SigningEventHandler sg); // SigningEventHandler is useless
        bool UnsignUser(int id, SigningEventHandler sg); // SigningEventHandler is useless
    }
}

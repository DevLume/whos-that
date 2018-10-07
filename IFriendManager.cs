using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    interface IFriendManager
    {
        List<User> ListFriends();
        List<User> ListFriendRequests();
        void AnswerFriendRq(int usrID, bool response);
        void SendFriendRq(int usrID);
    }
}

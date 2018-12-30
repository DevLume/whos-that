using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public interface IFriendRqService
    {
        Task<bool> AddFriend(string sender, string receiver);
    }
}

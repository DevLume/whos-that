using Droid.Core.Services.Tools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Droid.Core.ViewModels
{
    public interface IFriendlistService
    {
        Task<Tuple<bool, List<Friend>>> GetFriendlist(string username);
    }
}
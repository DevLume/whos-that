using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public interface IRegisterService
    {
        Task<Tuple<bool, string>> SendRegisterRequest(string username, string password, string email);
    }
}

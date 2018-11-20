using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public interface ILoginService
    {
        Task<Tuple<bool, string>> SendLoginRequest(string username, string password);
    }
}

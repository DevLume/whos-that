using Droid.Core.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public interface ICreateTestService
    {
        Task<Tuple<bool, string>> SendCreateTestRequest(string title, string author, Test test);
    }
}

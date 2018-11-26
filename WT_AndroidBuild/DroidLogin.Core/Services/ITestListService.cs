using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public interface ITestListService
    {
        Task<Tuple<List<string>, string>> ListTests(string author);
    }
}

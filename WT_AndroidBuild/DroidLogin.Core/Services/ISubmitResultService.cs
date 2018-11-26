using Droid.Core.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public interface ISubmitResultService
    {
        Task<Tuple<bool, string>> SubmitResults(TestResult tr);
    }
}

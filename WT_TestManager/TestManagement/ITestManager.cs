using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WT_TestManager.TestManagement.Tools;

namespace WT_TestManager.TestManagement
{
    public interface ITestManager
    {
        Test CreateTest(string author, string title, List<Question> questions); 
        List<Question> GetTestData(string author, string title);
    }
}
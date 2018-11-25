///Test management interface

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WT_TestManager.TestManagement.Tools;

namespace WT_TestManager.TestManagement
{
    public interface ITestManager
    {
        Test CreateTest(string author, string title, List<Question> questions); //Create a test based on given author, title, 
                                                                                //questions and wrap it in a test class
        List<Question> GetTestData(string author, string title); //Get Questions from test if you need only them
    }
}
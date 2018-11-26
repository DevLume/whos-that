///Not implemented
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WT_TestManager.TestManagement.Tools;

namespace WT_TestManager.TestManagement
{
    public class TestResultManager
    {
        private IDirectoryManager dirman;
        private string rootPath { get; set; }

        public TestResultManager(IDirectoryManager dirman)
        {
            this.dirman = dirman;
            rootPath = dirman.rootPath;
        }
    }
}
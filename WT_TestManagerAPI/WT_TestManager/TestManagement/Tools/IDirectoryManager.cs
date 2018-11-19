using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WT_TestManager.TestManagement.Tools
{
    public interface IDirectoryManager
    {
        string rootPath { get; set; }
        bool CreateDirectory(string rootPath, string folderName); // if we want to create more than one folder, call this method recursively
        bool DeleteDirectory(string path);
        bool CreateFile(string path);
    }
}
///Directory Management interface meant to work 
///with file directories on server side

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WT_TestManager.TestManagement.Tools
{
    public interface IDirectoryManager
    {
        string rootPath { get; set; } // Main root directory of server
        bool CreateDirectory(string rootPath, string folderName); // Use this to create directory, 
                                                                  // provide rootPath or folder directory, and new folder name or directory
        bool DeleteDirectory(string path); // Delete a directory under given path
        bool CreateFile(string path); // Not implemented
    }
}
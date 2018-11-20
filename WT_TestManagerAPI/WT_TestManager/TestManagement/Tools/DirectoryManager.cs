using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WT_TestManager.TestManagement.Tools
{
    public class DirectoryManager : IDirectoryManager
    {
        public string rootPath { get; set; }
        public DirectoryManager()
        {
            rootPath = string.Concat(HttpContext.Current.Server.MapPath(@"\"), @"\users");
        }

        public bool CreateDirectory(string rootPath, string folderName)
        {
            if (!File.Exists(string.Concat(rootPath, @"\", folderName)))
            {
                Directory.CreateDirectory(string.Concat(rootPath, @"\", folderName));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateFile(string path)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDirectory(string path)
        {
            throw new NotImplementedException();
        }
    }
}
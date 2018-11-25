using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using WT_TestManager.TestManagement.Tools;

namespace WT_TestManager.TestManagement
{
    public class StatisticsManager
    {
        private IDirectoryManager dirman;
        private List<string> personalDataList;
        private List<string> otherDataList;

        private string rootPath { get; set; }
        public StatisticsManager(IDirectoryManager dir)
        {
            dirman = dir;
            rootPath = dir.rootPath;
        }

        private List<string> GetFileList(string path)
        {
            List<string> result = new List<string>();

            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] files = d.GetFiles("*.txt");

            foreach (FileInfo file in files)
            {
                string[] temp = file.Name.Split('.');

                result.Add(temp[0]);
            }
            return result;
        }

        private List<string> GetData(string folderType, string username)
        {             
            StreamReader fileRead;
            List<string> result = new List<string>();
            List<string> fileList = new List<string>();
            
            string path = string.Concat(rootPath, @"\", username, @"\", folderType);
            fileList = GetFileList(path);

            foreach (string s in fileList)
            {
                string newPath = path + @"\" + s + ".txt";

                try
                {
                    fileRead = new System.IO.StreamReader(newPath);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("There was a problem with a file ", ex);
                    return null;
                }
                string line;
                while ((line = fileRead.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }
            return result;
        }
        public Stat GetStat(string username)
        {
            try
            {
                personalDataList = GetData("personalResults", username);
            }
            catch (DirectoryNotFoundException)
            {
                personalDataList = new List<string>();
            }

            try
            {
                otherDataList = GetData("otherResults", username);
            }
            catch (DirectoryNotFoundException)
            {
                otherDataList = new List<string>();
            }

            return new Stat(CountPersonalGuesses(username), CountOtherGuesses(username), 
                CountPersonalResultAverage(username), 
                CountOtherResultAverage(username), GetBestGuesser(username), 
                GetOtherHighestResult(username), GetPersonalHighestResult(username));
        }

        public int CountPersonalGuesses(string username)
        {
            return personalDataList.Count();
        }

        public double CountPersonalResultAverage(string username)
        {
            double res = 0;
            double t = 0;
            foreach (string s in personalDataList)
            {
                string[] temp = s.Split(' ');
                string[] temp1 = temp[2].Split('/');
                double x = double.Parse(temp1[0]);
                double y = double.Parse(temp1[1]);
                t = x / y;
                res += t;
            }
            return res/personalDataList.Count();
        }

        public int CountOtherGuesses(string username)
        {
            return otherDataList.Count();
        }

        public double CountOtherResultAverage(string username)
        {
            double res = 0;
            double t = 0;
            foreach (string s in otherDataList)
            {
                string[] temp = s.Split(' ');
                string[] temp1 = temp[2].Split('/');
                double x = double.Parse(temp1[0]);
                double y = double.Parse(temp1[1]);
                t = x / y;
                res += t;
            }
            return res / otherDataList.Count();
        }

        public string GetBestGuesser(string username)
        {
            double max = 0;
            string name = null;

            foreach (string s in otherDataList)
            {
                string[] temp = s.Split(' ');
                string[] temp1 = temp[2].Split('/');
                double x = double.Parse(temp1[0]);
                double y = double.Parse(temp1[1]);

                if ((x / y) > max)
                {
                    max = x / y;
                    name = temp[1];
                }

            }
            return name;
        }

        public double GetOtherHighestResult(string username)
        {
            double max = 0;
            foreach (string s in otherDataList)
            {
                string[] temp = s.Split(' ');
                string[] temp1 = temp[2].Split('/');
                double x = double.Parse(temp1[0]);
                double y = double.Parse(temp1[1]);

                if ((x / y) > max)
                {
                    max = x / y;
                }

            }
            return max;
        }

        public double GetPersonalHighestResult(string username)
        {      
            double max = 0;
            foreach (string s in personalDataList)
            {
                string[] temp = s.Split(' ');
                string[] temp1 = temp[2].Split('/');
                double x = double.Parse(temp1[0]);
                double y = double.Parse(temp1[1]);

                if ((x / y) > max)
                {
                    max = x / y;
                }

            }
            return max;
        }
    }
}
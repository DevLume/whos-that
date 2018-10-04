using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    class DataManager : IDataManager
    {
        // DataManager methods for saving Tests

        string userDirectoryPath = String.Concat(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"\user tests");
        string folderName, testName;
        public DataManager()
        {

        }
        public DataManager(string folderName, string testName)
        {
            this.folderName = folderName;
            this.testName = testName;
            this.testName += ".txt";
        }
        public string getDirectoryPath()
        {
            return Path.Combine(userDirectoryPath, folderName);
        }
        public string getFilePath()
        {
            return Path.Combine(Path.Combine(userDirectoryPath, folderName), testName);
        }
        public bool fileExists()
        {
            return File.Exists(Path.Combine(Path.Combine(userDirectoryPath, folderName), testName));
        }
        public void createDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
        public void writeToFile(string path, List<string> questions, List<string> answersA, List<string> answersB, List<string> answersC, List<string> answersD, List<int> correctAnswers)
        {
            string insertedLine;
            for (int i = 0; i < questions.Count(); i++)
            {
                insertedLine = String.Concat(questions[i], "|", answersA[i], "|", answersB[i], "|", answersC[i], "|", answersD[i], "|", correctAnswers[i], "\n");
                try
                {
                    File.AppendAllText(path, insertedLine + Environment.NewLine);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine("Could Not modify" + testName + ".txt", e.GetType().Name);
                }
            }
        }

        // Methods for working with data.txt

        string dataFilePath = String.Concat(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, @"\data.txt");
        public string[] GetDataLine(string username)
        {
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e) {
                Console.WriteLine("There was a problem with File", e.GetType().Name);   
                return null;
            }
            string line;
            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        string[] temp = line.Split(' ');
                        if (temp.Length >= 3)
                        {
                            if (String.Compare(temp[0], username).CompareTo(0) == 0)
                            {
                                string[] searchResult = new string[3];
                                searchResult[0] = temp[0];
                                searchResult[1] = temp[1];
                                searchResult[2] = temp[2];
                                fileRead.Close();
                                return searchResult;
                            }
                        }
                    }
                }
            }
            fileRead.Close();
            return null;
        }

        public string[] GetDataLine(string username, string email)
        {
            if (username != null) GetDataLine(username);
            else {
                System.IO.StreamReader fileRead;
                try
                {
                    fileRead = new System.IO.StreamReader(dataFilePath);
                }
                catch (IOException e)
                {
                    Console.WriteLine("There was a problem with File", e.GetType().Name);
                    return null;
                }
                string line;
                if (File.Exists(dataFilePath))
                {
                    using (FileStream fs = File.OpenRead(dataFilePath))
                    {
                        while ((line = fileRead.ReadLine()) != null)
                        {
                            string[] temp = line.Split(' ');
                            if (temp.Length >= 3)
                            {
                                if (String.Compare(temp[1], email).CompareTo(0) == 0)
                                {
                                    string[] searchResult = new string[3];
                                    searchResult[0] = temp[0];
                                    searchResult[1] = temp[1];
                                    searchResult[2] = temp[2];
                                    fileRead.Close();
                                    return searchResult;
                                }
                            } 
                        }
                    }
                }
                fileRead.Close();
            }
            return null;
        }

        public bool InsertUniqueDataLine(string username, string email, string passwordHash)
        {
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was a problem with File", e.GetType().Name);
                return false;
            }
            string line;
            bool foundSameLine = false;

            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        string[] temp = line.Split(' ');
                        if (temp.Length >= 3)
                        {
                            if (String.Compare(temp[0], username).CompareTo(0) == 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            else {
                Console.WriteLine("No File");
                return false;
            }

            fileRead.Close();

            String insertedLine = String.Concat(username, " ", email, " ", passwordHash, "\n");

            try
            {
                File.AppendAllText(dataFilePath, insertedLine + Environment.NewLine);
            }
            catch (System.IO.IOException e) {
                Console.WriteLine("Could Not modify data.txt", e.GetType().Name);
                return false;
            }
            return true; 
        }
    }
}

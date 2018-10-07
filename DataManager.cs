using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whos_that
{
    class DataManager : IDataManager
    {
        // DataManager methods for saving Tests

        string userDirectoryPath = String.Concat(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"\user tests");
        private string folderName, testName;
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
        public void writeToFile(string path, List<Question> questions, bool append) {
            if(append == false) File.Delete(path);
            Console.WriteLine("Creating file in " + path);
            string insertedLine;
            for (int i = 0; i < questions.Count(); i++)
            {
                insertedLine = String.Concat(questions[i].questionText, "|", questions[i].answerA, "|", questions[i].answerB, 
                    "|", questions[i].answerC, "|", questions[i].answerD, "|",
                    questions[i].correctAnswerNum, "\n");
                try
                {
                    File.AppendAllText(path, insertedLine + Environment.NewLine);
                }
                catch (IOException e)
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
           // bool foundSameLine = false; sitas variable kinda useless 

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
        //Database methods here:
        //TODO:Add exception handling
        public List<UserData> GetUserDataDB(string username)
        {
            List<UserData> result = new List<UserData>();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersTable>();
            //query and parsing here:

            var q = from a in usrTable where a.Name == username select a;
            foreach (var i in q) {
                result.Add(new UserData (i.Id, i.Name, i.Email, i.PassHash, i.Gender, (bool)i.Online));
            }

            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public List<UserData> GetUserDataDB(int id)
        {
            List<UserData> result = new List<UserData>();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersTable>();
            //query and parsing here:

            var q = from a in usrTable where a.Id == id select a;
            foreach (var i in q)
            {
                result.Add(new UserData(i.Id, i.Name, i.Email, i.PassHash, i.Gender, (bool)i.Online));
            }

            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public List<UserRelData> GetUserRelDataDB(string username)
        {
            /*List<UserData> result = new List<UserData>();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersRelTable>();
            //query and parsing here:

            var q = from a in usrTable where a.Name == id select a;
            foreach (var i in q)
            {
                result.Add(new UserData(i.Id, i.Name, i.Email, i.PassHash, i.Gender, (bool)i.Online));
            }

            //Close data context
            dataSpace.Dispose();
            return result;*/
            throw new NotImplementedException();
        }

        public List<UserRelData> GetUserRelDataDB(int id)
        {
            List<UserRelData> result = new List<UserRelData>();
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersRelTable>();
            //query and parsing here:

            var q = from a in usrTable where a.Id == id select a;
            foreach (var i in q)
            {
                result.Add(new UserRelData(i.Id, i.user1ID, (int)i.user2ID, (bool)i.approved, (DateTime)i.since, (bool)i.received));
            }

            //Close data context
            dataSpace.Dispose();
            return result;
        }

        public void InsertUserDataDB(List<UserData> data)
        {
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersTable>();
            usersTable tbl;
            //query and parsing here:
            foreach (UserData userdat in data) {
                tbl = new usersTable(userdat.id,userdat.name,
                    userdat.email, userdat.passHash, userdat.gender);
                dataSpace.usersTables.InsertOnSubmit(tbl);
            }

            try
            {
                dataSpace.SubmitChanges();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            //Close data context
            dataSpace.Dispose();
           // throw new NotImplementedException();
        }

        public void InsertUserRelDataDB(List<UserRelData> data)
        {
            //create new data context
            var dataSpace = new dataLinqDataContext();
            //get needed table from data context
            var usrTable = dataSpace.GetTable<usersRelTable>();
            usersRelTable tbl;
            //query and parsing here:
            foreach (UserRelData userdat in data)
            {
                tbl = new usersRelTable(userdat.id, userdat.user1ID,
                    userdat.user2ID, userdat.approved, userdat.date, userdat.received);
                dataSpace.usersRelTables.InsertOnSubmit(tbl);
            }

            try
            {
                dataSpace.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //Close data context
            dataSpace.Dispose();
        }  
    }
}

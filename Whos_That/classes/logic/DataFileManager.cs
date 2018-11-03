using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whos_that
{
    public class DataFileManager : IDataManager
    {
        // DataManager methods for saving Tests
        private string folderName, testName, usernameToGuess;
        private const string testFileName = @"\user tests", resultFileName = @"\user answers";
        private string userDirectoryPath;
        public DataFileManager()
        {
        }
        public DataFileManager(string folderName, string testName)
        {
            this.folderName = folderName;
            this.testName = testName;
            userDirectoryPath = String.Concat(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName);
        }
        public DataFileManager(string folderName, string testName, string usernameToGuess)
        {
            this.usernameToGuess = usernameToGuess;
            this.folderName = folderName;
            this.testName = testName;
            userDirectoryPath = String.Concat(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName);
        }
        public void updateDirectoryTests()
        {
          userDirectoryPath = String.Concat(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, testFileName);
        }
        public void updateDirectoryAnswers()
        {
            userDirectoryPath = String.Concat(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, resultFileName);
        }

        public string getDirectoryPath()
        {
            return Path.Combine(userDirectoryPath, folderName);
        }
        public string getDirectoryPath(string usernameToGuess)
        {
            return Path.Combine(Path.Combine(userDirectoryPath, folderName), usernameToGuess);
        }
        public string getFilePath()
        {
            return Path.Combine(Path.Combine(userDirectoryPath, folderName), testName);
        }
        public string getFilePath(string usernameToGuess)
        {
            return Path.Combine(Path.Combine(Path.Combine(userDirectoryPath, folderName), usernameToGuess), testName);
        }
        public bool fileExists()
        {
            return File.Exists(Path.Combine(Path.Combine(userDirectoryPath, folderName), testName));
        }
        public bool fileExists(string usernameToGuess)
        {
            return File.Exists(Path.Combine(Path.Combine(Path.Combine(userDirectoryPath, folderName), usernameToGuess), testName));
        }
        public void createDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
        public void saveAnswers(string path, int correctAnswers)
        {
               try
                {
                    File.AppendAllText(path, correctAnswers + Environment.NewLine);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Could Not modify" + testName, e.GetType().Name);
                }
        }
        public int[] getAnswers(string path)
        {
            StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(path);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was a problem with File", e.GetType().Name);
                return null;
            }
            int[] results = new int[3];
            string temp;
            if (File.Exists(path))
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    while ((temp = fileRead.ReadLine()) != null)
                    {
                        if (Convert.ToInt16(temp) > results[0]) results[0] = Convert.ToInt16(temp);
                        results[1]++;
                        results[2] += Convert.ToInt16(temp);
                    }
                }
            }
            fileRead.Close();
            results[2] /= results[1];
            return results;
        }
        public void writeToFile(string path, List<Question> questions, bool append)
        {
            if (append == false) File.Delete(path);
            string insertedLine;
            foreach (Question question in questions)
            {
                insertedLine = String.Concat($"{ question.QuestionText }|{ question.AnswerA }|{ question.AnswerB }|{ question.AnswerC }|{ question.AnswerD }|{ question.CorrectAnswerNum }");
                try
                {
                    File.AppendAllText(path, insertedLine + Environment.NewLine);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Could Not modify" + testName, e.GetType().Name);
                }
            }
        }

        public List<string> getTestData(string testName, string username, string path)
        {
            List<string> lines = new List<string>();
            StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(path);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was a problem with File", e.GetType().Name);
                return null;
            }
            string line;
            if (File.Exists(path))
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }

            fileRead.Close();
            return lines;
        }

        // methods to work with data.txt
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        string dataFilePath = String.Concat(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, @"\data.txt");
        string relDataFilePath = String.Concat(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, @"\relData.txt");
        public string[] GetDataLine(string username)
        {
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
            else
            {
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

        public bool InsertUniqueDataLine(string username, string dataline)
        {
            int entryID = 0;
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

            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        string[] temp = line.Split(' ');
                        if (temp.Length >= 6)
                        {
                            if (String.Compare(temp[1], username).CompareTo(0) == 0)
                            {
                                return false;
                            }
                            entryID++;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No File");
                return false;
            }

            fileRead.Close();
            UserData tempdata = GetUserData(entryID+1);
            while(tempdata.id != 0)
            {
                entryID++;
                tempdata = GetUserData(entryID + 1);
            }
           // String insertedLine = String.Concat(username, " ", email, " ", passwordHash, "\n");
            String insertedLine = String.Concat($"{entryID+1}{dataline}\n");

            try
            {
                File.AppendAllText(dataFilePath, insertedLine + Environment.NewLine);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Could Not modify data.txt", e.GetType().Name);
                return false;
            }
            return true;
        }
        public bool InsertUniqueDataLine(int id1, int id2, string dataline)
        {
            int entryID = 0;

            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(relDataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was a problem with File", e.GetType().Name);
                return false;
            }
            string line;
            // bool foundSameLine = false; sitas variable kinda useless 

            if (File.Exists(relDataFilePath))
            {
                using (FileStream fs = File.OpenRead(relDataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        string[] temp = line.Split(' ');
                        if (temp.Length >= 6)
                        {
                            if (Int32.Parse(temp[1]) == id1 && Int32.Parse(temp[2]) == id2)
                            {
                                Console.WriteLine("Such relationship already exists");
                            }

                            entryID++;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No File");
                return false;
            }

            fileRead.Close();

            List<UserRelData> tempdata = GetUserRelData(entryID + 1);

            foreach (UserRelData u in tempdata)
            {
                if (entryID < u.id)
                {
                    entryID = u.id + 1;
                }
            }

            // String insertedLine = String.Concat(username, " ", email, " ", passwordHash, "\n");
            String insertedLine = String.Concat($"{entryID+1}{dataline}\n");

            try
            {
                File.AppendAllText(relDataFilePath, insertedLine + Environment.NewLine);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Could Not modify data.txt", e.GetType().Name);
                return false;
            }
            return true;
        }

        public UserData GetUserData(string username)
        {
            UserData userdat = new UserData();
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was a problem with File", e.GetType().Name);
                return new UserData();
            }
            string line;
            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        string[] temp = line.Split(' ');
                        if (temp.Length >= 6)
                        {
                            if (String.Compare(temp[1], username).CompareTo(0) == 0)
                            {
                                //string[] searchResult = new string[3];
                                /*searchResult[0] = temp[0];
                                searchResult[1] = temp[1];
                                searchResult[2] = temp[2];*/
                                userdat.id = Int32.Parse(temp[0]);
                                userdat.name = temp[1];
                                userdat.email = temp[2];
                                userdat.passHash = temp[3];
                                userdat.gender = temp[4];
                                userdat.online = bool.Parse(temp[5]);
                                fileRead.Close();
                                return userdat;
                            }
                        }
                    }
                }
            }
            fileRead.Close();
            return new UserData();
        }

        public UserData GetUserData(int id)
        {
            UserData userdat = new UserData();
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was a problem with File", e.GetType().Name);
                return new UserData();
            }
            string line;
            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        string[] temp = line.Split(' ');
                        if (temp.Length >= 6)
                        {
                            if (Int32.Parse(temp[0]) == id)
                            {
                                //string[] searchResult = new string[3];
                                /*searchResult[0] = temp[0];
                                searchResult[1] = temp[1];
                                searchResult[2] = temp[2];*/
                                userdat.id = Int32.Parse(temp[0]);
                                userdat.name = temp[1];
                                userdat.email = temp[2];
                                userdat.passHash = temp[3];
                                userdat.gender = temp[4];
                                userdat.online = bool.Parse(temp[5]);
                                fileRead.Close();
                                return userdat;
                            }
                        }
                    }
                }
            }
            fileRead.Close();
            return new UserData();
        }

        public UserData GetUserDataByEmail(string email)
        {
            UserData userdat = new UserData();
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was a problem with File", e.GetType().Name);
                return new UserData();
            }
            string line;
            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        string[] temp = line.Split(' ');
                        if (temp.Length >= 6)
                        {
                            if (String.Compare(temp[2], email).CompareTo(0) == 0)
                            {
                                //string[] searchResult = new string[3];
                                /*searchResult[0] = temp[0];
                                searchResult[1] = temp[1];
                                searchResult[2] = temp[2];*/
                                userdat.id = Int32.Parse(temp[0]);
                                userdat.name = temp[1];
                                userdat.email = temp[2];
                                userdat.passHash = temp[3];
                                userdat.gender = temp[4];
                                userdat.online = bool.Parse(temp[5]);
                                fileRead.Close();
                                return userdat;
                            }
                        }
                    }
                }
            }
            fileRead.Close();
            return new UserData();
        }

        public List<User> GetAllOnlineUserData()
        {
            UserData userdat = new UserData();
            List<User> result = new List<User>();
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was a problem with File", e.GetType().Name);
                return new List<User>();
            }
            string line;
            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        string[] temp = line.Split(' ');
                        if (temp.Length >= 6)
                        {
                            if (Int32.Parse(temp[5]) == 1)
                            {
                                //string[] searchResult = new string[3];
                                /*searchResult[0] = temp[0];
                                searchResult[1] = temp[1];
                                searchResult[2] = temp[2];*/
                                userdat.id = Int32.Parse(temp[0]);
                                userdat.name = temp[1];
                                userdat.email = temp[2];
                                userdat.passHash = temp[3];
                                userdat.gender = temp[4];
                                userdat.online = bool.Parse(temp[5]);
                                result.Add(new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender));                          
                            }
                        }
                    }
                }
            }
            fileRead.Close();
            return result;
        }

        public List<User> GetAllUserData()
        {
            UserData userdat = new UserData();
            List<User> result = new List<User>();
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was a problem with File", e.GetType().Name);
                return new List<User>();
            }
            string line;
            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        string[] temp = line.Split(' ');
                        if (temp.Length >= 6)
                        {               
                            userdat.id = Int32.Parse(temp[0]);
                            userdat.name = temp[1];
                            userdat.email = temp[2];
                            userdat.passHash = temp[3];
                            userdat.gender = temp[4];
                            userdat.online = bool.Parse(temp[5]);
                            result.Add(new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender));
                        }
                    }
                }
            }
            fileRead.Close();
            return result;
        }

        public List<UserRelData> GetUserRelData(int id)
        {
            UserRelData userdat = new UserRelData();
            List<UserRelData> result = new List<UserRelData>();
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(relDataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was a problem with File", e.GetType().Name);
                return result;
            }
            string line;
            if (File.Exists(relDataFilePath))
            {
                using (FileStream fs = File.OpenRead(relDataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        string[] temp = line.Split(' ');
                        if (temp.Length >= 6 && Int32.Parse(temp[1]) == id)
                        {
                            userdat.id = Int32.Parse(temp[0]);
                            userdat.user1ID = Int32.Parse(temp[1]);
                            userdat.user2ID = Int32.Parse(temp[2]);
                            userdat.approved = Boolean.Parse(temp[3]);
                            userdat.date = DateTime.ParseExact(temp[4], "dd/MM/yyyy", 
                                CultureInfo.InvariantCulture);
                            userdat.received = Boolean.Parse(temp[5]);
                            //result.Add(new User(userdat.id, userdat.name, userdat.email, userdat.passHash, userdat.gender));
                            result.Add(new UserRelData(userdat.id, userdat.user1ID,userdat.user2ID,
                                userdat.approved,userdat.date, userdat.received));
                        }
                    }
                }
            }
            fileRead.Close();
            return result;
        }

        public List<UserRelData> GetUserRelData(string username)
        {
            throw new NotImplementedException();
        }

        public void InsertUserData(List<UserData> data)
        {
            foreach (UserData userdat in data)
            {
                string dataline = string.Concat(" ", userdat.name, " ",
                    userdat.email, " ", userdat.passHash, " ", userdat.gender, " ", userdat.online, "\n");
                InsertUniqueDataLine(userdat.name, dataline);
            }
        }

        public void InsertUserRelData(List<UserRelData> data)
        {
            foreach (UserRelData userdat in data)
            {              
                string dataline = string.Concat( " ", userdat.user1ID, " ", 
                    userdat.user2ID, " ", userdat.approved, " ",userdat.date.ToString("dd/MM/yyyy") , " ", 
                    userdat.received, "\n");
                InsertUniqueDataLine(userdat.user1ID, userdat.user2ID, dataline);
            }
        }

        public void RemoveUserData(List<UserData> data)
        {
            foreach (UserData userdat in data)
            {
                string dataline = string.Concat(userdat.id, " ", userdat.name, " ",
                   userdat.email, " ", userdat.passHash, " ", userdat.gender, " ", userdat.online, "\n");
                RemoveLine(userdat.id, dataline, dataFilePath);
            }
        }

        public void RemoveUserRelData(List<UserRelData> data)
        {
            foreach (UserRelData userdat in data)
            {
                /*string dataline = string.Concat(userdat.id, " ", userdat.user1ID, " ",
                userdat.user2ID, " ", userdat.approved, " ", userdat.date.ToString("dd/MM/yyyy"), " ",
                userdat.received);*/
                IEnumerable<string> Edataline = File.ReadLines(relDataFilePath);
                string dataline = null;
                foreach (var s in Edataline)
                {
                    if (s.Split(' ')[0] == userdat.id.ToString())
                    {
                        dataline = s;
                    }
                    //Console.WriteLine(dataline);
                }
                RemoveLine(userdat.id, dataline, relDataFilePath);
            }
        }

        void RemoveLine(int lineID, string dataline, string filePath)
        { 
            var tempPath = String.Concat(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, string.Concat(@"\temp",RandomString(4),".txt"));
            var linesToKeep = File.ReadLines(filePath).Where(l => l != dataline);
            File.Delete(tempPath);
            File.WriteAllLines(tempPath, linesToKeep);
            File.Delete(filePath);
            File.Move(tempPath, filePath);
        }

        public bool CreateRelationship(int uid1, int uid2, bool approved)
        {
            List<UserRelData> ureldat = GetUserRelData(uid1);
            UserRelData existingLine = new UserRelData();
            UserRelData newLine = new UserRelData();
            foreach (UserRelData u in ureldat)
            {
                if (!(bool)u.received && u.user1ID == uid2 && u.user2ID == uid1)
                {
                    Console.WriteLine("Such relationship already exists");
                    return false;
                }
            }

            if (!approved)
            {
                List<UserRelData> rmdat = new List<UserRelData>();
                foreach (UserRelData u in ureldat)
                {
                    if (!(bool)u.received && u.user1ID == uid1 && u.user2ID == uid2)
                    {
                        rmdat.Add(new UserRelData(u.id, (int)u.user1ID, (int)u.user2ID, (bool)u.approved, DateTime.Today, (bool)u.received));
                    }
                }
                RemoveUserRelData(rmdat);
                return true;
            }
            else
            {
                List<UserRelData> reldat = new List<UserRelData>();             
                foreach (UserRelData u in ureldat)
                {
                    if (u.user2ID == uid2 && u.user1ID == uid1)
                    {
                        existingLine = u;
                        newLine = u;
                        newLine.approved = true;
                        newLine.received = false;
                        newLine.date = DateTime.Today;
                        reldat.Add(new UserRelData(newLine.id, uid2, uid1, true, (DateTime)newLine.date, false));
                        Console.WriteLine("Adding with since date {0}", newLine.date);
                        InsertUserRelData(reldat);
                    }
                }
            }

            //Modify existing line
            List<UserRelData> temp = new List<UserRelData>();
            temp.Add(existingLine);

            RemoveUserRelData(temp);

            temp = new List<UserRelData>();
            temp.Add(newLine);

            InsertUserRelData(temp);

            return true;
        }

        public bool InsertMessage(int uid1, int uid2, string message)
        {
            throw new NotImplementedException();
        }

        public bool ModifyOnline(int usrID, bool isOnline)
        {
            throw new NotImplementedException();
        }
    }
}

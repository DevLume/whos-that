using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WT_TestManager.TestManagement.Tools;

namespace WT_TestManager.TestManagement
{
    public class TestManager : ITestManager
    {
        public static string rootPath { get; set; }
        private IDirectoryManager dirMan;

        public TestManager(IDirectoryManager dir)
        {
            rootPath = dir.rootPath;
            dirMan = dir;
        }

        public Test CreateTest(string author, string title, List<Question> questions)
        {
            Test test = new Test(title, author, questions);
            if (!dirMan.CreateDirectory(rootPath, author))
            {
                Console.WriteLine("Such user directory already exists!");
            }

            if (!dirMan.CreateDirectory(string.Concat(rootPath, @"\", author, @"\"), "madeTests"))
            {
                Console.WriteLine("Could Not Create a test file directory");              
            }                

            string testPath = string.Concat(rootPath, @"\", author, @"\", "madeTests", @"\", title);
            writeToFile(testPath, title, questions, true);
            return new Test(title, author, questions);          
        }
 
        public List<Question> GetTestData(string author, string title)
        {
            List<Question> result = new List<Question>();

            StreamReader fileRead;

            string path = string.Concat(rootPath, @"\", author, @"\", "madeTests", @"\", title);

            try
            {
                fileRead = new System.IO.StreamReader(path);
            }
            catch (IOException ex)
            {
                Console.WriteLine("There was a problem with a file ", ex);
                return null;
            }         
         

            if (File.Exists(path))
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    string s = "";
                    string[] sq;
                    while ((s = fileRead.ReadLine()) != null)
                    {
                        try
                        {
                            Question q = new Question("", "", "", "", "", 0);
                            sq = s.Split('|');
                            q.question = sq[0];
                            q.answer1 = sq[1];
                            q.answer2 = sq[2];
                            q.answer3 = sq[3];
                            q.answer4 = sq[4];
                            q.correctAnswerIndex = Int32.Parse(sq[5]);

                            result.Add(q);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("An Exception while generating a question list occured ", ex);
                            return null;
                        }
                    }

                }
            }
            return result;
        }

        public void writeToFile(string path, string testName, List<Question> questions, bool append)
        {
            if (append == false) File.Delete(path);
            string insertedLine;
            foreach (Question question in questions)
            {
                insertedLine = String.Concat($"{ question.question }|{ question.answer1 }|{ question.answer2 }|{ question.answer3 }|{ question.answer4}|{ question.correctAnswerIndex }");
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

    }
}
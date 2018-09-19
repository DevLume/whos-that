using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Whos_that
{
    public class User : SecurityManager
    {
        public String username;
        public String gender;
        private String passwordHash;
        private String email;

        public void RestoreAccount() {
           //TODO: add account restore 
        }

        public String CreateAccount(String username, String password, String email) {
            //Check username length
            if (username.Length > 16) return "Username is too long";

            //check email
            const String regexPattern =
                 @"^([0-9a-zA-Z]" + //Start with a digit or alphabetical
               @"([\+\-_\.][0-9a-zA-Z]+)*" + // No continuous or ending +-_. chars in email
               @")+" +
               @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";
            String checkEmail = email;
            Regex regex = new Regex(regexPattern);
            Match match = regex.Match(checkEmail);
            if (!match.Success)
                return "Email format is wrong";
            //hash the password
            String passHash = HashPassword(username, password);

            //Currently no database, so will store accounts in files

            //Open file to read
            String dataFilePath = String.Concat(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName,@"\data.txt");
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e) {
                Console.WriteLine("There was problem with File", e.GetType().Name);
                return "IO error";
            }
            String line;
            
            //Check if same username exists
            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        String dbUsername = line;
                        //TEST:
                        //Console.Write(temp.GetString(b));
                        

                        //Console.Write(String.Concat(username," ",dbUsername, " ", String.Compare(username, dbUsername).ToString()));
                        //Console.WriteLine("");
                        //----

                        if (String.Compare(username, dbUsername).CompareTo(0) == 0) {
                            return "Such username already exists";
                        }
                    }
                }
            }
            else {
                Console.WriteLine("No File");
            }
            //Close File
            fileRead.Close();

            //Account can be created, so we gather final data and send it to the database (currently to the file)
            this.email = email;
            passwordHash = passHash;
            this.username = username;

            String outputLine = String.Concat("\n", this.username, " ", this.email, " ", this.passwordHash);

            File.AppendAllText(dataFilePath, outputLine + Environment.NewLine);
            

            //FOR TESTING
           /* string test = HashPassword(username,password);
            Console.WriteLine(String.Concat("hash: ",test));

            string test1 = DehashPassword(test, password);
            Console.WriteLine(String.Concat("dehashed string: ", test1));*/
            //-------
            return "Account created successfully!";
        }

    }
}

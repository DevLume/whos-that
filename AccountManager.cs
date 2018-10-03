<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Whos_that
{
    public class AccountManager : SecurityManager
    {
        public bool CreateAccount(String username, String password, String email)
        {
            //Check username length
            if (username.Length > 16)
            {
                Console.WriteLine("username is too long");
                return false;
            }

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
            {
                Console.WriteLine("E-mail format is wrong.");
                return false;
            }
            //hash the password
            String passHash = HashPassword(password, username);

            //Currently no database, so will store accounts in files

            //Open file to read
            String dataFilePath = String.Concat(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, @"\data.txt");
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was problem with File", e.GetType().Name);
                return false;
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
                        string[] tokens = dbUsername.Split(' ');

                        dbUsername = tokens[0];                      

                        if (String.Compare(username, dbUsername).CompareTo(0) == 0)
                        {
                            Console.WriteLine("Such username already exists!");
                            return false;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No File");
            }
            //Close File
            fileRead.Close();

            //Account can be created, so we gather final data and send it to the database (currently to the file)
           
            String outputLine = String.Concat(username, " ", email, " ", passHash, "\n");

            try
            {
                File.AppendAllText(dataFilePath, outputLine + Environment.NewLine);
            }
            catch (System.IO.IOException e) {
                Console.WriteLine("Could not create an account! data file is at use", e.GetType().Name);
                return false;
            }
            return true;
        }

        public bool Login(String username, String password)
        {
            String dataFilePath = String.Concat(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, @"\data.txt");
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was problem with File", e.GetType().Name);
                return false;
            }
            String line;
            bool foundUser = false;
            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        String[] temp = line.Split(' ');
                        String dbUsername = temp[0];
                        String passwordHash;
                        if (String.Compare(username, dbUsername) == 0)
                        {
                            foundUser = true;
                            
                            passwordHash = temp[2];
                            String dbPass;
                            try
                            {
                                dbPass = DehashPassword(passwordHash, username);
                                if (String.Compare(password, dbPass) == 0)
                                {
                                    fileRead.Close();
                                    User usr = new User(temp[0], temp[2], temp[1]);
                                    UserManager.userList.Add(usr); // For now we'll always have one user connected... guess why.
                                    //TESTING
                                    /*
                                    string[] str = UserManager.ListUsers();
                                    Console.WriteLine("List All Users:");
                                    for (int i = 0; i < str.Length; i++) {
                                        Console.WriteLine(str[i]);
                                    }

                                    RemindPassword(temp[1]);
                                    */
                                    //----------------------
                                    return true;
                                }
                            }
                            catch (System.Security.Cryptography.CryptographicException e)
                            {
                                Console.WriteLine("Username or Password is wrong");
                                fileRead.Close();
                                return false;
                            }

                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No File");
            }

            if (!foundUser)
            {
                Console.WriteLine("No such user is found");
                return false;
            }

            fileRead.Close();
            Console.WriteLine("Password is wrong");
            return false;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Whos_that
{
    public class AccountManager : SecurityManager
    {

        public void RestoreAccount()
        {
            //TODO: add account restore 
        }

        public bool CreateAccount(String username, String password, String email)
        {
            //Check username length
            if (username.Length > 16)
            {
                Console.WriteLine("username is too long");
                return false;
            }
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
            {
                Console.WriteLine("E-mail format is wrong.");
                return false;
            }
            //hash the password
            String passHash = HashPassword(password, username);

            //Currently no database, so will store accounts in files

            //Open file to read
            String dataFilePath = String.Concat(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, @"\data.txt");
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was problem with File", e.GetType().Name);
                return false;
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
                        string[] tokens = dbUsername.Split(' ');

                        dbUsername = tokens[0];
                       

                        if (String.Compare(username, dbUsername).CompareTo(0) == 0)
                        {
                            Console.WriteLine("Such username already exists!");
                            return false;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No File");
            }
            //Close File
            fileRead.Close();

            //Account can be created, so we gather final data and send it to the database (currently to the file)
           
            String outputLine = String.Concat(username, " ", email, " ", passHash, "\n");

            File.AppendAllText(dataFilePath, outputLine + Environment.NewLine);

            return true;
        }

        public bool Login(String username, String password)
        {
            //TODO: Add User initialisation
            String dataFilePath = String.Concat(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, @"\data.txt");
            System.IO.StreamReader fileRead;
            try
            {
                fileRead = new System.IO.StreamReader(dataFilePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("There was problem with File", e.GetType().Name);
                return false;
            }
            String line;
            bool foundUser = false;
            if (File.Exists(dataFilePath))
            {
                using (FileStream fs = File.OpenRead(dataFilePath))
                {
                    while ((line = fileRead.ReadLine()) != null)
                    {
                        String[] temp = line.Split(' ');
                        String dbUsername = temp[0];
                        String passwordHash;
                        if (String.Compare(username, dbUsername) == 0)
                        {
                            foundUser = true;
                            passwordHash = temp[2];
                            String dbPass;
                            try
                            {
                                dbPass = DehashPassword(passwordHash, username);
                                if (String.Compare(password, dbPass) == 0)
                                {
                                    fileRead.Close();     
                                    return true;
                                }
                            }
                            catch (System.Security.Cryptography.CryptographicException e)
                            {
                                Console.WriteLine("Username or Password is wrong");
                                fileRead.Close();
                                return false;
                            }

                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No File");
            }

            if (!foundUser)
            {
                Console.WriteLine("No such user is found");
                return false;
            }

            fileRead.Close();
            Console.WriteLine("Password is wrong");
            return false;
        }
    }
}
>>>>>>> master

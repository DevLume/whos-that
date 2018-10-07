using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Whos_that
{
    public class AccountManager : SecurityManager
    {
        DataManager dataMan = new DataManager();
   
        public bool CreateAccount(string username, string password, string email)
        {
            //Check username length
            if (username.Length > 16)
            {
                MessageBox.Show("username is too long");
                return false;
            }
            //check username for spaces
            for (int i = 0; i < username.Length; i++) {
                if (username[i] == ' ') {
                    MessageBox.Show("Wrong username format");
                    return false;
                }
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
                MessageBox.Show("E-mail format is wrong.");
                return false;
            }
            //hash the password
            String passHash = HashPassword(password, username);

            //Currently no database, so will store accounts in files
            //Check if same username exists

            string[] checkline = dataMan.GetDataLine(username);

            if (checkline == null)
            {
                dataMan.InsertUniqueDataLine(username, email, passHash);
                MessageBox.Show("You have successfully created an account!");
            }
            else {
                MessageBox.Show("Such username is taken");
                return false;
            }        
            return true;
        }

        public bool Login(string username, string password)
        {      
            bool foundUser = false;
           
            string[] temp = dataMan.GetDataLine(username);
            if (temp == null) foundUser = false;
            else foundUser = true;

            if (!foundUser)
            {
                MessageBox.Show("No such user is found");
                return false;
            }

            string dehashedPass = DehashPassword(temp[2], temp[0]);

            if (String.Compare(dehashedPass, password).CompareTo(0) == 0) {
               // User usr = new User(temp[0], temp[2], temp[1]);
                //UserManager.onlineUserList.Add(usr);
                Console.WriteLine("Login was successful!");
                return true;
            }

            MessageBox.Show("Password is wrong");
            return false;
        }
    }
}

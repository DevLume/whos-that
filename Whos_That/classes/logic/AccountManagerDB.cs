using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whos_that
{
    class AccountManagerDB : SecurityManager
    {
        UserManager userMan = new UserManager();
        private event SigningEventHandler SignOn;
        
        public bool CreateAccount(string username, string password, string email)
        {
            if (username.Length > 16) {
                MessageBox.Show("Username is too long");
                return false;
            }

            for (int i = 0; i < username.Length; i++)
            {
                if (username[i] == ' ') {
                    MessageBox.Show("Wrong username format");
                    return false;
                }
            }

            const string regexPattern = @"^([0-9a-zA-Z]" + //Start with a digit or alphabetical
               @"([\+\-_\.][0-9a-zA-Z]+)*" + // No continuous or ending +-_. chars in email
               @")+" +
               @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";
            string checkEmail = email;
            Regex regex = new Regex(regexPattern);
            Match match = regex.Match(checkEmail);
            if (!match.Success)
            {
                MessageBox.Show("E-mail format is wrong");
                return false;
            }
            if (userMan.GetUserByEmail(email).id != 0)
            {
                MessageBox.Show("such E-mail is already taken");
                return false;
            }
            string passHash = HashString(password, username);

            //database time
            User newUser = new User(username,email, passHash,"unspecified");
            if (userMan.NewUser(newUser))
            {
                MessageBox.Show("An account has been created!");
                return true;
            }
            else
                return false;
        }

        public bool Login(string username, string password)
        {
            SignOn += EventManager.UserSignedOn;        
            User usr = userMan.GetUser(username);
            if (string.IsNullOrEmpty(usr.username))
            {
                MessageBox.Show("No such user exists");
                return false;
            }
            else
            {
                try
                {
                    string dbPass = DehashString(usr.passwordHash, username);
                    if (string.Compare(password, dbPass) == 0)
                    {
                        MessageBox.Show("Username and password are correct");
                        
                        EventManager.setID(usr.id);
                        SignOn();                      
                        return true;
                    }
                    else
                    {                      
                        Console.WriteLine("wrong password");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Username or Password is wrong or something else " + e );
                    return false;
                }
            }
            return false;
        }
    }
}

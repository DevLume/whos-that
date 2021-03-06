﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Whos_that
{
    class AccountManagerDB : SecurityManager
    {
        UserManager userMan = new UserManager();
        private event SigningEventHandler SignOn;
        
        public bool CreateAccount(string username, string password, string email, out string responseMessage)
        {
            int maxUsernameLength = Int32.Parse(WebConfigurationManager.AppSettings["maxUsernameLength"]);
            int minUsernameLength = Int32.Parse(WebConfigurationManager.AppSettings["minUsernameLength"]);
            int maxPaswordLength = Int32.Parse(WebConfigurationManager.AppSettings["maxPasswordLength"]);
            int minPasswordLength = Int32.Parse(WebConfigurationManager.AppSettings["minPasswordLength"]);

            if (username.Length > maxUsernameLength)
            {
                responseMessage = "Username is too long";
                return false;
            }
            else if (username.Length < minUsernameLength)
            {
                responseMessage = "Username is too short";
                return false;
            }


            for (int i = 0; i < username.Length; i++)
            {
                if (username[i] == ' ') {
                    responseMessage = "Wrong username format";
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
                responseMessage = "E-mail format is wrong";
                return false;
            }
            if (userMan.GetUserByEmail(email).id != 0)
            {
                responseMessage = "such E-mail is already taken";
                return false;
            }

            if (password.Length < minPasswordLength)
            {
                responseMessage = "Your password is too short";
                return false;
            }
            else if (password.Length > maxPaswordLength)
            {
                responseMessage = "Your password is too long";
                return false;
            }

            string passHash = HashString(password, username);

            //database time
            User newUser = new User(username,email, passHash,"unspecified");
            if (userMan.NewUser(newUser))
            {
                responseMessage = "An account has been created!";
                return true;
            }
            else
            {
                responseMessage = "An account could not be created, Such user Already exists";
                return false;
            }
        }

        public bool Login(string username, string password, out string responseMessage)
        {
            SignOn += EventManager.UserSignedOn;        
            User usr = userMan.GetUser(username);
            if (string.IsNullOrEmpty(usr.username))
            {
                 responseMessage = "No such user exists";
                return false;
            }
            else
            {
                try
                {
                    string dbPass = DehashString(usr.passwordHash, username);
                    if (string.Compare(password, dbPass) == 0)
                    {
                        responseMessage = "Username and password are correct";
                        
                        EventManager.setID(usr.id);
                        SignOn();                      
                        return true;
                    }
                    else
                    {                      
                       responseMessage = "wrong password";
                    }
                }
                catch (Exception e)
                {
                    responseMessage = "Username or Password is wrong or something else " + e ;
                    return false;
                }
            }
            return false;
        }
    }
}

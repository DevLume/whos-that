using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;

namespace Whos_that
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 


        //user init steps:
        /*
            1. create list of logged users
            2. on successful login, add new user to the list
            3. give option to list all users
        */
        public static List<User> userList = new List<User>(); // this will hold online users only

        [STAThread]
        static void Main()
        {
            UserManager userman = new UserManager();

            sortOptions opt = sortOptions.none;

            opt |= sortOptions.byGender;
            /*
             Lux
            Mister
            Garen
            Johnny
            */

            List<User> frnd = userman.GetUser("luke").ListFriends();

            List<User> sortOf = ListManager.CreateOutputList(opt,frnd);

            foreach (User u in sortOf)
            {
                Console.WriteLine(u.username);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			LoginForm logForm = new LoginForm();
            Application.Run(logForm);
        }
    }
}

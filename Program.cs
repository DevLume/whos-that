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
            ListManager listman = new ListManager();

            ListManager.sortOptions sortop = new ListManager.sortOptions { };

           
            //sortop = ListManager.sortOptions.none;
            //sortop |= ListManager.sortOptions.byName;
            
            List<User> ur = listman.CreateOutputList(sortop, userman.GetUser("luke").ListFriends());

            foreach (User u in ur)
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

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Whos_that
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static List<User> onlineUserList = new List<User>(); // this will hold online users only

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
               
            LoginForm logForm = new LoginForm();

            Application.Run(logForm);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whos_that
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

            User usr = new User();
            Console.WriteLine(usr.CreateAccount("TEXT", "test", "tet@email.com"));

           // MessageBox.Show(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
        }
    }
}

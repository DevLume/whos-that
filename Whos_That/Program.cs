using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Whos_that
{
    static class Program
    {

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
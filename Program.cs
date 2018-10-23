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
            UserManager u = new UserManager();

            User l = u.GetUser("luke");
            User m = u.GetUser("Mister");

            l.Unfriend(m);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm logForm = new LoginForm();
            Application.Run(logForm);
        }
    }
}
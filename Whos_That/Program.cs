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
            DataManager.SetDataManager(new DataBaseManager());
            UserManager uman = new UserManager();
            /*User lu = uman.GetUser("luke");
            User robo = uman.GetUser("robobat");

            lu.SendMessage(robo, "Prius sux");

            foreach (string s in robo.ListMessages())
            {
                Console.WriteLine(s);
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm logForm = new LoginForm();
            Application.Run(logForm);
        }
    }
}
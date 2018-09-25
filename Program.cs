using System;
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
            SecurityManager secMan = new SecurityManager();

            /*string hashedText = secMan.HashPassword("password", "username");

            Console.WriteLine(String.Concat("password hash: ", hashedText));

            hashedText = secMan.DehashPassword(hashedText, "username");

            Console.WriteLine(String.Concat("dehashed password: ", hashedText));*/
            //Console.WriteLine(usr.CreateAccount("password", "username", "megaEmail@email.com"));

            if (usr.Login("passsword", "username")) Console.WriteLine("Login is successful");

            // MessageBox.Show(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);            
        }
    }
}

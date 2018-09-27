using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             AccountManager acmos = new AccountManager();

             acmos.RemindPassword("lukaszm.dev@gmail.com");
             LoginForm logForm = new LoginForm();

             Application.Run(logForm);

            //Test mailing code snippet taken from MailKit github
            /*
            var messg = new MimeMessage();
            messg.From.Add(new MailboxAddress("email_from", "bot@mail.com"));
            messg.To.Add(new MailboxAddress("email_to", "lukaszm.dev@gmail.com"));
            messg.Subject = "TEST";

            var builder = new BodyBuilder();

            builder.TextBody = "TEST";

            messg.Body = builder.ToMessageBody();

            try
            {
                var client = new SmtpClient();
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("whos.that.robobat@gmail.com", "robobatforever");
                client.Send(messg);
                client.Disconnect(true);
            }
            catch (Exception e) {
                Console.WriteLine("Send Mail failed: " + e.Message);
            }
            Console.ReadLine();
            */
        }
    }
}

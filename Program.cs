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

      //  public static List<User> onlineUserList = new List<User>(); // this will hold online users only

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //TEST SPACE (friendlist v.0.1)
            User usr1 = new User("Alice", "test", "mail@mail.com");
            User usr2 = new User("Bob", "test1", "mail1@mail.com");

            DataManager dataMan = new DataManager();

            dataMan.InsertUniqueDataLine("Alice", "mail@mail.com", "test");
            dataMan.InsertUniqueDataLine("Bob", "mail1@mail.com", "test1");

            Console.WriteLine("Alice sends friend request to Bob...");
            usr1.SendFriendRequest(usr2);

            Console.WriteLine("Alice checks her sent friend requests...");
            usr1.ListSentFriendRequests();

            Console.WriteLine("Bob checks his friend Requests...");
            usr2.ListReceivedFriendRequests();

            Console.WriteLine("Bob accepts friend request from Alice");
            usr2.ReceiveRequest(usr1, true);

            Console.WriteLine("Alice checks her sent friend requests...");
            usr1.ListSentFriendRequests();

            Console.WriteLine("Bob checks his friend Requests...");
            usr2.ListReceivedFriendRequests();

            Console.WriteLine("Bob checks his friendlist...");
            usr2.ListAllFriends();

            Console.WriteLine("Alice checks her friendlist...");
            usr1.ListAllFriends();
            //---------

            LoginForm logForm = new LoginForm();

            Application.Run(logForm);
        }
    }
}

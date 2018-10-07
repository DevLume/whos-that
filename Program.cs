using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

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

            DataManager dataMan = new DataManager();

            /*List<UserData> userDat = dataMan.GetUserDataDB("Bob");

            foreach (UserData dat in userDat)
            {
                Console.WriteLine(dat.ToString());
            }

            userDat = dataMan.GetUserDataDB(0);

            foreach (UserData dat in userDat)
            {
                Console.WriteLine(dat.ToString());
            }*/

            /* List<UserRelData> udata = new List<UserRelData>();

             udata.Add(new UserRelData(0, 1, 2, false, DateTime.Today, true));
             udata.Add(new UserRelData(1, 2, 4, false, DateTime.Today, true));
             udata.Add(new UserRelData(2, 5, 5, false, DateTime.Today, true));
             udata.Add(new UserRelData(3, 3, 6, false, DateTime.Today, true));

             dataMan.InsertUserRelDataDB(udata);
             */
/*
            UserManager userMan = new UserManager();

            List<User> list = userMan.ListOnlineUsers();
            foreach (User u in list) {
                Console.WriteLine(u.username);
            }

            User alice = userMan.GetUser(0);
            User bob = userMan.GetUser("Bob");

            Console.WriteLine(alice.username);
            Console.WriteLine(bob.username);
            */
            /* var test1 = new dataLinqDataContext();
             var tt = test1.GetTable<testTable>();
             var q = from a in tt where a.Id == 2 select a;

             foreach (var j in q) {
                 Console.WriteLine(j.Name);
             }
             test1.Dispose();*/
            //TEST LINQ
            /* 
             var test = new dataLinqDataContext(); // Creating data context like: .dbml file name + DataContext()     
             var g = from a in test.testTables select new{ text1 = a.Name, text2 = a.Age }; // query
             foreach (var i in g) {
                 Console.WriteLine(i.text1 +" "+ i.text2.ToString());
             }
             int sum = (int)g.AsEnumerable().Sum(o=>o.text2); // dis will return sum of years (just for test purposes)                     
             Console.WriteLine("Sum of ages: " + sum);

             //data insertion:
            /* testTable pers = new testTable(3,"Toby",49);
             test.testTables.InsertOnSubmit(pers);
             try {
                 test.SubmitChanges();
             } catch (Exception e) {
                 Console.WriteLine(e);
             }*/
            /*
            Console.WriteLine("After Insertion:");
            g = from a in test.testTables select new { text1 = a.Name, text2 = a.Age }; // query
            foreach (var i in g)
            {
                Console.WriteLine(i.text1 + " " + i.text2.ToString());
            }
            sum = (int)g.AsEnumerable().Sum(o => o.text2); // dis will return sum of years (just for test purposes)                     
            Console.WriteLine("Sum of ages: " + sum);

            string nams = "Toby";

            var f = from a in test.testTables where a.Name == nams select new { o = a.Age };
            foreach (var i in f) {
                Console.WriteLine(i.o);
            }
            */
            //---------

            //LoginForm logForm = new LoginForm();

            //Application.Run(logForm);
            Application.Run();
        }
    }
}

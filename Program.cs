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

            //TEST SPACE (friendlist v.0.2)

            DataBaseManager dataMan = new DataBaseManager();
            UserManager userMan = new UserManager();

            userMan.NewUser(new User("Bob", "bob", "bobmail@mob.pop"));

            User Alice = userMan.GetUser("Alice");
            User Bob = userMan.GetUser("Bob");

            if (!Alice.SendFriendRq(Bob.GetId())) {
                Console.WriteLine("No rq sent");
            }

            Bob.AnswerFriendRq(Alice.GetId(), true);           


            //Alice.SendFriendRq(Bob.GetId());
            //Bob.SendFriendRq(Toby.GetId());

            /*Toby.AnswerFriendRq(Bob.GetId(), false);
            Bob.AnswerFriendRq(Alice.GetId(), true);*/

            //Bob.AnswerFriendRq(Alice.GetId(),true);

            /*User Toby = new User("Toby","lux","luxxul@nasxul.cr");
            UserData TobyData = Toby.ConvertToUserData();
            List<UserData> udat = new List<UserData>();
            udat.Add(TobyData);
            dataMan.InsertUserDataDB(udat);
            /*User Alice = new User("Alice","AliceD@gmail.com","pasahas","Female");
            User Bob = new User("Bob", "BobD@gmail.com", "pasahasz", "Male");

            List<UserData> temp = new List<UserData>();

            temp.Add(Alice.ConvertToUserData());
            temp.Add(Bob.ConvertToUserData());*/

            // dataMan.InsertUserDataDB(temp);

            /*List<UserData> alicedat = dataMan.GetUserDataDB("Alice");
            int aliceID = 0;
            foreach (UserData u in alicedat) {
                aliceID = u.id;
            }
            Console.WriteLine(aliceID);
            //User Alice = 

            List<UserData> bobdat = dataMan.GetUserDataDB("Bob");
            int bobID = 0;
            foreach (UserData u in bobdat)
            {
                bobID = u.id;
            }
            Console.WriteLine(bobID);
            /*Alice.id = aliceID;
            Bob.id = bobID;*/

            /*User AliceD = userMan.GetUser("Bob");
            Console.WriteLine(AliceD.id);
            Console.WriteLine(AliceD.username);
            //Console.WriteLine(AliceD.email);
            Console.WriteLine(AliceD.gender);
            //Console.WriteLine(AliceD.passHash);
            /*Bob.SendFriendRq(aliceID);
            Alice.AnswerFriendRq(bobID, true);*/
            /*List<User> alicefrnd = alice.ListFriends();
            foreach (User ur in alicefrnd) {
                Console.WriteLine(ur.username);
            }*/
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    public delegate void SigningEventHandler();
    public delegate void MessageEventHandler(User user);

    public static class EventManager
    { 
        private static int id { get; set; }
        public static void UserSignedOff()
        {
            UserManager u = new UserManager();
            if (EventManager.id == 0)
            {
                Console.WriteLine("User is signing off from a login screen");
            }
            else
            {
                u.UnsignUser(id, null);
                Console.WriteLine("User is signing off");
            }
        }

        public static void UserSignedOn()
        {
            UserManager u = new UserManager();

            u.SignUser(id, null);
            Console.WriteLine("User is signing on");
        }    

        public static void MessageSent(User recipient)
        {
            recipient.messageReceived = true;
        }   

        public static void setID(int id)
        {
            EventManager.id = id;
        }
    }
}

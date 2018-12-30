using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WT_DataManager.Classes
{  
   public class Friend
   {
        public string imageBase64Code;
        public string username;
        public string message;

        public Friend(string img, string username, string message)
        {
            imageBase64Code = img;
            this.username = username;
            this.message = message;
        }
   }
    
}
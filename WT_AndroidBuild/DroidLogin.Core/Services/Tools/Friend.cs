using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core.Services.Tools
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

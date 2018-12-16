using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core.Services.Tools
{
    public class Message
    {
        public string author;
        public string receiver;
        public string textContent;

        public Message() { }

        public Message(string author, string receiver, string textContent)
        {
            this.author = author;
            this.receiver = receiver;
            this.textContent = textContent;
        }
    }
}

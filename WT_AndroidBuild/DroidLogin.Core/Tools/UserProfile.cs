﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core.Tools
{
    public class UserProfile
    {
        public string picBase64;
        public string username;
        public string description;
        public List<string> testList;

        public UserProfile()
        {
        }

        public UserProfile(string picBase64, string username, string description, List<string> testList)
        {
            this.picBase64 = picBase64;
            this.username = username;
            this.description = description;
            this.testList = testList;
        }
    }
}

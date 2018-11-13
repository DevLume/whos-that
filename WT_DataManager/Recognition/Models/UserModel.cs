using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recognition.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string passHash { get; set; }
        public string gender { get; set; }
        public bool online { get; set; }
        public string ImageUri { get; set; }
    }
}

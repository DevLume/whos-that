using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recognition.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PassHash { get; set; }
        public string Gender { get; set; }
        public bool Online { get; set; }
        public string ImageUri { get; set; }
    }
}

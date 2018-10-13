using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Whos_that
{
    interface ISecurityManager
    {
        String HashPassword(string text, string password);
        String DehashPassword(string text, string password);
        String ChangePassword(); //Still not implemented
        bool RemindPassword(string email);
    }
}

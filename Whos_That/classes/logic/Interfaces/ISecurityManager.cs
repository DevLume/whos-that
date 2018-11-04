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
        string HashString(string text, string password);
        string DehashString(string text, string password);
        string ChangePassword(); //Still not implemented
        bool RemindPassword(string email);
    }
}

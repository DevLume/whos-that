using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Whos_that;

namespace Whos_That.Tests
{
    public class UserManagerTests
    {
        [Fact]
        public void GetUser_ShouldReturnUser()
        {
            User wantedUser = new User(17, "test","test@maul.com", "DzQsQiCMRgpqBcfiw50stA==", "unspecified");

            UserManager userman = new UserManager();
            User actualUser = userman.GetUser("test");

            Assert.Equal(wantedUser, actualUser);
        }
    }
}

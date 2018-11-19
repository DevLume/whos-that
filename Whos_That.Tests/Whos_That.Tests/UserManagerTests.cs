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
        private UserManager userman = new UserManager();
        [Fact]
        public void GetUserByUsername_ShouldReturnUser()
        {
            User wantedUser = new User(3, "test1", "test1@maul.com", "passhash1", "unspecified    ");

            User actualUser = userman.GetUser("test1");

            Assert.Equal(wantedUser, actualUser);
        }

        [Fact]
        public void GetUserByID_ShouldReturnUser()
        {
            User wantedUser = new User(3, "test1", "test1@maul.com", "passhash1", "unspecified    ");

            User actualUser = userman.GetUser(3);

            Assert.Equal(wantedUser, actualUser);
        }

        [Fact]
        public void checkIfUserExists_ShouldReturnTrue()
        {
            string username = "test1";
            bool wantedResult = true;

            bool actualResult = userman.checkIfUserExists(username);

            Assert.Equal(wantedResult, actualResult);
        }

        [Fact]
        public void checkIfUserExists_ShouldReturnFalse()
        {
            string username = "noSuchUsernameAccount";
            bool wantedResult = false;

            bool actualResult = userman.checkIfUserExists(username);

            Assert.Equal(wantedResult, actualResult);
        }

        
        [Fact]
        public void ListUsers_ShouldReturnUserList()
        {
            User u1 = new User(3, "test1", "test1@maul.com", "passhash1", "unspecified    ");
            User u2 = new User(4, "test2", "test2@maul.com", "passhash2", "unspecified    ");
            User u3 = new User(5, "test3", "test3@maul.com", "passhash3", "unspecified    ");

            List<User> wantedResult = new List<User>();
            wantedResult.Add(u1);
            wantedResult.Add(u2);
            wantedResult.Add(u3);
            List<User> actualResult = userman.ListUsers();

            Assert.Equal(wantedResult, actualResult);
        }

        [Fact]
        public void ListOnlineUsers_ShouldReturnOnlineUser()
        {
            User u1 = new User(3, "test1", "test1@maul.com", "passhash1", "unspecified    ");

            List<User> wantedResult = new List<User>();
            wantedResult.Add(u1);

            List<User> actualResult = userman.ListOnlineUsers();

            Assert.Equal(wantedResult, actualResult);
        }
        [Fact]
        public void NewUser_ShouldCreateNewUser()
        {
            User newUser = new User(0, "test4", "test4@maul.com", "passhash4", "none");
            bool wantedResult = true;

            bool actualResult = userman.NewUser(newUser);

            Assert.Equal(wantedResult, actualResult);
        }

        [Fact]
        public void RemoveUser_ShouldRemoveUser()
        {
            string username = "test4";
            bool wantedResult = true;

            bool actualResult = userman.RemoveUser(username);

            Assert.Equal(wantedResult, actualResult);
        }

        [Fact]
        public void RemoveUser_ShouldReturnFalse()
        {
            string username = "test69";
            bool wantedResult = false;

            bool actualResult = userman.RemoveUser(username);

            Assert.Equal(wantedResult, actualResult);
        }

    }
}

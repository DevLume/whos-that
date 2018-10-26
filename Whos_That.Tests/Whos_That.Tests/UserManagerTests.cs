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
            User wantedUser = new User(17, "test", "test@maul.com", "DzQsQiCMRgpqBcfiw50stA==", "unspecified");

            User actualUser = userman.GetUser("test");

            Assert.Equal(wantedUser, actualUser);
        }

        [Fact]
        public void GetUserByID_ShouldReturnUser()
        {
            User wantedUser = new User(17, "test", "test@maul.com", "DzQsQiCMRgpqBcfiw50stA==", "unspecified");

            User actualUser = userman.GetUser(17);

            Assert.Equal(wantedUser, actualUser);
        }

        [Fact]
        public void checkIfUserExists_ShouldReturnTrue()
        {
            string username = "test";
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

        //I Guess we'll need to separate database into production and test tables
        /*
        [Fact]
        public void ListUsers_ShouldReturnUserList()
        {
            User u1 = new User(1, "test1", "test1@mail.com", "passhash1", "none");
            User u2 = new User(2, "test2", "test2@mail.com", "passhash2", "none");
            User u3 = new User(3, "test3", "test3@mail.com", "passhash3", "none");

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
            User u1 = new User(1, "test1", "test1@mail.com", "passhash1", "none");

            List<User> wantedResult = new List<User>();
            wantedResult.Add(u1);

            List<User> actualResult = userman.ListOnlineUsers();

            Assert.Equal(wantedResult, actualResult);
        }
        [Fact]
        public void NewUser_ShouldCreateNewUser()
        {
            User newUser = new User(0, "usernamas", "usernamoemailas@comas.lt", "usernamopasswordohashas", "nepasakysiu");
            bool wantedResult = true;

            bool actualResult = userman.NewUser(newUser);

            Assert.Equal(wantedResult, actualResult);
        }
        */
    }
}

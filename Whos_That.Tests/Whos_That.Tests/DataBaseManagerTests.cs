using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Whos_that;

namespace Whos_That.Tests
{
    public class DataBaseManagerTests
    {
        private TestDataBaseManager dataman = new TestDataBaseManager();

        [Fact]
        public void GetUserDataDBWithUsername_ShouldReturnUserData()
        {
            UserData wantedData = new UserData(1,"test1","test1@maul.com", "passhash1", "unspecified    ", true);

            UserData actualData =  dataman.GetUserData("test1");

            Assert.Equal(wantedData, actualData);
        }

        [Fact]
        public void GetUserDataDBWithID_ShouldReturnUserData()
        {
            UserData wantedData = new UserData(1, "test1", "test1@maul.com", "passhash1", "unspecified    ", true);

            UserData actualData = dataman.GetUserData(1);

            Assert.Equal(wantedData, actualData);
        }

        [Fact]
        public void GetUserDataDBWithEmail_ShouldReturnUserData()
        {
            UserData wantedData = new UserData(1, "test1", "test1@maul.com", "passhash1", "unspecified    ", true);

            UserData actualData = dataman.GetUserDataByEmail("test1@maul.com");

            Assert.Equal(wantedData, actualData);
        }
    }
}

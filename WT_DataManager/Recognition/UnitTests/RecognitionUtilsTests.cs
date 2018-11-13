using FakeItEasy;
using NUnit.Framework;
using Recognition.Utilities;
using Recognition.Wrappers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recognition.UnitTests
{
    public class RecognitionUtilsTests
    {
        [Test]
        public void GetStream_ShouldReturnExpected()
        {
            //Arrange
            byte[] fakeBytes = new byte[1000];
            var fakeWebClientFacttory = A.Fake<ICustomWebClientFactory>();
            var fakeWebClient = fakeWebClientFacttory.Create();
            A.CallTo(() => fakeWebClient.DownloadData("https://static.tvtropes.org/pmwiki/pub/images/young_joseph_joestar_anime.png")).Returns(fakeBytes);

            //Act
            var recognitionUtils = new RecognitionUtils()
            {
                WebClient = fakeWebClient
            };
            var result = recognitionUtils.GetStream("https://static.tvtropes.org/pmwiki/pub/images/young_joseph_joestar_anime.png");

            //Assert
            var resultBytes = result.ToArray();

            resultBytes.ShouldBe(fakeBytes);

            A.CallTo(() => fakeWebClient.DownloadData("https://static.tvtropes.org/pmwiki/pub/images/young_joseph_joestar_anime.png")).MustHaveHappenedOnceExactly();
        }
    }
}

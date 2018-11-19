using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using WT_TestManager.TestManagement;
using WT_TestManager.TestManagement.Tools;

namespace WT_TestManager.Controllers
{
    public class UserTestController : ApiController
    {
        [Route("api/userTest/Get")]
        [HttpGet]
        [ResponseType(typeof(List<Question>))]
        public HttpResponseMessage Get(string author, string title)
        {
            DirectoryManager dirman = new DirectoryManager();
            TestManager testman = new TestManager(dirman);

            List<Question> questions = testman.GetTestData(author, title);

            var json = JsonConvert.SerializeObject(questions);
            var res = Request.CreateResponse(HttpStatusCode.OK);
            res.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return res;
        }

        [Route("api/userTest/Create")]
        [HttpPost]
        public HttpResponseMessage Create([FromBody]string serTest)
        {
            DirectoryManager dirman = new DirectoryManager();
            TestManager testman = new TestManager(dirman);

            try
            {
                Test test = JsonConvert.DeserializeObject<Test>(serTest);

                testman.CreateTest(test.author, test.title, test.GetQuestions());

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex);
            }
        }

        [Route("api/userTest/Createt")]
        [HttpPost]
        public bool Createt([FromBody]string login)
        {
            if (login == "loginas") return true;
            else return false;

            
        }
    }
}
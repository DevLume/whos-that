using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WT_TestManager.TestManagement;
using WT_TestManager.TestManagement.Tools;

namespace WT_TestManager.Controllers
{
    public class StatisticsController : ApiController
    {
        [Route("api/stat/submitRes")]
        [HttpPost]
        public HttpResponseMessage SubmitResult([FromBody]string testResJSON)
        {
            DirectoryManager dirman = new DirectoryManager();
            TestManager testman = new TestManager(dirman);
            TestResultManager testResMan = new TestResultManager(dirman);
            try
            {
                ResultToSubmit resultToSubmit = JsonConvert.DeserializeObject<ResultToSubmit>(testResJSON);

                testman.SubmitTestResults(resultToSubmit.authorName,
                    "otherResults", resultToSubmit.testTitle, 
                    string.Concat(resultToSubmit.correctAnswerCount,
                    "/", resultToSubmit.questionCount), resultToSubmit.guessingUserName);

                testman.SubmitTestResults(resultToSubmit.guessingUserName,
                   "personalResults", resultToSubmit.testTitle,
                   string.Concat(resultToSubmit.correctAnswerCount,
                   "/", resultToSubmit.questionCount), resultToSubmit.authorName);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
       
        }
    }
}
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

        [Route("api/stat/get")]
        [HttpGet]
        public HttpResponseMessage PersonalStatistics_Full(string username)
        {
            DirectoryManager dirman = new DirectoryManager();
            StatisticsManager statman = new StatisticsManager(dirman);

            Stat stat = statman.GetStat(username);

            try
            {          
                var json = JsonConvert.SerializeObject(stat);

                var res = Request.CreateResponse(HttpStatusCode.OK);
                res.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                return res;
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }           
        }
    }
}
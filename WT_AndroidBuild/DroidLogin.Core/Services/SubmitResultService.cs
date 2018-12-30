///Test result submitting service, 
///sending http requests to test management api
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Droid.Core.Tools;
using Newtonsoft.Json;

namespace Droid.Core.Services
{
    public class SubmitResultService : ISubmitResultService
    {
        public async Task<Tuple<bool, string>> SubmitResults(TestResult tr) 
        {
            HttpClient client = new HttpClient();
            tr.testTitle += ".txt";
           
            var json = JsonConvert.SerializeObject(tr);

            client.BaseAddress = new Uri("http://10.3.1.158:8086/api/stat/submitRes");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("", json)
            });

            var requestResult = await client.PostAsync("/api/stat/submitRes", content);
            string resultContent = await requestResult.Content.ReadAsStringAsync();
            if (requestResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new Tuple<bool, string>(true, string.Format("Your result is " + tr.correctAnswerCount  + "out of " + tr.questionCount));
            }
            else
            {
                return new Tuple<bool, string>(false, "Something went wrong, we could not process your results");
            }
        }
    }    
}

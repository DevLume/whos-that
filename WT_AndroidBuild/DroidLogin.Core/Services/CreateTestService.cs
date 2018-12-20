using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Droid.Core.Tools;
using Newtonsoft.Json;

namespace Droid.Core.Services
{
    public class CreateTestService : ICreateTestService
    {
        public async Task<Tuple<bool, string>> SendCreateTestRequest(string title, string author, Test test)
        {
            HttpClient client = new HttpClient();
            test.title += ".txt";
            var json = JsonConvert.SerializeObject(test);

            client.BaseAddress = new Uri("http://10.3.1.158:8086/api/userTest/Create");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("", json)
            });

            var result = await client.PostAsync("/api/userTest/Create", content);
            string resultContent = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new Tuple<bool, string>(true, "You shall create your test");
            }
            else
            {
                return new Tuple<bool, string>(false, "You shall not create your test");

            }
        }
    }
}

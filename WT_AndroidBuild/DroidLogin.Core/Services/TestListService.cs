using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public class TestListService : ITestListService
    {
        public async Task<Tuple<List<string>, string>> ListTests(string author)
        {
            HttpClient client = new HttpClient();

            List<string> articles;
            HttpResponseMessage response = await client.GetAsync("http://192.168.8.102:8086/api/userTest/List?author="+author);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return new Tuple<List<string>, string>(null, "Either such user not found, or he did not make any tests");
            }

            using (HttpContent content = response.Content)
            {
                string respBody = await response.Content.ReadAsStringAsync();

                articles = JsonConvert.DeserializeObject<List<string>>(respBody);
            }

            return new Tuple<List<string>, string>(articles, null);
        }
    }
}

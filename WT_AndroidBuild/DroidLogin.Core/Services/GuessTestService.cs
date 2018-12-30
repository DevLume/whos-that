using Droid.Core.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public class GuessTestService : IGuessTestService
    {
        public async Task<Tuple<bool, List<Question>>> GetTestToSolve(string title, string author)
        {
            var client = new HttpClient();
            List<Question> articles;
            HttpResponseMessage response = await client.GetAsync("http://10.3.1.158:8086/api/userTest/Get?author=" + author +"&title="+title +".txt");
            response.EnsureSuccessStatusCode();

            using (HttpContent content = response.Content)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                //Console.WriteLine(responseBody);

                articles = JsonConvert.DeserializeObject<List<Question>>(responseBody);       
            }
            return new Tuple<bool, List<Question>>(true, articles);
        }       
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Droid.Core.Tools;
using Newtonsoft.Json;

namespace Droid.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        public async Task<Tuple<string, Stat>> GetStatistics(string username)
        {
            HttpClient client = new HttpClient();

            Stat stat;
            HttpResponseMessage response = await client.GetAsync("http://10.3.1.158:8086/api/stat/get?username=" + username);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return new Tuple<string, Stat>("Something went wrong", null);
            }

            using (HttpContent content = response.Content)
            {
                string respBody = await response.Content.ReadAsStringAsync();

                stat = JsonConvert.DeserializeObject<Stat>(respBody);
            }
            return new Tuple<string, Stat>(null, stat);
        }
    }
}

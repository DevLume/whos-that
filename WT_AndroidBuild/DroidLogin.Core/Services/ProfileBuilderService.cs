using Droid.Core.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public class ProfileBuilderService : IProfileBuilderService
    {
        public async Task<bool> UpdateProfile(UserProfile profile)
        {
            HttpClient client = new HttpClient();

            var json = JsonConvert.SerializeObject(profile);

            client.BaseAddress = new Uri("http://10.3.1.158:8087/api/profile/set");
            /* var content = new FormUrlEncodedContent(new[]
             {
                 new KeyValuePair<string, string>("", json)
             });*/

            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
          
            var result = await client.PostAsync("/api/profile/set", content);
            string resultContent = await result.Content.ReadAsStringAsync();

            if (result.StatusCode == System.Net.HttpStatusCode.OK || result.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

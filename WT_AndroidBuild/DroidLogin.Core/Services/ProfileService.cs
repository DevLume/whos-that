using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Droid.Core.Tools;
using Newtonsoft.Json;

namespace Droid.Core.Services
{
    public class ProfileService : IProfileService
    {
        public async Task<UserProfile> GetUserProfile(string username)
        {
            HttpClient client = new HttpClient();
            UserProfile uprofile = null;
            HttpResponseMessage response = await client.GetAsync("http://10.3.1.158:8087/api/profile/get?username="+username);

            response.EnsureSuccessStatusCode();

            using (HttpContent content = response.Content)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                uprofile = JsonConvert.DeserializeObject<UserProfile>(responseBody);
            }
            return uprofile;
        }
    }
}

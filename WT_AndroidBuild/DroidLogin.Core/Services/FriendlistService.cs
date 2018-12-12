using Droid.Core.Services.Tools;
using Droid.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public class FriendlistService : IFriendlistService
    {
        public async Task<Tuple<bool, List<Friend>>> GetFriendlist(string username)
        {
            HttpClient client = new HttpClient();

            List<Friend> articles;
            HttpResponseMessage response = await client.GetAsync("http://192.168.8.102:8087/api/Friendlist/get?username=" + username);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return new Tuple<bool, List<Friend>>(false, null);
            }

            using (HttpContent content = response.Content)
            {
                string respBody = await response.Content.ReadAsStringAsync();

                articles = JsonConvert.DeserializeObject<List<Friend>>(respBody);
            }

            return new Tuple<bool, List<Friend>>(true, articles);

        }
    }
}

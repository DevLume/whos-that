using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public class FriendRqService : IFriendRqService
    {
        public async Task<bool> AddFriend(string sender, string receiver)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://10.3.1.158:8087/api/Friendlist/set?sender=" + sender +"&receiver=" +receiver);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}

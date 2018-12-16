using Droid.Core.Services.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public class MessagingService : IMessagingService
    {
        public List<string> ListMessages(string receiverName)
        {
            throw new NotImplementedException();
        }

        public async void ReadMessage(string receiverName, string senderName)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://192.168.8.102:8087/api/messaging/read?receiverName= " +
                receiverName + "&senderName" + senderName);
        }

        public async Task<bool> SendMessage(string sender, string receiver, string messageData)
        {
            HttpClient client = new HttpClient();

            Message message = new Message(sender, receiver, messageData);
            var json = JsonConvert.SerializeObject(message);

            client.BaseAddress = new Uri("http://192.168.8.102:8087/api/messaging/send");
            var content = new FormUrlEncodedContent(new[]
            {
              new KeyValuePair<string, string>("",json)  
            });

            var result = await client.PostAsync("/api/messaging/send", content);
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

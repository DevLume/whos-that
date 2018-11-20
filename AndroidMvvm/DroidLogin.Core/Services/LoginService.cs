using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public class LoginService : ILoginService
    {
        public event GuiMessageManager.TransmitMessage onResponseReceived;
        private GuiMessageManager GuiMessger = new GuiMessageManager();

        public LoginService()
        {
            onResponseReceived += GuiMessger.TransmitHttpMessage;
        }

        public async Task<Tuple<bool, string>> SendLoginRequest(string username, string password)
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format("https://wtdatamanager.azurewebsites.net/api/Account/Login?username=" + username + "&password=" + password));
            HttpResponseMessage httpResponse = null;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpResponse = await client.GetAsync(uri);
            string responseMessage = "temp";
            bool pass = false;
            if (httpResponse != null)
            {
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    return new Tuple<bool, string>(false, "Internal server error, please try again");
                }
                pass = onResponseReceived(httpResponse, out responseMessage);
                return new Tuple<bool, string>(pass, responseMessage);
            }
            else
            {
                return new Tuple<bool, string>(false, "You shall not pass!");
            }
        }
    }
}

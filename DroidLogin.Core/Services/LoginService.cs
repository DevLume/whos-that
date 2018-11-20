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
            Cryptor crypt = new Cryptor();
            string cipher = crypt.GetRandomString(8);

            string u = crypt.HashString(username, cipher);
            string p = crypt.HashString(password, cipher);

            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format("https://wtdatamanager1.azurewebsites.net/api/Account/Login?username=" + cipher + u + "&password=" + cipher + p));
            HttpResponseMessage httpResponse = null;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpResponse = await client.GetAsync(uri);
            string responseMessage = "temp";
            bool pass = false;
            if (httpResponse != null)
            {
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

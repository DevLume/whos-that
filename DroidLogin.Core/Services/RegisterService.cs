using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services
{
    public class RegisterService : IRegisterService
    {
        public event GuiMessageManager.TransmitMessage onResponseReceived;

        private GuiMessageManager GuiMessgr = new GuiMessageManager();
        public RegisterService()
        {
            onResponseReceived += GuiMessgr.TransmitHttpMessage;
        }

        public async Task<Tuple<bool, string>> SendRegisterRequest(string username, string password, string email)
        {  
            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format("https://wtdatamanager1.azurewebsites.net/api/Account/Register?username=" + username  + "&password=" + password  + "&email=" + email ));
            HttpResponseMessage httpResponse;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpResponse = await client.GetAsync(uri);
            string mesg;
            if (httpResponse != null)
            {
                if (httpResponse.IsSuccessStatusCode || httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    bool pass = onResponseReceived(httpResponse, out mesg);
                    return new Tuple<bool, string>(pass, mesg);
                }
                else if (httpResponse.StatusCode == System.Net.HttpStatusCode.BadGateway ||
                   httpResponse.StatusCode == System.Net.HttpStatusCode.GatewayTimeout ||
                   httpResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    return new Tuple<bool, string>(false, "Internal server error, please try again");
                }
                else
                {
                    return new Tuple<bool, string>(false, "You shall not register!");
                }
            }
            else
            {
                return new Tuple<bool, string>(false, "You shall not register!");
            }
        }
    }
}

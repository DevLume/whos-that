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
            var uri = new Uri(string.Format("https://wtdatamanager1.azurewebsites.net/api/Account/Register?username=" + username + "&password=" + password + "&email=" + email));
            HttpResponseMessage response;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response = await client.GetAsync(uri);
            string mesg;
            if (response != null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    return new Tuple<bool, string>(false, "Internal server error, please try again");
                }
                bool pass = onResponseReceived(response, out mesg);
                return new Tuple<bool, string>(pass, mesg);
            }
            else
            {
                return new Tuple<bool, string>(false, "You shall not pass!");
            }
        }
    }
}

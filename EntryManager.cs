using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace Whos_that
{
    public class EntryManager
    {     
        public event GuiMessageManager.TransmitMessage onResponseReceived;
        private GuiMessageManager GuiMessenger = new GuiMessageManager();
       
        public EntryManager()
        {
            onResponseReceived += GuiMessenger.TransmitHttpMessage;
        }

        public async void SendRegisterRequest(string username, string password, string email, Context context)
        {
            Cryptor crypt = new Cryptor();
            string cipher = crypt.GetRandomString(8);

            string u = crypt.HashString(username, cipher);
            string p = crypt.HashString(password, cipher);
            string e = crypt.HashString(email, cipher);

            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format("https://wtdatamanager.azurewebsites.net/api/Account/Register?username=" + cipher + u + "&password=" + cipher + p + "&email=" + cipher + e));
            HttpResponseMessage response;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response = await client.GetAsync(uri);

            if (response != null)
            {
                onResponseReceived(response, context);
            }
        }

        public async void SendLoginRequest(string username, string password, Context context)
        {
            Cryptor crypt = new Cryptor();
            string cipher = crypt.GetRandomString(8);

            string u = crypt.HashString(username, cipher);
            string p = crypt.HashString(password, cipher);

            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format("https://wtdatamanager.azurewebsites.net/api/Account/Login?username=" + cipher + u + "&password=" + cipher + p));
            HttpResponseMessage response = null;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            response = await client.GetAsync(uri);

            if (response != null)
            {
                onResponseReceived(response, context);
            }
        }
    }
}
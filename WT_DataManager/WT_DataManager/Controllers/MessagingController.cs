using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Whos_that;
using WT_DataManager.Classes;

namespace WT_DataManager.Controllers
{
    public class MessagingController : ApiController
    {
        public MessagingController() { }
        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("api/messaging/send")]
        public HttpResponseMessage SendMessage([FromBody]string message)
        {
            UserManager userman = new UserManager();

            try {
                Message messg = JsonConvert.DeserializeObject<Message>(message);

                User receiver = userman.GetUser(messg.receiver);
                User sender = userman.GetUser(messg.author);

                sender.SendMessage(receiver, messg.textContent); // + media content, but not implemented

                return Request.CreateResponse(System.Net.HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.Forbidden, ex);
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("api/messaging/list")]
        public HttpResponseMessage ListMessages(string receiverName)
        {
            UserManager userman = new UserManager();
            User u = userman.GetUser(receiverName);
            List<string> result = new List<string>();

            foreach (Tuple<string, string> t in u.ListMessages())
            {
                string s = t.Item1 + ": " + t.Item2;
                result.Add(s);
            }

            var json = JsonConvert.SerializeObject(result);
            var res = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            res.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return res;
        }

        [AcceptVerbs("POST")]
        [HttpGet]
        [Route("api/messaging/read")]
        public HttpResponseMessage ReadMessage(string receiverName, string senderName)
        {
            UserManager userman = new UserManager();
            User receiver = userman.GetUser(receiverName);
            User sender = userman.GetUser(senderName);

            receiver.MarkMessageAsRead(sender.id);
            return Request.CreateResponse(System.Net.HttpStatusCode.Accepted);
        }
    }
}
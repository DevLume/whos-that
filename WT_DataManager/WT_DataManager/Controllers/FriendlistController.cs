using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Whos_that;
using WT_DataManager.Classes;

namespace WT_DataManager.Controllers
{
    public class FriendlistController : ApiController
    {
        UserManager userman = new UserManager();

        SecurityManager secman = new SecurityManager();

        public FriendlistController() { }

        [AcceptVerbs("GET")]
        [Route("api/Friendlist/get")]
        [HttpGet]
        public HttpResponseMessage GetFriendlist(string username)
        {
            User loggedUser = userman.GetUser(username);
            List<User> friendlist = loggedUser.ListFriends();
            List<Tuple<string, string>> messages = loggedUser.ListMessages();
            List<Friend> wrappedFriendlist = new List<Friend>();

            foreach (User u in friendlist)
            {
                Friend f = new Friend(Convert.ToBase64String(u.userpic), u.username,"  ");
                wrappedFriendlist.Add(f);
            }

            foreach (Friend f in wrappedFriendlist)
            {
                foreach (Tuple<string, string> t in messages)
                {
                    if (f.username == t.Item1)
                    {
                        f.message = t.Item2;
                    }
                }
            }

            var json = JsonConvert.SerializeObject(wrappedFriendlist);
            var res = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            res.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return res;
        }
 
        [Route("api/Friendlist/test")]
        [HttpGet]
        public HttpResponseMessage test(string username)
        {
            string rootpath = string.Concat(HttpContext.Current.Server.MapPath(@"\"),@"\catz");
            DirectoryInfo d = new DirectoryInfo(rootpath);
            FileInfo[] files = d.GetFiles("*.jpg");

            List<Friend> result = new List<Friend>();

            foreach (FileInfo file in files)
            {
                //string[] temp = file.Name.Split('.');
                using (Image img = Image.FromFile(string.Concat(rootpath, @"\", file)))
                {
                    using (MemoryStream mem = new MemoryStream())
                    {
                        img.Save(mem, img.RawFormat);
                        byte[] imgBytes = mem.ToArray();

                        string base64string = Convert.ToBase64String(imgBytes);

                        Friend f = new Friend(base64string,"kot", "meow");
                        result.Add(f);
                    }
                }                 
            }

            var json = JsonConvert.SerializeObject(result);
            var res = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            res.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return res;
        }

    }
}
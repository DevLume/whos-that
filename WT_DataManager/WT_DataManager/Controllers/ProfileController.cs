using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Whos_that;
using WT_DataManager.Classes;

namespace WT_DataManager.Controllers
{
    public class ProfileController : ApiController
    {
        [Route("api/profile/get")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(string username)
        {
            UserManager userman = new UserManager();
            UserProfile userProfile = await userman.GetUserProfile(username);

            var json = JsonConvert.SerializeObject(userProfile);
            var res = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            res.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return res;
        }

        [Route("api/profile/set")]
        [HttpPost]
        public HttpResponseMessage Set([FromBody]UserProfile profile)
        {
            UserManager userman = new UserManager();

            try
            {
                userman.SetUserProfile(profile);
            }
            catch (ArgumentNullException)
            {
                if (profile.description == null)
                {
                    profile.description = "none";
                }

                if (profile.picBase64 == null)
                {
                    profile.picBase64 = "none";
                }

                if (profile.testList == null)
                {
                    profile.testList = new List<string>();
                    profile.testList.Add("none");
                }

                userman.SetUserProfile(profile);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.Forbidden, ex);
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }
    }
}
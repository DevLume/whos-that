using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WT_DataManager.Models;

namespace WT_DataManager.Controllers
{  
    //Read-Write controller
    public class RWController : ApiController
    {
        [Route("api/delivery/Test")]
        [HttpGet, HttpPost]
        public HttpResponseMessage GetDeliveryItem(string testString = "api werkz")
        {
            return Request.CreateResponse<string>(HttpStatusCode.OK, testString);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Whos_that;
using WT_DataManager.Models;

namespace WT_DataManager.Controllers
{
    public class AccountController : ApiController
    {
        
        AccountManagerDB accman = new AccountManagerDB();
        public AccountController()
        { }


        [AcceptVerbs("GET", "POST")]
        [Route("api/Account")]
        [HttpPost]
        public HttpResponseMessage Register(string username, string password, string email)
        {
            bool result = false;
            string responseMessage;
            result = accman.CreateAccount(username, password, email, out responseMessage);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, responseMessage);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, responseMessage);
            }
        }

        [Route("api/Account/5")]
        [HttpGet]
        public HttpResponseMessage Login(string username, string password)
        {
            bool result = false;
            string responseMessage;
            result = accman.Login(username, password, out responseMessage);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, responseMessage);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, responseMessage);
            }
        }
    }
}

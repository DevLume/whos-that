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
        SecurityManager secman = new SecurityManager();
        public AccountController()
        { }


        [AcceptVerbs("GET", "POST")]
        [Route("api/Account/Register")]
        [HttpPost]
        public HttpResponseMessage Register(string username, string password, string email)
        {
            bool result = false;
            string responseMessage;
            result = accman.CreateAccount(username, password, email, out responseMessage);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, responseMessage);
            }
        }

        [Route("api/Account/Login")]
        [HttpGet]
        public HttpResponseMessage Login(string username, string password)
        {
            bool result = false;
            string responseMessage;
            result = accman.Login(username, password, out responseMessage);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, responseMessage);
            }
        }

        [Route("api/Account/Test")]
        [HttpGet]
        public HttpResponseMessage Test(string test)
        {
            string testString = $"your string is {test}";
            return Request.CreateResponse(HttpStatusCode.Accepted, testString);
        }

    }
}

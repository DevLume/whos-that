using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WT_DataManager.Models;

namespace WT_DataManager.Controllers
{
    [RoutePrefix("api/Login")]
    public class RWController : ApiController
    {
        dataEntities db = new dataEntities();
        // GET api/Login
        public string getString(string hotdog)
        {
            if (hotdog == "hotdog")
            {
                return "Hotdog!";
            }
            else
            {
                return "Not Hotdog!";
            }
        }

        [HttpPost]
        [Route("WEBREGISTER")]
        //POST: API/Login
        public HttpResponseMessage WebRegister(string username, string password)
        {
            //TODO: Rewrite this method to check for proper user data
            usersTestTable uTable = new usersTestTable();
            uTable.Name = username;
            uTable.PassHash = password;
            db.usersTestTables.Add(uTable);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Accepted, "Account created succesfully");
        }

        //GET API/Login
        [HttpGet]
        [Route("WEBLOGIN")]
        public HttpResponseMessage WebLogin(string username, string password)
        {
            //TODO: Rewrite this method to check for proper user data
            var user = db.usersTestTables.Where(x => x.Name == username && x.PassHash == password).FirstOrDefault();
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Please enter valid credentials");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, "Success");
            }
        }
    }
}

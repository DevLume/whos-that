using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Recognition.Models;
using Recognition.RecognitionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recognition.Controllers
{
    [Route("api/[controller]")]
    public class RecognitionController : Controller
    {
        private RecServices _recServices { get; set; } = new RecServices();

        /// <summary>
        /// Creates person group, only needs to be used once!
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("creategroup")]
        public async Task<ActionResult> CreateGroup()
        {
            return Ok(await _recServices.CreateGroup());
        }

        [HttpPost]
        [Route("insertperson")]
        public async Task<ActionResult> InsertPersonInRecognition([FromBody ]UserModel userModel)
        {
            var result = await _recServices.InsertPersonInToGroup(userModel);
            return Ok(result);
        }

        [HttpPost]
        [Route("identifyperson")]
        public async Task<ActionResult> IdentifyPerson([FromBody] UserModel userModel)
        {
            return Ok(await _recServices.Identify(userModel));
        }
    }
}

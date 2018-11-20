using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("creategroup")]
        public async Task<ActionResult> CreateGroup()
        {
            return Ok(await _recServices.CreateGroup());
        }
    }
}

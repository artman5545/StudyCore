using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebGateway
{
    [Route("api/[controller]")]
    [ApiController,AllowAnonymous]
    public class HelperController : ControllerBase
    {
        public IActionResult IP()
        {
            return Ok("");
        }
    }
}

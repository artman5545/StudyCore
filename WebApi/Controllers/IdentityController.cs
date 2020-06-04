using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("Identity")]
    [ApiController]
    [Authorize]
    public class IdentityController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(User.Claims.Select(e => new { e.Type, e.Value }));
        }

        [Route("getaaa")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Getaaa()
        {
            return new JsonResult( "aaa");
        }
    }
}
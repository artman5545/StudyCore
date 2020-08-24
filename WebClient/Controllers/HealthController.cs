using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    /// <summary>
    /// 心跳检查
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// 心跳检查
        /// </summary>
        /// <returns></returns>
        [HttpGet,AllowAnonymous]
        public IActionResult Check()
        {
            return Ok("OJBK");
        }
    }
}

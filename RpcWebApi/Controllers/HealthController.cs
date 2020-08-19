using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RpcWebApi.Controllers
{
    /// <summary>
    /// 检查健康接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// 健康检查接口
        /// </summary>
        [HttpGet, HttpPost, HttpDelete, HttpPut, AllowAnonymous]
        public IActionResult Check()
        {
            return Ok("OJBK");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RpcWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ojbk");
        }
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("ojbk");
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok("ojbk");
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("ojbk");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RpcWebApi.Controllers
{
    /// <summary>
    /// 检查健康接口
    /// </summary>
    public class HealthController : AbpController
    {
        /// <summary>
        /// 健康检查接口
        /// </summary>
        public IActionResult Check() => Ok("OJBK");
    }
}

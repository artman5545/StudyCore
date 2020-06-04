using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataManage.Models;
using DataManage.Service;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 用户数据接口
    /// </summary>
    [Area("System")]
    [Route("api/System/User")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        IUserService _us;
        
        public UserController(IUserService us)
        {
            _us = us;
        }

        /// <summary>
        /// 获取人员列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseMessage<IEnumerable<UserInfo>> Get(int pageIndex,int pageSize)
        {
            int total = 0;
            var result = _us.FindList(e => true,o=>o.Id,out total,true,pageIndex,pageSize);
            return CreateResult.For(result,total);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="ui"></param>
        [HttpPost]
        public ResponseMessage<object> Post(UserInfo ui)
        {
            _us.Add(ui);
            return CreateResult.For();
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="ui"></param>
        /// <returns></returns>
        [HttpPut]
        public ResponseMessage<object> PUT(UserInfo ui)
        {
            _us.Update(ui);
            return CreateResult.For();
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ResponseMessage<object> DELETE(int id)
        {
            _us.DelByQuery(e => id == e.Id);
            return CreateResult.For();
        }
    }
}
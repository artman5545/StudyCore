using Abp.AspNetCore.Mvc.Controllers;
using App.HttpHelper;
using DBAccess.Models;
using DBAccess.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbpWebApi.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Route("api/[controller]")]
    public class AdminInfoController : AbpController
    {
        readonly IAdministratorService _adminService;
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <param name="admin"></param>
        public AdminInfoController(IAdministratorService admin)
        {
            this._adminService = admin;
        }

        /// <summary>
        /// 获取人员列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseMessage<List<Guid>> Get(int pageIndex, int pageSize)
        {
            int total = 0;
            var result = _adminService.LoadEntities(e => true, o => o.Id, "asc", pageIndex, pageSize, out total).Select(e => e.Id).ToList();
            return CreateResult.For(result, total);
        }

        ///// <summary>
        ///// 新增用户
        ///// </summary>
        ///// <param name="ui"></param>
        //[HttpPost]
        //public ResponseMessage<object> Post(Administrator ui)
        //{
        //    _adminService.AddEntity(ui);
        //    return CreateResult.For();
        //}

        ///// <summary>
        ///// 修改用户
        ///// </summary>
        ///// <param name="ui"></param>
        ///// <returns></returns>
        //[HttpPut]
        //public ResponseMessage<object> PUT(Administrator ui)
        //{
        //    _adminService.UpdateEntity(ui);
        //    return CreateResult.For();
        //}

        ///// <summary>
        ///// 删除用户
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpDelete]
        //public ResponseMessage<object> DELETE(Guid id)
        //{
        //    _adminService.DeleteByWhere(e => id == e.Id);
        //    return CreateResult.For();
        //}
    }
}

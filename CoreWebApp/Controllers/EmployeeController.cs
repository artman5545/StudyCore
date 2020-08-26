using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DBModel.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.HttpHelper;
using CoreWebApp.Models;

namespace CoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employee)
        {
            this._employeeService = employee;
        }

        /// <summary>
        /// g111111
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseMessage<List<AEmployee>> Get()
        {
            var list = _employeeService.LoadEntities(e => true).Select(e => new AEmployee { Id = e.Id, Name = e.Name }).ToList();
            return CreateResult.For(list);
        }
    }
}

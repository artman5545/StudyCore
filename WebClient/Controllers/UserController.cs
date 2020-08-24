using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebClient.Mapping;
using WebClient.RpcServices;

namespace WebClient.Controllers
{
    /// <summary>
    /// test
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMyService _myService;
        /// <summary>
        /// test
        /// </summary>
        /// <param name="my"></param>
        public UserController(IMyService my)
        {
            this._myService = my;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MUserInfo> GetAsync(int id)
        {
            return await _myService.GetUserInfo(id).ResponseAsync;
        }
    }
}

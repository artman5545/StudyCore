using Abp.Dependency;
using DataManage.Mapping;
using MagicOnion;
using MagicOnion.Server;

namespace RpcWebApi.RpcServices
{
    /// <summary>
    /// 
    /// </summary>
    public class MyService : ServiceBase<IMyService>, IMyService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UnaryResult<MUserInfo> GetUserInfo(int id)
        {
            return UnaryResult(new MUserInfo { Id = id, UserName = "text", UserAccount = "213" });
        }
    }
}

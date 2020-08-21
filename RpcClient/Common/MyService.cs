using DataManage.Mapping;
using MagicOnion;
using MagicOnion.Server;

namespace RpcService.Common
{
    public class MyService : ServiceBase<IMyService>, IMyService
    {
        public UnaryResult<MUserInfo> GetUserInfo(int id)
        {
            return UnaryResult(new MUserInfo { Id = id, UserName = "text", UserAccount = "213" });
        }

    }
}

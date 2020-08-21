using Abp.Dependency;
using DataManage.Mapping;
using MagicOnion;

namespace RpcClient.RpcServices
{
    public interface IMyService : IService<IMyService>, ITransientDependency
    {
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UnaryResult<MUserInfo> GetUserInfo(int id);
    }
}

using Abp.Dependency;
using MagicOnion;
using RpcClient.Mapping;

namespace RpcClient.RpcServices
{
    /// <summary>
    /// 111
    /// </summary>
    public interface IMyService : IService<IMyService>
    {
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UnaryResult<MUserInfo> GetUserInfo(int id);
    }
}

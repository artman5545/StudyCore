using DataManage.Mapping;
using MagicOnion;

namespace RpcServer.Common
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

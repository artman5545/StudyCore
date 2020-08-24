using Abp.Dependency;
using MagicOnion;
using MagicOnion.Server;
using System;
using WebClient.Mapping;

namespace WebClient.RpcServices
{
    public interface IMyService : IService<IMyService>
    {
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UnaryResult<MUserInfo> GetUserInfo(int id);
    }

    public class MyService : ServiceBase<IMyService>, IMyService, ISingletonDependency
    {
        public UnaryResult<MUserInfo> GetUserInfo(int id)
        {
            throw new NotImplementedException();
        }
    }
}

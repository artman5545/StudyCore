using Abp.AspNetCore;
using Abp.Grpc.Client;
using Abp.Grpc.Client.Configuration;
using Abp.Grpc.Client.Extensions;
using Abp.Modules;

namespace WebClient.Provider
{
    /// <summary>
    /// 
    /// </summary>
    [DependsOn(typeof(AbpAspNetCoreModule), typeof(AbpGrpcClientModule))]
    public class MyAbpGrpcClientModule : AbpModule
    {
        public override void PreInitialize()
        {
            //发现模式
            //Configuration.Modules.UseGrpcClientForConsul(new ConsulRegistryConfiguration("127.0.0.1", 8500, null));
            //直联模式
            Configuration.Modules.UseGrpcClientForDirectConnection(new[]
            {
                new GrpcServerNode
                {
                    GrpcServiceName = "RpcWebApi",
                    GrpcServiceIp = "127.0.0.1",
                    GrpcServicePort = 19021
                }
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyAbpGrpcClientModule).Assembly);
        }
    }
}

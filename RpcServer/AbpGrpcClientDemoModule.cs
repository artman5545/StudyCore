using Abp.Grpc.Client;
using Abp.Grpc.Client.Configuration;
using Abp.Grpc.Client.Extensions;
using Abp.Grpc.Common.Configuration;
using Abp.Modules;
using RpcClient.RpcServices;

namespace RpcClient
{
    [DependsOn(typeof(AbpGrpcClientModule))]
    public class AbpGrpcClientDemoModule : AbpModule
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
            IocManager.RegisterAssemblyByConvention(typeof(AbpGrpcClientDemoModule).Assembly);
            //base.Initialize();
        }
    }
}

using Abp.Grpc.Client;
using Abp.Grpc.Client.Configuration;
using Abp.Grpc.Client.Extensions;
using Abp.Grpc.Common.Configuration;
using Abp.Modules;

namespace RpcClient
{
    [DependsOn(typeof(AbpGrpcClientModule))]
    public class AbpGrpcClientDemoModule : AbpModule
    {
        public override void PreInitialize()
        {
            //发现模式
            //Configuration.Modules.UseGrpcClientForConsul(new ConsulRegistryConfiguration("127.0.0.1", 19021, null));
            //直联模式
            Configuration.Modules.UseGrpcClientForDirectConnection(new[]
            {
                new GrpcServerNode
                {
                    GrpcServiceName = "WebServer",
                    GrpcServiceIp = "127.0.0.1",
                    GrpcServicePort = 5050
                }
            });
        }

        //public override void Initialize()
        //{
        //    IocManager.RegisterAssemblyByConvention(typeof(AbpGrpcClientDemoModule).Assembly);
        //    //base.Initialize();
        //}
    }
}

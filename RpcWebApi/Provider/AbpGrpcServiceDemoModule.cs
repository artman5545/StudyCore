using Abp.AspNetCore;
using Abp.Grpc.Server;
using Abp.Grpc.Server.Extensions;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpcWebApi.Provider
{
    /// <summary>
    /// 注册服务端到Consul服务
    /// </summary>
    [DependsOn(typeof(AbpAspNetCoreModule), typeof(AbpGrpcServerModule))]
    public class AbpGrpcServiceDemoModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.UseGrpcService(option =>
            {
                // GRPC 服务绑定的 IP 地址
                option.GrpcBindAddress = "0.0.0.0";
                // GRPC 服务绑定的 端口号
                option.GrpcBindPort = 19021;
                // 启用 Consul 服务注册
                option.UseConsul(consulOption =>
                {
                    // Consul 服务地址
                    consulOption.ConsulAddress = "127.0.0.1";
                    // Consul 服务端口号
                    consulOption.ConsulPort = 8500;
                    // 注册到 Consul 的服务名称
                    consulOption.RegistrationServiceName = "WebServer";
                    // 健康检查接口的端口号
                    consulOption.ConsulHealthCheckPort = 5000;
                    consulOption.ConsulHealthCheckAddress = "127.0.0.1";
                });
            })
            .AddRpcServiceAssembly(typeof(AbpGrpcServiceDemoModule).Assembly);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpGrpcServiceDemoModule).Assembly);
        }
    }
}

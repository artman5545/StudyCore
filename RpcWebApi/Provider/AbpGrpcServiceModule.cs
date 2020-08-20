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
    public class AbpGrpcServiceModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.UseGrpcService(option =>
            {
                // GRPC 服务绑定的 IP 地址
                option.GrpcBindAddress = "0.0.0.0";
                // GRPC 服务绑定的 端口号
                option.GrpcBindPort = 5001;
                // 启用 Consul 服务注册
                option.UseConsul(consulOption =>
                {
                    // Consul 服务注册地址
                    consulOption.ConsulAddress = "127.0.0.1";
                    // Consul 服务注册端口号
                    consulOption.ConsulPort = 8500;
                    // 注册到 Consul 的服务名称
                    consulOption.RegistrationServiceName = "RpcWebApi";
                    // 健康检查接口的端口号
                    consulOption.ConsulHealthCheckPort = 19021;
                    consulOption.ConsulHealthCheckAddress = "172.17.0.1";
                });
            })
            .AddRpcServiceAssembly(typeof(AbpGrpcServiceModule).Assembly);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpGrpcServiceModule).Assembly);
        }
    }
}

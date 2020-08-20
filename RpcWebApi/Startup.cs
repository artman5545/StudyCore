using Consul;
using Grpc.Core;
using MagicOnion;
using MagicOnion.Hosting;
using MagicOnion.HttpGateway.Swagger;
using MagicOnion.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.IO;
using IApplicationLifetime = Microsoft.AspNetCore.Hosting.IApplicationLifetime;

namespace RpcWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var magicOnionHost = MagicOnionHost.CreateDefaultBuilder()
            .UseMagicOnion(
                new MagicOnionOptions(isReturnExceptionStackTraceInErrorDetail: true),
                new ServerPort("127.0.0.1", 5002, ServerCredentials.Insecure))
            .UseConsoleLifetime()
            .Build();
            services.AddSingleton<MagicOnionServiceDefinition>(magicOnionHost.Services.GetService<MagicOnionHostedServiceDefinition>().ServiceDefinition);
            magicOnionHost.StartAsync();
            services.AddMvc(e => e.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //services.AddControllers();
            //services.AddAbp<AbpGrpcServiceModule>();

            services.AddCors(ops => ops.AddPolicy("cors", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MagicOnionServiceDefinition magicOnion, IApplicationLifetime  lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMagicOnionSwagger(magicOnion.MethodHandlers, new SwaggerOptions("MagicOnion.Server", "Swagger Integration Test", "/")
            {
                XmlDocumentPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "RpcWebApi.xml")
            });
            app.UseMagicOnionHttpGateway(magicOnion.MethodHandlers, new Channel("localhost:19021", ChannelCredentials.Insecure));


            //app.UseAbp();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            ServiceEntity serviceEntity = new ServiceEntity
            {
                IP = "192.168.21.95",
                Port = 5002,
                ServiceName = "RpcWebApi",
                ConsulIP = "127.0.0.1",
                ConsulPort = 8500
            };
            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://{serviceEntity.ConsulIP}:{serviceEntity.ConsulPort}"));//请求注册的 Consul 地址
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
                Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称为心跳间隔
                HTTP = $"http://{serviceEntity.IP}:{serviceEntity.Port}/health",//健康检查地址
                Timeout = TimeSpan.FromSeconds(5)
            };
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = Guid.NewGuid().ToString(),
                Name = serviceEntity.ServiceName,
                Address = serviceEntity.IP,
                Port = serviceEntity.Port,
                Tags = new[] { $"urlprefix-/{serviceEntity.ServiceName}" }//添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别
            };
            consulClient.Agent.ServiceRegister(registration).Wait();//服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();//服务停止时取消注册
            });
        }
    }
    public class ServiceEntity
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public string ServiceName { get; set; }
        public string ConsulIP { get; set; }
        public int ConsulPort { get; set; }
    }
}

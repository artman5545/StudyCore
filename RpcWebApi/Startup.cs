using Abp.AspNetCore;
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
using RpcWebApi.Provider;
using System;
using System.IO;

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
                new ServerPort("127.0.0.1", 19021, ServerCredentials.Insecure))
            .UseConsoleLifetime()
            .Build();
            services.AddSingleton<MagicOnionServiceDefinition>(magicOnionHost.Services.GetService<MagicOnionHostedServiceDefinition>().ServiceDefinition);
            magicOnionHost.StartAsync();
            services.AddMvc(e => e.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();

            services.AddCors(ops => ops.AddPolicy("cors", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            //return services.AddAbp<AbpGrpcServiceDemoModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            , MagicOnionServiceDefinition magicOnion
            , IHostApplicationLifetime lifetime
            )
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMagicOnionSwagger(magicOnion.MethodHandlers, new SwaggerOptions("MagicOnion.Server", "Swagger Integration Test", "/")
            {
                XmlDocumentPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "RpcWebApi.xml")
            });
            app.UseMagicOnionHttpGateway(magicOnion.MethodHandlers, new Channel("127.0.0.1:19021", ChannelCredentials.Insecure));


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

            #region ע�ᵽconsul
            ServiceEntity serviceEntity = new ServiceEntity
            {
                IP = "127.0.0.1",
                Port = 19021,
                ServiceName = "RpcWebApi",
                ConsulIP = "127.0.0.1",
                ConsulPort = 8500
            };
            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://{serviceEntity.ConsulIP}:{serviceEntity.ConsulPort}"));//����ע��� Consul ��ַ
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//����������ú�ע��
                Interval = TimeSpan.FromSeconds(10),//�������ʱ���������߳�Ϊ�������
                //HTTP = $"http://{serviceEntity.IP}:5000/api/values",//��������ַ
                HTTP = $"http://{serviceEntity.IP}:5000/health/check",
                Timeout = TimeSpan.FromSeconds(5)
            };
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = Guid.NewGuid().ToString(),//��Ⱥ�еĵ�����������
                Name = serviceEntity.ServiceName,//��Ⱥȡ����
                Address = serviceEntity.IP,
                Port = serviceEntity.Port,
                Tags = new[] { $"urlprefix-/{serviceEntity.ServiceName}" }//��� urlprefix-/servicename ��ʽ�� tag ��ǩ���Ա� Fabio ʶ��
            };
            consulClient.Agent.ServiceRegister(registration);//��������ʱע�ᣬ�ڲ�ʵ����ʵ����ʹ�� Consul API ����ע�ᣨHttpClient����

            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();//����ֹͣʱȡ��ע��
            });
            #endregion
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

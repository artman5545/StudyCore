using Abp.AspNetCore;
using Abp.Dependency;
using Consul;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using WebClient.RpcServices;
using Abp.AspNetCore;
using WebClient.Provider;

namespace WebClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<Channel>(e =>
            //{
            //    return new Channel("127.0.0.1", 5050, ChannelCredentials.Insecure);
            //});
            //services.AddSwaggerGen(ops =>
            //{
            //    ops.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "micro service demo",
            //        Description = "΢����ӿ�",
            //        //Contact = new Microsoft.OpenApi.Models.OpenApiContact
            //        //{
            //        //    Name = "demo",
            //        //    Email = "xxx@163.com",
            //        //    Url = new System.Uri("http://127.0.0.1")
            //        //}
            //    });
            //    ops.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebClient.xml"));
            //});
            //services.AddScoped<IMyService, MyService>();
            //IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            services.AddMvc();
            services.AddControllers();
            return services.AddAbp<MyAbpGrpcClientModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            app.UseAbp();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region swagger
            //app.UseSwagger();
            //app.UseSwaggerUI(ops =>
            //{
            //    ops.SwaggerEndpoint("/swagger/v1/swagger.json", "demo");
            //});
            #endregion

            #region consul
            //var httpCheck = new AgentServiceCheck()
            //{
            //    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(1),//����������ú�ע��
            //    Interval = TimeSpan.FromSeconds(10),//�������ʱ���������߳�Ϊ�������
            //    //HTTP = $"http://{serviceEntity.IP}:5000/api/values",//��������ַ
            //    HTTP = $"http://127.0.0.1:5060/api/Health",
            //    Timeout = TimeSpan.FromSeconds(5)
            //};
            //var registration = new AgentServiceRegistration()
            //{
            //    Checks = new[] { httpCheck },
            //    ID = Guid.NewGuid().ToString(),//��Ⱥ�еĵ�����������
            //    Name = "WebClient",//��Ⱥ����
            //    Address = "127.0.0.1",
            //    Port = 5060,
            //    Tags = new[] { $"urlprefix-/WebClient" }//��� urlprefix-/servicename ��ʽ�� tag ��ǩ���Ա� Fabio ʶ��
            //};
            //var consulClient = new ConsulClient(x => x.Address = new Uri("http://127.0.0.1:8500"));
            //consulClient.Agent.ServiceRegister(registration);
            //lifetime.ApplicationStopping.Register(() =>
            //{
            //    consulClient.Agent.ServiceDeregister(registration.ID);
            //});
            #endregion

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


}

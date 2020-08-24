using DataManage.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
namespace WebApi
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
            services.AddDbContextPool<coredbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("bimcon")),
                   poolSize: 64
               );
            AutoInjection(services);
            services.AddControllers();


            services.AddMvc(ops => ops.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            #region 验证凭证
            services.AddMvcCore().AddAuthorization();
            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(ops =>
                    {
                        ops.RequireHttpsMetadata = false;
                        ops.Authority = "https://localhost:44383";
                        ops.ApiName = "api1";//ApiResource匹配
                    });
            #endregion


            services.AddSwaggerGen(ops =>
            {
                ops.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TestCoreApi", Version = "v1" });

                ops.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebApi.xml"));
                ops.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataManage.xml"));
            });
            services.AddCors(ops => ops.AddPolicy("cors", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("cors");
            app.UseAuthentication();//鉴权

            app.UseAuthorization();//授权
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreWebApi");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapAreaControllerRoute(
                    name: "SystemManage",
                    areaName: "System",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }

        /// <summary>
        /// 自动注入
        /// </summary>
        /// <param name="services"></param>
        private void AutoInjection(IServiceCollection services)
        {
            //services.AddSingleton<coredbContext>();
            var types = System.Reflection.Assembly.Load("DataManage").GetTypes().Where(e => "DataManage.Service" == e.Namespace);
            var singletonInterfaceDependency = types.Where(e => e.IsInterface).ToList();
            foreach (var interfaceName in singletonInterfaceDependency)
            {
                var type = types.Where(t => t.GetInterfaces().Contains(interfaceName)).FirstOrDefault();
                if (type != null)
                {
                    services.AddScoped(interfaceName, e =>
                    {
                        return type.GetConstructors()[0].Invoke(new object[] { e.GetService<coredbContext>() });
                    });
                }
            }
            //using (var iServiceScope = services.BuildServiceProvider().CreateScope())
            //{
            //    using (var dbcontext = iServiceScope.ServiceProvider.GetRequiredService<coredbContext>())
            //    {
            //        //var mappingCollection = (StorageMappingItemCollection)dbcontext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            //        //mappingCollection.GenerateViews(new List<EdmSchemaError>());
            //    }
            //}
        }
    }
}

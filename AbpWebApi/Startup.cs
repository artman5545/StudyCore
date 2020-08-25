using Abp.AspNetCore;
using Abp.EntityFrameworkCore;
using DBAccess.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace AbpWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAbpDbContext<CoreDB>(conf =>
                conf.DbContextOptions.UseSqlServer(Configuration.GetConnectionString("bimcon"))
            );
            services.AddSwaggerGen(ops =>
            {
                ops.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "AbpWebApi", Version = "v1" });
                ops.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AbpWebApi.xml"));
            });
            services.AddControllers();
            return services.AddAbp<AbpWebApiModule>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAbp();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(ops =>
            {
                ops.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreWebApi");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapAreaControllerRoute(
                //    name: "SystemManage",
                //    areaName: "System",
                //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                //);
            });
        }
    }
}

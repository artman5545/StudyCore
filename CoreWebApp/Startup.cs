using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.BaseHelper;
using App.DBModel.Models;
using App.DBModel.Service;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CoreWebApp
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
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Core",
                });

                //c.IncludeXmlComments(Path.Combine(basePath, "Core.xml"), true);
                //c.IncludeXmlComments(Path.Combine(basePath, "Model.xml"), true);
            });

            services.AddDbContext<WorkDBContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:Default"]));
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            
            builder.RegisterAssemblyTypes(typeof(IBaseRepository<>).Assembly,typeof(IBaseService<>).Assembly)
                      .AsImplementedInterfaces()
                      .InstancePerDependency();
            //builder.RegisterAssemblyTypes()
            //    .Where(e=>e.Name.EndsWith("Service",StringComparison.OrdinalIgnoreCase))
            //          .AsImplementedInterfaces()
            //          .InstancePerDependency();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(e => typeof(ControllerBase).IsAssignableFrom(e) && e.Name.EndsWith("Controller")).PropertiesAutowired();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.AllowAnyMethod()
                       .SetIsOriginAllowed(_ => true)
                       .AllowAnyHeader()
                       .AllowCredentials();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API V1");
                c.RoutePrefix = "";
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

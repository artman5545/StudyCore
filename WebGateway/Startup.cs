using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Cache;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;
using System;

namespace WebGateway
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
            services.AddOcelot()
                .AddConsul()
                .AddCacheManager(e =>
                {
                    e.WithDictionaryHandle();//Ĭ���ֵ�洢
                })
                .AddPolly()//˲̬����
                ;
            //services.AddSingleton<IOcelotCache<CachedResponse>, MyCache>();//�滻Ĭ�ϻ���
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOcelot();
        }
    }

    /// <summary>
    /// �Զ��建�棬ʹ��redis
    /// </summary>
    public class MyCache : IOcelotCache<CachedResponse>
    {
        public void Add(string key, CachedResponse value, TimeSpan ttl, string region)
        {
            throw new NotImplementedException();
        }

        public void AddAndDelete(string key, CachedResponse value, TimeSpan ttl, string region)
        {
            throw new NotImplementedException();
        }

        public void ClearRegion(string region)
        {
            throw new NotImplementedException();
        }

        public CachedResponse Get(string key, string region)
        {
            throw new NotImplementedException();
        }
    }
}

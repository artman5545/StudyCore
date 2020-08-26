using Abp.AspNetCore;
using Abp.Configuration.Startup;
using Abp.Modules;
using DBAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace AbpWebApi
{
    /// <summary>
    /// 
    /// </summary>
    [DependsOn(typeof(AbpAspNetCoreModule),typeof(AbpDBAccessModule))]
    public class AbpWebApiModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Configuration.UnitOfWork.Timeout = TimeSpan.FromSeconds(5);
            Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

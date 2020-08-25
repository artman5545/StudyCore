using Abp.AspNetCore;
using Abp.Configuration.Startup;
using Abp.Modules;
using DBAccess;

namespace AbpWebApi
{
    /// <summary>
    /// 
    /// </summary>
    [DependsOn(typeof(AbpAspNetCoreModule))]
    public class AbpWebApiModule : AbpModule
    {
        /// <summary>
        /// 
        /// </summary>
        public override void PreInitialize()
        {
            Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpWebApiModule).Assembly);
        }
    }
}

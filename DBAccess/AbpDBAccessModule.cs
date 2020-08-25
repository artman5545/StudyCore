using Abp.Modules;
using App.DBHelper;
using DBAccess.Models;
using System;

namespace DBAccess
{
    [DependsOn(typeof(AbpDBHelperModule))]
    public class AbpDBAccessModule: AbpModule
    {
        //public override void PreInitialize()
        //{
        //    IocManager.Register<CoreDB>();
        //}
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpDBAccessModule).Assembly);
        }
    }
}

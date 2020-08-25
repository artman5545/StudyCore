using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DBHelper
{
    public class AbpDBHelperModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpDBHelperModule).Assembly);
        }
    }
}

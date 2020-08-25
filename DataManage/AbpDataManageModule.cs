using System;
using System.Collections.Generic;
using System.Text;
using Abp;
using Abp.Modules;
using DataManage.Models;

namespace DataManage
{
    public class AbpDataManageModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}

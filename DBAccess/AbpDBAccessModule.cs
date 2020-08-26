using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Uow;
using Abp.Modules;
using DBAccess.Models;
using DBAccess.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyModel.Resolution;
using System;
using System.Reflection;

namespace DBAccess
{
    //[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    public class AbpDBAccessModule: AbpModule
    {
        
        //public override void PreInitialize()
        //{
        //    IocManager.Register<CoreDB>();
        //}
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //IocManager.Register(typeof(IDbContextProvider<CoreDB>), typeof(UnitOfWorkDbContextProvider<CoreDB>), Abp.Dependency.DependencyLifeStyle.Transient);
        }
    }
}

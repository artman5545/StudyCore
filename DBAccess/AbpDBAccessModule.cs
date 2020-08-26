using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Uow;
using Abp.Modules;
using DBAccess.Models;
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
            
            IocManager.Register(typeof(IDbContextProvider<CoreDB>), typeof(UnitOfWorkDbContextProvider<CoreDB>), Abp.Dependency.DependencyLifeStyle.Transient);
            
        }
    }
}

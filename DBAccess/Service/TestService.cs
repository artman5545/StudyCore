using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using DBAccess.Service;
using App.DBHelper;
using Abp.Domain.Entities;
using DBAccess.Models;
using Abp.EntityFrameworkCore;

namespace DBAccess.Service
{
    public interface IAdministratorService : IAppRepository<DdutyDoctor, Guid>
    {
    }
    public class AdministratorService : AppRepository<DdutyDoctor, Guid>, IAdministratorService, ITransientDependency
    {
        public AdministratorService(IDbContextProvider<AbpDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

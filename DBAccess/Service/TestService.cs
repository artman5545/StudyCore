using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using DBAccess.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBAccess.Service
{
    public interface IAdministratorService : IBaseService<DdutyDoctor, Guid>
    {
    }
    public class AdministratorService : BaseService<DdutyDoctor, Guid>, IAdministratorService, ITransientDependency
    {
        public AdministratorService(IDbContextProvider<CoreDB> dbContextProvider) : base(dbContextProvider) { }
    }
}

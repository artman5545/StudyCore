using Abp.Application.Services;
using Abp.Dependency;
using App.DBHelper;
using DBAccess.Models;
using System;

namespace DBAccess.Service
{
    public interface IAdministratorService : IBaseService<Administrator, Guid>, IApplicationService { }
    public class AdministratorService : BaseService<Administrator, Guid>, IAdministratorService
    {
        public AdministratorService(IAppRepository<Administrator, Guid> r) : base(r) { }
    }
}

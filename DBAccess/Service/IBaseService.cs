using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Domain.Entities;
using App.DBHelper;

namespace DBAccess.Service
{
    public interface IBaseService<T, Tkey> : IAppRepository<T, Tkey>, IApplicationService where T : Entity<Tkey>
    {
    }
}

using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using App.DBHelper;
using DBAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DBAccess.Service
{
    public class BaseService<T, Tkey> : BaseRepository<CoreDB, T, Tkey> where T : Entity<Tkey>
    {

        public BaseService(IDbContextProvider<CoreDB> dbContextProvider)
        : base(dbContextProvider) { }
    }

    public class BaseService<T> : BaseService<T, Guid>, IBaseService<T, Guid> where T : Entity<Guid>
    {
        public BaseService(IDbContextProvider<CoreDB> dbContextProvider)
        : base(dbContextProvider) { }
    }
}

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
        : base(dbContextProvider)
        {
        }

        //public Task<int> AddAsync(T entity)
        //{
        //    return _dbContext.AddAsync(entity);
        //}

        //public T AddEntity(T entity)
        //{
        //    return _dbContext.AddEntity(entity);
        //}

        //public int AddRange(IEnumerable<T> entity)
        //{
        //    return _dbContext.AddRange(entity);
        //}

        //public Task<int> AddRangeAsync(IEnumerable<T> entities)
        //{
        //    return _dbContext.AddRangeAsync(entities);
        //}

        //public bool DelEntity(T entity)
        //{
        //    return _dbContext.DelEntity(entity);
        //}

        //public int DeleteByWhere(Expression<Func<T, bool>> where)
        //{
        //    return _dbContext.DeleteByWhere(where);
        //}

        //public bool DelRange(IEnumerable<T> entities)
        //{
        //    return _dbContext.DelRange(entities);
        //}

        //public bool ExcuteByTran(Func<T> func, out string msg)
        //{
        //    return _dbContext.ExcuteByTran(func, out msg);
        //}

        //public int ExecuteSqlCommand(string sql, params object[] objectparams)
        //{
        //    return _dbContext.ExecuteSqlCommand(sql, objectparams);
        //}

        //public int GetCount(Expression<Func<T, bool>> where)
        //{
        //    return _dbContext.GetCount(where);
        //}

        //public IList<TResult> GetListByJoin<T2, TResult, Tkey1, Tkey2>(Expression<Func<T, bool>> where, Expression<Func<T2, bool>> where2, Expression<Func<T, Tkey1>> outer, Expression<Func<T2, Tkey1>> inner, Expression<Func<T, IEnumerable<T2>, TResult>> resultSelector)
        //    where T2 : class
        //    where TResult : class
        //{
        //    return _dbContext.GetListByJoin<T2, TResult, Tkey1, Tkey2>(where, where2, outer, inner, resultSelector);
        //}

        //public IQueryable<T> LoadEntities(Expression<Func<T, bool>> where)
        //{
        //    return _dbContext.LoadEntities(where);
        //}

        //public IQueryable<T> LoadEntities<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby, string asc, int pageIndex, int pageSize, out int recordCount)
        //{
        //    return _dbContext.LoadEntities(where, orderby, asc, pageIndex, pageSize, out recordCount);
        //}

        //public T LoadEntity(Expression<Func<T, bool>> where)
        //{
        //    return _dbContext.LoadEntity(where);
        //}

        //public List<T> SqlQuery(string sql, params object[] objectparams)
        //{
        //    return _dbContext.SqlQuery(sql, objectparams);
        //}

        //public int UpdateEntities(Expression<Func<T, bool>> where, Action<T> action)
        //{
        //    return _dbContext.UpdateEntities(where, action);
        //}

        //public Task<int> UpdateEntitiesAsync(Expression<Func<T, bool>> where, Action<T> action)
        //{
        //    return _dbContext.UpdateEntitiesAsync(where, action);
        //}

        //public bool UpdateEntity(T entity)
        //{
        //    return _dbContext.UpdateEntity(entity);
        //}

        //public Task<int> UpdateEntityAsync(T entity)
        //{
        //    return _dbContext.UpdateEntityAsync(entity);
        //}
    }

    public class BaseService<T> : BaseService<T, Guid>, IBaseService<T, Guid> where T : Entity<Guid>
    {
        public BaseService(IDbContextProvider<CoreDB> dbContextProvider)
        : base(dbContextProvider)
        {
        }
    }
}

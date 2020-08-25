using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using App.DBHelper;
using Abp.Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using Abp.EntityFrameworkCore;
using DBAccess.Models;

namespace DBAccess.Service
{
    public class BaseService<T, Tkey> : AppRepository<T, Tkey>, IBaseService<T, Tkey> where T : Entity<Tkey>
    {
        public BaseService(IDbContextProvider<CoreDB> dbContextProvider):base(dbContextProvider)
        {
        }

        public Task<int> AddAsync(T entity)
        {
            return this.AddAsync(entity);
        }

        public T AddEntity(T entity)
        {
            return this.AddEntity(entity);
        }

        public int AddRange(IEnumerable<T> entity)
        {
            return this.AddRange(entity);
        }

        public Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            return this.AddRangeAsync(entities);
        }

        public bool DelEntity(T entity)
        {
            return this.DelEntity(entity);
        }

        public int DeleteByWhere(Expression<Func<T, bool>> where)
        {
            return this.DeleteByWhere(where);
        }

        public bool DelRange(IEnumerable<T> entities)
        {
            return this.DelRange(entities);
        }

        public bool ExcuteByTran(Func<T> func, out string msg)
        {
            return this.ExcuteByTran(func, out msg);
        }

        public int ExecuteSqlCommand(string sql, params object[] objectparams)
        {
            return this.ExecuteSqlCommand(sql, objectparams);
        }

        public int GetCount(Expression<Func<T, bool>> where)
        {
            return this.GetCount(where);
        }

        public IList<TResult> GetListByJoin<T2, TResult, Tkey1, Tkey2>(Expression<Func<T, bool>> where, Expression<Func<T2, bool>> where2, Expression<Func<T, Tkey1>> outer, Expression<Func<T2, Tkey1>> inner, Expression<Func<T, IEnumerable<T2>, TResult>> resultSelector)
            where T2 : class
            where TResult : class
        {
            return this.GetListByJoin<T2, TResult, Tkey1, Tkey2>(where, where2, outer, inner, resultSelector);
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> where)
        {
            return this.LoadEntities(where);
        }

        public IQueryable<T> LoadEntities<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby, string asc, int pageIndex, int pageSize, out int recordCount)
        {
            return this.LoadEntities(where, orderby, asc, pageIndex, pageSize, out recordCount);
        }

        public T LoadEntity(Expression<Func<T, bool>> where)
        {
            return this.LoadEntity(where);
        }

        public List<T> SqlQuery(string sql, params object[] objectparams)
        {
            return this.SqlQuery(sql, objectparams);
        }

        public int UpdateEntities(Expression<Func<T, bool>> where, Action<T> action)
        {
            return this.UpdateEntities(where, action);
        }

        public Task<int> UpdateEntitiesAsync(Expression<Func<T, bool>> where, Action<T> action)
        {
            return this.UpdateEntitiesAsync(where, action);
        }

        public bool UpdateEntity(T entity)
        {
            return this.UpdateEntity(entity);
        }

        public Task<int> UpdateEntityAsync(T entity)
        {
            return this.UpdateEntityAsync(entity);
        }
    }
}

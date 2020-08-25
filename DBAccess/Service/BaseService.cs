using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using App.DBHelper;
using Abp.Domain.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace DBAccess.Service
{
    public class BaseService<T, Tkey> : IBaseService<T, Tkey> where T : Entity<Tkey>
    {
        readonly IAppRepository<T, Tkey> _repository;
        public BaseService(IAppRepository<T, Tkey> r)
        {
            _repository = r;
        }

        public Task<int> AddAsync(T entity)
        {
            return _repository.AddAsync(entity);
        }

        public T AddEntity(T entity)
        {
            return _repository.AddEntity(entity);
        }

        public int AddRange(IEnumerable<T> entity)
        {
            return _repository.AddRange(entity);
        }

        public Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            return _repository.AddRangeAsync(entities);
        }

        public bool DelEntity(T entity)
        {
            return _repository.DelEntity(entity);
        }

        public int DeleteByWhere(Expression<Func<T, bool>> where)
        {
            return _repository.DeleteByWhere(where);
        }

        public bool DelRange(IEnumerable<T> entities)
        {
            return _repository.DelRange(entities);
        }

        public bool ExcuteByTran(Func<T> func, out string msg)
        {
            return _repository.ExcuteByTran(func, out msg);
        }

        public int ExecuteSqlCommand(string sql, params object[] objectparams)
        {
            return _repository.ExecuteSqlCommand(sql, objectparams);
        }

        public int GetCount(Expression<Func<T, bool>> where)
        {
            return _repository.GetCount(where);
        }

        public IList<TResult> GetListByJoin<T2, TResult, Tkey1, Tkey2>(Expression<Func<T, bool>> where, Expression<Func<T2, bool>> where2, Expression<Func<T, Tkey1>> outer, Expression<Func<T2, Tkey1>> inner, Expression<Func<T, IEnumerable<T2>, TResult>> resultSelector)
            where T2 : class
            where TResult : class
        {
            return _repository.GetListByJoin<T2, TResult, Tkey1, Tkey2>(where, where2, outer, inner, resultSelector);
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> where)
        {
            return _repository.LoadEntities(where);
        }

        public IQueryable<T> LoadEntities<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby, string asc, int pageIndex, int pageSize, out int recordCount)
        {
            return _repository.LoadEntities(where, orderby, asc, pageIndex, pageSize, out recordCount);
        }

        public T LoadEntity(Expression<Func<T, bool>> where)
        {
            return _repository.LoadEntity(where);
        }

        public List<T> SqlQuery(string sql, params object[] objectparams)
        {
            return _repository.SqlQuery(sql, objectparams);
        }

        public int UpdateEntities(Expression<Func<T, bool>> where, Action<T> action)
        {
            return _repository.UpdateEntities(where, action);
        }

        public Task<int> UpdateEntitiesAsync(Expression<Func<T, bool>> where, Action<T> action)
        {
            return _repository.UpdateEntitiesAsync(where, action);
        }

        public bool UpdateEntity(T entity)
        {
            return _repository.UpdateEntity(entity);
        }

        public Task<int> UpdateEntityAsync(T entity)
        {
            return _repository.UpdateEntityAsync(entity);
        }
    }
}

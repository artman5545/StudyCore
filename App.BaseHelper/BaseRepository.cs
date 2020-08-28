using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.BaseHelper
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class, new()
    {
        private readonly IDbContext _dbContext;

        public BaseRepository(IDbContext myDbContext)
        {
            this._dbContext = myDbContext;
        }

        #region add
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual T AddEntity(T t)
        {
            return _dbContext.Set<T>().Add(t).Entity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual ValueTask<EntityEntry<T>> AddAsync(T t)
        {
            return _dbContext.Set<T>().AddAsync(t);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual Task AddRangeAsync(IEnumerable<T> entities)
        {
            return _dbContext.Set<T>().AddRangeAsync(entities);
        }

        #endregion

        #region delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual void DelEntity(T t)
        {
            _dbContext.Entry(t).State = EntityState.Deleted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual void DelRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual void DeleteByWhere(Expression<Func<T, bool>> where)
        {
            LoadEntities(where).ForEachAsync(t =>
            {
                _dbContext.Entry(t).State = EntityState.Deleted;
            });
        }

        #endregion

        #region query
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual T LoadEntity(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where<T>(where).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public virtual async Task<T> FindAsync(params object[] keyValues)
        {
            return await _dbContext.Set<T>().FindAsync(keyValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<T> LoadEntities(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="asc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public virtual IQueryable<T> LoadEntities<Key>(Expression<Func<T, bool>> where, Expression<Func<T, Key>> orderby, string asc, int pageIndex, int pageSize, out int recordCount)
        {
            pageIndex -= 1;
            recordCount = GetCount(where);
            if (asc.Equals("asc"))
            {
                return _dbContext.Set<T>().Where(where).OrderBy(orderby).Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                return _dbContext.Set<T>().Where(where).OrderByDescending(orderby).Skip(pageIndex * pageSize).Take(pageSize);
            }
        }

        /// <summary>
        /// group by order by
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="Tkey"></typeparam>
        /// <typeparam name="Tkey2"></typeparam>
        /// <param name="where"></param>
        /// <param name="where2"></param>
        /// <param name="outer"></param>
        /// <param name="inner"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public virtual IList<TResult> GetListByJoin<T2, TResult, key, Tkey2>(Expression<Func<T, bool>> where, Expression<Func<T2, bool>> where2, Expression<Func<T, key>> outer, Expression<Func<T2, key>> inner, Expression<Func<T, IEnumerable<T2>, TResult>> resultSelector) where T2 : class where TResult : class
        {
            var query = _dbContext.Set<T>().Where(where);
            var query2 = _dbContext.Set<T2>().Where(where2);
            return query.GroupJoin(query2, outer, inner, resultSelector).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int GetCount(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where).Count();
        }

        #endregion

        #region update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual void UpdateEntity(T t)
        {
            _dbContext.Entry(t).State = EntityState.Modified;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual void UpdateEntities(Expression<Func<T, bool>> where, Action<T> action)
        {
            _dbContext.Set<T>().Where(where).ToList().ForEach(action);
        }

        #endregion

        #region  exec sql
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns></returns>
        public virtual List<T> SqlQuery(string sql, params object[] objectparams)
        {
            //return _dbContext.Set<T>().FromSqlRaw(sql, objectparams).ToList<T>();
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns></returns>
        public virtual int ExecuteSqlCommand(string sql, params object[] objectparams)
        {
            //return _dbContext.Database.ExecuteSqlRaw(sql, objectparams);
            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

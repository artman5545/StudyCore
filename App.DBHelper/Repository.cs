using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DBHelper
{
    public class AppRepository<T, TKey> : EfCoreRepositoryBase<AbpDbContext, T, TKey> where T : class, IEntity<TKey>
    {
        public AbpDbContext _dbContext;

        /// <summary>
        /// 数据库类型
        /// </summary>
        //private DatabaseType _dbType { get; set; }
        public AppRepository(IDbContextProvider<AbpDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            _dbContext = dbContextProvider.GetDbContext();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual T AddEntity(T t)
        {
            T entity = _dbContext.Set<T>().Add(t).Entity;
            _dbContext.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(T t)
        {
            _dbContext.Set<T>().Add(t);
            return _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual int AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            return _dbContext.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            return _dbContext.SaveChangesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual bool DelEntity(T t)
        {
            _dbContext.Entry(t).State = EntityState.Deleted;
            int result = _dbContext.SaveChanges();
            return result > 0 ? true : false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual bool DelRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            int result = _dbContext.SaveChanges();
            return result > 0 ? true : false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual Task<int> RemoveAsync(T t)
        {
            _dbContext.Entry(t).State = EntityState.Deleted;
            return _dbContext.SaveChangesAsync();
        }
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
        public virtual IQueryable<T> LoadEntities<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby, string asc, int pageIndex, int pageSize, out int recordCount)
        {
            pageIndex -= 1;
            recordCount = GetEntitiesCount(where);
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
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual int GetEntitiesCount(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Count(where);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual bool UpdateEntity(T t)
        {
            _dbContext.Entry(t).State = EntityState.Modified;
            int result = _dbContext.SaveChanges();
            return result > 0 ? true : false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task<int> UpdateEntityAsync(T t)
        {
            _dbContext.Entry(t).State = EntityState.Modified;
            var task = _dbContext.SaveChangesAsync();
            return await task;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual int UpdateEntities(Expression<Func<T, bool>> where, Action<T> action)
        {
            _dbContext.Set<T>().Where(where).ToList().ForEach(action);
            return _dbContext.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual async Task<int> UpdateEntitiesAsync(Expression<Func<T, bool>> where, Action<T> action)
        {
            _dbContext.Set<T>().Where(where).ToList().ForEach(action);
            var task = _dbContext.SaveChangesAsync();
            return await task;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual int DeleteByWhere(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> list = LoadEntities(where);
            foreach (T item in list)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
            }
            int result = _dbContext.SaveChanges();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns></returns>
        public virtual List<T> SqlQuery(string sql, params object[] objectparams)
        {
            return _dbContext.Set<T>().FromSqlRaw(sql, objectparams).ToList<T>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns></returns>
        public virtual int ExecuteSqlCommand(string sql, params object[] objectparams)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, objectparams);
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
        public virtual IList<TResult> GetListByJoin<T2, TResult, Tkey, Tkey2>(Expression<Func<T, bool>> where, Expression<Func<T2, bool>> where2, Expression<Func<T, Tkey>> outer, Expression<Func<T2, Tkey>> inner, Expression<Func<T, IEnumerable<T2>, TResult>> resultSelector) where T2 : class where TResult : class
        {
            var query = _dbContext.Set<T>().Where(where);
            var query2 = _dbContext.Set<T2>().Where(where2);
            return query.GroupJoin(query2, outer, inner, resultSelector).ToList();
        }

        /// <summary>
        /// 事务执行
        /// </summary>
        /// <param name="func"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual bool ExcuteByTran(Func<T> func, out string msg)
        {
            msg = string.Empty;
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    func();
                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    msg = e.Message;
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public int GetCount(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where).Count();
        }
    }
}

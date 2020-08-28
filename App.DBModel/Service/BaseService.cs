using App.BaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DBModel.Service
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        protected IUnitOfWork uow;
        protected IBaseRepository<T> _repository;

        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<T> currentRepository)
        {
            this.uow = unitOfWork;
            this._repository = currentRepository;
        }

        #region add
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual int AddEntity(T t)
        {
            _repository.AddEntity(t);
            return uow.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual Task<int> AddAsync(T t)
        {
            _repository.AddEntity(t);
            return uow.SaveChangesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual int AddRange(IEnumerable<T> entities)
        {
            _repository.AddRange(entities);
            return uow.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            _repository.AddRange(entities);
            return uow.SaveChangesAsync();
        }
        #endregion

        #region delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual int DelEntity(T t)
        {
            _repository.DelEntity(t);
            return uow.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual int DelRange(IEnumerable<T> entities)
        {
            _repository.DelRange(entities);
            return uow.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual Task<int> RemoveAsync(T t)
        {
            _repository.DelEntity(t);
            return uow.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual int DeleteByWhere(Expression<Func<T, bool>> where)
        {
            _repository.DeleteByWhere(where);
            return uow.SaveChanges();
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
            return _repository.LoadEntity(where);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public virtual async Task<T> FindAsync(params object[] keyValues)
        {
            return await _repository.FindAsync(keyValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<T> LoadEntities(Expression<Func<T, bool>> where)
        {
            return _repository.LoadEntities(where);
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
            return _repository.LoadEntities<Key>(where, orderby, asc, pageIndex, pageSize, out recordCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int GetCount(Expression<Func<T, bool>> where)
        {
            return _repository.GetCount(where);
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
            return _repository.GetListByJoin<T2, TResult, key, Tkey2>(where, where2, outer, inner, resultSelector);
        }
        #endregion

        #region update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual int UpdateEntity(T t)
        {
            _repository.UpdateEntity(t);
            return uow.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task<int> UpdateEntityAsync(T t)
        {
            _repository.UpdateEntity(t);
            return await uow.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual int UpdateEntities(Expression<Func<T, bool>> where, Action<T> action)
        {
            _repository.UpdateEntities(where, action);
            return uow.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual async Task<int> UpdateEntitiesAsync(Expression<Func<T, bool>> where, Action<T> action)
        {
            _repository.UpdateEntities(where, action);
            return await uow.SaveChangesAsync();
        }

        #endregion

        #region exec sql
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns></returns>
        public virtual List<T> SqlQuery(string sql, params object[] objectparams)
        {
            return _repository.SqlQuery(sql, objectparams);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns></returns>
        public virtual int ExecuteSqlCommand(string sql, params object[] objectparams)
        {
            return _repository.ExecuteSqlCommand(sql, objectparams);
        }
        #endregion


    }
}

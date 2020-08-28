using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DBModel.Service
{
    public interface IBaseService<T> where T : class, new()
    {

        #region add
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int AddEntity(T t);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> AddAsync(T t);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int AddRange(IEnumerable<T> entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<int> AddRangeAsync(IEnumerable<T> entities);

        #endregion

        #region delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int DelEntity(T t);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int DelRange(IEnumerable<T> entities);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> RemoveAsync(T t);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int DeleteByWhere(Expression<Func<T, bool>> where);

        #endregion

        #region query
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T LoadEntity(Expression<Func<T, bool>> where);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<T> FindAsync(params object[] keyValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> where);

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
        IQueryable<T> LoadEntities<Key>(Expression<Func<T, bool>> where, Expression<Func<T, Key>> orderby, string asc, int pageIndex, int pageSize, out int recordCount);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int GetCount(Expression<Func<T, bool>> where);

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
        IList<TResult> GetListByJoin<T2, TResult, key, Tkey2>(Expression<Func<T, bool>> where, Expression<Func<T2, bool>> where2, Expression<Func<T, key>> outer, Expression<Func<T2, key>> inner, Expression<Func<T, IEnumerable<T2>, TResult>> resultSelector) where T2 : class where TResult : class;
        #endregion

        #region update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int UpdateEntity(T t);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> UpdateEntityAsync(T t);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        int UpdateEntities(Expression<Func<T, bool>> where, Action<T> action);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<int> UpdateEntitiesAsync(Expression<Func<T, bool>> where, Action<T> action);

        #endregion

        #region exec sql
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns></returns>
        List<T> SqlQuery(string sql, params object[] objectparams);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, params object[] objectparams);
        #endregion
    }
}

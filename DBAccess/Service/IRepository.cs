using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DBAccess.Service
{
    public interface IAppRepository<T, TKey>: IRepository where T :  Entity<TKey>
    {
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddEntity(T entity);
        /// <summary>
        /// 新增实体（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddAsync(T entity);

        /// <summary>
        /// 新增实体列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int AddRange(IEnumerable<T> entity);
        /// <summary>
        /// 新增实体列表
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<int> AddRangeAsync(IEnumerable<T> entities);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DelEntity(T entity);

        /// <summary>
        /// 删除实体列表
        /// </summary>
        /// <param name="entities">实体列表</param>
        /// <returns></returns>
        bool DelRange(IEnumerable<T> entities);

        /// <summary>
        /// 根据加载实体
        /// </summary>
        /// <param name="where">lamda表达式</param>
        /// <returns></returns>
        T LoadEntity(Expression<Func<T, bool>> where);

        /// <summary>
        /// 根据条件加载实体列表
        /// </summary>
        /// <param name="where">lamda表达式</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> where);

        /// <summary>
        /// 加载自己定义排序分页实体列表
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="asc">asc/desc</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        IQueryable<T> LoadEntities<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby, string asc, int pageIndex, int pageSize, out int recordCount);


        /// <summary>
        /// 查询实体数量
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int GetCount(Expression<Func<T, bool>> where);
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateEntity(T entity);
        /// <summary>
        /// 异步更新实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> UpdateEntityAsync(T t);
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        int UpdateEntities(Expression<Func<T, bool>> where, Action<T> action);
        /// <summary>
        /// 异步批量更新数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<int> UpdateEntitiesAsync(Expression<Func<T, bool>> where, Action<T> action);
        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int DeleteByWhere(Expression<Func<T, bool>> where);
        /// <summary>
        /// 使用sql脚本查询实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns></returns>
        List<T> SqlQuery(string sql, params object[] objectparams);

        /// <summary>
        /// 执行sql脚本
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns>@@rowcount</returns>
        int ExecuteSqlCommand(string sql, params object[] objectparams);
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
        IList<TResult> GetListByJoin<T2, TResult, Tkey, Tkey2>(Expression<Func<T, bool>> where, Expression<Func<T2, bool>> where2, Expression<Func<T, Tkey>> outer, Expression<Func<T2, Tkey>> inner, Expression<Func<T, IEnumerable<T2>, TResult>> resultSelector) where T2 : class where TResult : class;
        /// <summary>
        /// 事务
        /// </summary>
        /// <param name="func"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool ExcuteByTran(Func<T> func, out string msg);
    }

    public interface IAppRepository<T> : IRepository where T : Entity
    {
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddEntity(T entity);
        /// <summary>
        /// 新增实体（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddAsync(T entity);

        /// <summary>
        /// 新增实体列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int AddRange(IEnumerable<T> entity);
        /// <summary>
        /// 新增实体列表
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<int> AddRangeAsync(IEnumerable<T> entities);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DelEntity(T entity);

        /// <summary>
        /// 删除实体列表
        /// </summary>
        /// <param name="entities">实体列表</param>
        /// <returns></returns>
        bool DelRange(IEnumerable<T> entities);

        /// <summary>
        /// 根据加载实体
        /// </summary>
        /// <param name="where">lamda表达式</param>
        /// <returns></returns>
        T LoadEntity(Expression<Func<T, bool>> where);

        /// <summary>
        /// 根据条件加载实体列表
        /// </summary>
        /// <param name="where">lamda表达式</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> where);

        /// <summary>
        /// 加载自己定义排序分页实体列表
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="asc">asc/desc</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        IQueryable<T> LoadEntities<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderby, string asc, int pageIndex, int pageSize, out int recordCount);


        /// <summary>
        /// 查询实体数量
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int GetCount(Expression<Func<T, bool>> where);
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateEntity(T entity);
        /// <summary>
        /// 异步更新实体
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> UpdateEntityAsync(T t);
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        int UpdateEntities(Expression<Func<T, bool>> where, Action<T> action);
        /// <summary>
        /// 异步批量更新数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        Task<int> UpdateEntitiesAsync(Expression<Func<T, bool>> where, Action<T> action);
        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int DeleteByWhere(Expression<Func<T, bool>> where);
        /// <summary>
        /// 使用sql脚本查询实体
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns></returns>
        List<T> SqlQuery(string sql, params object[] objectparams);

        /// <summary>
        /// 执行sql脚本
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objectparams"></param>
        /// <returns>@@rowcount</returns>
        int ExecuteSqlCommand(string sql, params object[] objectparams);
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
        IList<TResult> GetListByJoin<T2, TResult, Tkey, Tkey2>(Expression<Func<T, bool>> where, Expression<Func<T2, bool>> where2, Expression<Func<T, Tkey>> outer, Expression<Func<T2, Tkey>> inner, Expression<Func<T, IEnumerable<T2>, TResult>> resultSelector) where T2 : class where TResult : class;
        /// <summary>
        /// 事务
        /// </summary>
        /// <param name="func"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool ExcuteByTran(Func<T> func, out string msg);
    }
}


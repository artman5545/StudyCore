using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataManage.Service
{
    public interface IBaseBLL<T> where T : class, new()
    {
        int Add(T t);
        int AddList(IEnumerable<T> t);

        void Del(T t);

        void DelList(IEnumerable<T> t);

        int DelByQuery(Expression<Func<T, bool>> query);
        int Update(T t);

        int UpdateList(IEnumerable<T> list);

        T Find(int id);

        IEnumerable<T> FindList(Expression<Func<T, bool>> query);

        IEnumerable<T> FindList(Expression<Func<T, bool>> query, Expression<Func<T, dynamic>> order);
        IEnumerable<T> FindList<KEY>(Expression<Func<T, bool>> query, Expression<Func<T, KEY>> order, out int total, bool sort, int pageIndex, int pageSize);
        IEnumerable<T> FindList(Expression<Func<T, bool>> query, IEnumerable<Expression<Func<T, dynamic>>> order, out int total, bool sort, int pageIndex, int pageSize);

        IEnumerable<T> QueryBySql(string sql);


    }
}

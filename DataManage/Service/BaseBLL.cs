using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataManage.Service
{

    public class BaseBLL<T> : IBaseBLL<T> where T : class, new()
    {
        protected DbContext _db;
        public BaseBLL(DbContext c)
        {
            _db = c;
        }
        public int Add(T t)
        {
            _db.Add(t);
            return _db.SaveChanges();
        }

        public int AddList(IEnumerable<T> t)
        {
            throw new NotImplementedException();
        }

        public void Del(T t)
        {
            throw new NotImplementedException();
        }

        public int DelByQuery(Expression<Func<T, bool>> query)
        {
            var list = _db.Set<T>().Where(query);
            _db.Set<T>().RemoveRange(list);
            return _db.SaveChanges();
        }

        public void DelList(IEnumerable<T> t)
        {
            throw new NotImplementedException();
        }

        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindList(Expression<Func<T, bool>> lambda)
        {
            return _db.Set<T>().Where(lambda).ToList();
        }

        public IEnumerable<T> FindList(Expression<Func<T, bool>> query, Expression<Func<T, dynamic>> order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindList<key>(Expression<Func<T, bool>> query, Expression<Func<T, key>> order, out int total, bool sort, int pageIndex, int pageSize)
        {
            //var func=EF.CompileQuery((DbContext context,Expression<Func<T,bool>> qy, Expression<Func<T, key>> od) => context.Set<T>().Where(qy).OrderByDescending(order).Skip((pageIndex - 1)).Take(pageSize));
            //total = GetTotal(query);
            //return func(_db, query, order);
            var func = EF.CompileQuery((DbContext context) => context.Set<T>().Where(query).OrderBy(order).Skip((pageIndex)).Take(pageSize));
            total = GetTotal(query);
            return func(_db);
        }

        public IEnumerable<T> FindList(Expression<Func<T, bool>> query, IEnumerable<Expression<Func<T, dynamic>>> order, out int total, bool sort, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> QueryBySql(string sql)
        {
            throw new NotImplementedException();
        }

        public int Update(T t)
        {
            _db.Update(t);
            return _db.SaveChanges();
        }

        public int UpdateList(IEnumerable<T> list)
        {
            throw new NotImplementedException();
        }

        public int GetTotal(Expression<Func<T, bool>> query)
        {
            return _db.Set<T>().Where(query).Count();
        }

    }

}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.BaseHelper
{
    public interface IUnitOfWork
    {
        DbContext GetDbContext();

        Task<int> SaveChangesAsync();

        int SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext myDbContext;

        public UnitOfWork(DbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public DbContext GetDbContext()
        {
            return myDbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await myDbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return myDbContext.SaveChanges();
        }
    }
}

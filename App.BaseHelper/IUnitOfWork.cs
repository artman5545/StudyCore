using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.BaseHelper
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContext GetDbContext();

        Task<int> SaveChangesAsync();

        int SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext myDbContext;

        public UnitOfWork(IDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public IDbContext GetDbContext()
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

        public void Dispose()
        {
            if (myDbContext != null)
            {
                myDbContext.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}

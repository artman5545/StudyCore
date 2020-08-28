using Microsoft.EntityFrameworkCore;
using System;

namespace App.BaseHelper
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();

        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        where TEntity : class;
    }
}

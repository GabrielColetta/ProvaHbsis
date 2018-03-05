using Library.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Library.Persistence.Context
{
    public interface IContext : IDisposable
    {
        DbSet<Book> Books { get; set; }
        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
        Task<int> SaveChangesAsync();
    }
}

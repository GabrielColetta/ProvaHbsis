using Library.Domain.Entities;
using Library.Persistence.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Library.Persistence.Context
{
    public class ApplicationContext : DbContext, IContext
    {
        public ApplicationContext()
            : base("DefaultConnectionString")
        {
            Database.SetInitializer<ApplicationContext>(null);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new BookConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

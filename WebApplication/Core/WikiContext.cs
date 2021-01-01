using Microsoft.EntityFrameworkCore;
using WebApplication.Core.Entity;

namespace WebApplication.Core
{
    public class WikiContext : DbContext
    {
        private string ConnectionString;
        
        public DbSet<Customer> Customers { get; set; }

        public WikiContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
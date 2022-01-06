using Microsoft.EntityFrameworkCore;
using Way2Commerce.Data.EntityConfigurations;
using Way2Commerce.Data.Models;

namespace Way2Commerce.Data.Contexts
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
        }
    }
}

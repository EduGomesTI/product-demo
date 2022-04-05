using Microsoft.EntityFrameworkCore;
using Product.Domain.Categories.Entites;

namespace Product.Data.DataContext
{
    public class MemoryContext : DbContext
    {
        public MemoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .Ignore(c => c.ValidationResult);
        }



    }
}

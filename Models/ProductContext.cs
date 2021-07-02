using Microsoft.EntityFrameworkCore;

namespace EFCore4.Models
{
    public class ProductContext : DbContext
    {   

        public ProductContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Category>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().HasMany(x => x.Product).WithOne(x => x.Category);
            modelBuilder.Entity<Category>().HasData(new Category{
                Id = 1,
                Name = "Category 1",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Product 1",
                CategoryId = 1,
            });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories {get; set;}

    }
}
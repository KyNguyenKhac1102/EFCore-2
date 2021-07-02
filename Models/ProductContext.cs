using Microsoft.EntityFrameworkCore;

namespace EFCore4.Models
{
    public class ProductContext : DbContext
    {   

        public ProductContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Category>().Property(x => x.CategoryId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().HasMany(x => x.Product).WithOne(x => x.Category);
            modelBuilder.Entity<Category>().HasData(new Category{
                CategoryId= 1,
                CategoryName = "Category 1",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "Product 1",
                CategoryId = 1,
            });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories {get; set;}

    }
}
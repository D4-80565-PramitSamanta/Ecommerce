using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.ProductService.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel() { Id = 1, Name = "Laptop", Price = 80000, Quantity = 5 });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel() { Id = 2, Name = "Mobile", Price = 10000, Quantity = 10 });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel() { Id = 3, Name = "Tab", Price = 30000, Quantity = 2 });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}

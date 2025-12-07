using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.OrderService.Data
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderModel>().HasData(new OrderModel() { Id = 1, Name = "Laptop", Price = 80000, Quantity = 5 });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<OrderModel> Orders { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using OrderViewer.Service.OrderAPI.Models;

namespace OrderViewer.Service.OrderAPI.ContextData
{
    public class OrderService_DbContext  : DbContext
    {
        public OrderService_DbContext(DbContextOptions<OrderService_DbContext> options): base(options)
        {
        }
        // Define DbSets for your entities here
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity mappings
            // Relationships: One Order → Many Products
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);


            //Add indeces
            modelBuilder.Entity<Order>()
                .HasIndex(o => o.CreatedAt);
            
            modelBuilder.Entity<Order>()
                .HasIndex(o => o.Status);

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.Customer);

            //Add initial data for Orders
            var orderId = Guid.NewGuid();
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = orderId,
                Customer = "Lewis Hamilton ",
                Status = OrderStatus.Pending,
                Total = 10000.00m,
                CreatedAt = DateTime.UtcNow
            });

            // Seed initial products linked to that order
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    OrderId = orderId,
                    Name = "Laptop",
                    Quantity = 1,
                    UnitPrice = 8500m
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    OrderId = orderId,
                    Name = "Mouse",
                    Quantity = 2,
                    UnitPrice = 250m
                }
                ,
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    OrderId = orderId,
                    Name = "Keyboard",
                    Quantity = 2,
                    UnitPrice = 500m
                }
            );
        }
    }
}

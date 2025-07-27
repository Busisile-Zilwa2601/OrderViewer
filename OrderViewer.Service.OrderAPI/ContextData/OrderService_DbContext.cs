using Microsoft.EntityFrameworkCore;
using OrderViewer.Service.OrderAPI.Models;

namespace OrderViewer.Service.OrderAPI.ContextData
{
    public class OrderService_DbContext: DbContext
    {
        public OrderService_DbContext(DbContextOptions<OrderService_DbContext> options): base(options)
        {
        }
        // Define DbSets for your entities here
        public DbSet<Order> Orders { get; set; }
        // public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity mappings

            //Add indeces
            modelBuilder.Entity<Order>()
                .HasIndex(o => o.CreatedAt);
            
            modelBuilder.Entity<Order>()
                .HasIndex(o => o.Status);

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.Customer);

            //Add initial data for Orders
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = Guid.NewGuid(),
                Customer = "John Doe",
                Status = OrderStatus.Pending,
                Total = 100.00m,
                CreatedAt = DateTime.UtcNow
            });
        }
    }
}

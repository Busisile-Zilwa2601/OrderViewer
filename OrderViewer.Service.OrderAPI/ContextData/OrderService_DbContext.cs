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

            var random = new Random();
            var customers = new[]
            {
                "Lewis Hamilton","Banale","Max Verstappen", "Sebastian Vettel",
                "Charles Leclerc", "Lando Norris", "Fernando Alonso",
                "Daniel Ricciardo", "Valtteri Bottas", "Shaka"
            };

            var productNames = new[]
            {
                "Laptop", "Mouse", "Keyboard", "Monitor", "Headset", "USB Drive",
                "Printer", "Webcam", "Tablet", "Smartphone"
            };

            var orders = new List<Order>();
            var products = new List<Product>();

            //Add initial data for Orders
            // Seed initial products linked to that order
            for (int i = 0; i < 50; i++)
            {
                var orderId = Guid.NewGuid();
                var customer = customers[random.Next(customers.Length)];
                var status = (OrderStatus)random.Next(0, 4);
                var createdAt = DateTime.UtcNow.AddDays(-random.Next(0, 90)); // last 90 days

                // Generate 1-5 random products
                int numProducts = random.Next(1, 6);
                decimal orderTotal = 0m;

                for (int j = 0; j < numProducts; j++)
                {
                    var quantity = random.Next(1, 5);
                    var unitPrice = Math.Round((decimal)(random.Next(100, 5000) + random.NextDouble()), 2); // price range
                    orderTotal += quantity * unitPrice;

                    products.Add(new Product
                    {
                        ProductId = Guid.NewGuid(),
                        OrderId = orderId,
                        Name = productNames[random.Next(productNames.Length)],
                        Quantity = quantity,
                        UnitPrice = unitPrice
                    });
                }

                orders.Add(new Order
                {
                    OrderId = orderId,
                    Customer = customer,
                    Status = status,
                    Total = orderTotal,
                    CreatedAt = createdAt
                });
            }

            modelBuilder.Entity<Order>().HasData(orders.ToArray());
            modelBuilder.Entity<Product>().HasData(products.ToArray());
        }
    }
}

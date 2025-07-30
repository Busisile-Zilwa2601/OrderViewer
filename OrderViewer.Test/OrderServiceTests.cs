using Xunit;
using Moq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderViewer.Service.OrderAPI.ContextData;
using OrderViewer.Service.OrderAPI.Dtos;
using OrderViewer.Service.OrderAPI.Models;
using OrderViewer.Service.OrderAPI.Services;

namespace OrderViewer.Test
{
    public class OrderServiceTests
    {
        private readonly IMapper _mapper;
        private readonly DbContextOptions<OrderService_DbContext> _dbOptions;
        private readonly ILogger<OrderService> _logger;

        public OrderServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>().ReverseMap();
            });

            _mapper = config.CreateMapper();

            _dbOptions = new DbContextOptionsBuilder<OrderService_DbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique DB for isolation
                .Options;

            _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<OrderService>();
        }

        [Fact]
        public async Task GetOrders_ShouldReturnAllOrders()
        {
            // Arrange
            using var context = new OrderService_DbContext(_dbOptions);
            context.Orders.Add(new Order
            {
                OrderId = Guid.NewGuid(),
                Customer = "Alice",
                Status = OrderStatus.Pending,
                Total = 150.00m,
                CreatedAt = DateTime.UtcNow
            });
            context.Orders.Add(new Order
            {
                OrderId = Guid.NewGuid(),
                Customer = "Zimkhitha",
                Status = OrderStatus.Processing,
                Total = 200.00m,
                CreatedAt = DateTime.UtcNow
            });
            await context.SaveChangesAsync();
            var service = new OrderService(_mapper, context, _logger);
            
            // Act
            var orders = await service.GetFilteredOrders(new Filter());
            
            // Assert
            Assert.Equal(2, orders.TotalCount);
            Assert.Contains(orders.Items, o => o.Customer == "Alice");
            Assert.DoesNotContain(orders.Items, o => o.Customer == "Bob");
        }

        [Fact]
        public async Task GetOrderById_Throws_WhenNotFound()
        {
            // Arrange
            using var context = new OrderService_DbContext(_dbOptions);
            var service = new OrderService(_mapper, context, _logger);

            var invalidId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => service.GetOrderById(invalidId));
        }

        [Fact]
        public async Task GetFilteredOrders_ShouldReturnFilteredResults()
        {
            // Arrange
            using var context = new OrderService_DbContext(_dbOptions);
            context.Orders.Add(new Order
            {
                OrderId = Guid.NewGuid(),
                Customer = "Alice",
                Status = OrderStatus.Pending,
                Total = 150.00m,
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            });
            context.Orders.Add(new Order
            {
                OrderId = Guid.NewGuid(),
                Customer = "Zimkhitha",
                Status = OrderStatus.Processing,
                Total = 200.00m,
                CreatedAt = DateTime.UtcNow
            });
            await context.SaveChangesAsync();
            var service = new OrderService(_mapper, context, _logger);
            var filter = new Filter
            {
                Customer = "Alice"
            };
            // Act
            var result = await service.GetFilteredOrders(filter);
            // Assert
            Assert.Single(result.Items);
            Assert.Equal("Alice", result.Items.First().Customer);
        }

        [Fact]
        public async Task GetFilteredOrders_ShouldReturnEmpty_WhenNoMatch()
        {
            // Arrange
            using var context = new OrderService_DbContext(_dbOptions);
            context.Orders.Add(new Order
            {
                OrderId = Guid.NewGuid(),
                Customer = "Alice",
                Status = OrderStatus.Pending,
                Total = 150.00m,
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            });
            await context.SaveChangesAsync();
            var service = new OrderService(_mapper, context, _logger);
            var filter = new Filter
            {
                Customer = "Bob"
            };
            // Act
            var result = await service.GetFilteredOrders(filter);
            // Assert
            Assert.Empty(result.Items);
        }
    }
}

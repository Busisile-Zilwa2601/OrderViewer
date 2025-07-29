using Xunit;
using Moq;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            var service = new OrderService(_mapper, context);
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
            var service = new OrderService(_mapper, context);

            var invalidId = Guid.NewGuid();

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => service.GetOrderById(invalidId));
        }
    }
}

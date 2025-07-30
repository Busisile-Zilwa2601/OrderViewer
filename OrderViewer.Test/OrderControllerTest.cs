using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderViewer.Service.OrderAPI.Controllers;
using OrderViewer.Service.OrderAPI.Dtos;
using OrderViewer.Service.OrderAPI.Interfaces;
using OrderViewer.Service.OrderAPI.Models;


namespace OrderViewer.Test
{
    public class OrderControllerTest
    {
        private readonly Mock<IOrderService> _orderServiceMock;
        private readonly OrderController _controller;
        private readonly Mock<ILogger<OrderController>> _loggerMock;

        public OrderControllerTest() 
        {
            _orderServiceMock = new Mock<IOrderService>();
            _loggerMock = new Mock<ILogger<OrderController>>();
            _controller = new OrderController(_orderServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetOrder_RetunsOk_WhenOrderExists()
        { 
            //Mockdata
            var orderId = Guid.NewGuid();
            var expectedOrder = new OrderDto
            {
                OrderId = orderId,
                Customer = "Test Customer",
                Total = 100.00m,
                CreatedAt = DateTime.UtcNow
            };
            _orderServiceMock.Setup(s => s.GetOrderById(orderId))
                .ReturnsAsync(expectedOrder);

            //Act
            var result = await _controller.GetOrder(orderId);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedOrder = Assert.IsType<OrderDto>(okResult.Value);
            Assert.Equal(expectedOrder.OrderId, returnedOrder.OrderId);
        }

        [Fact]
        public async Task GetOrder_ReturnsNotFound_WhenOrderDoesNotExist()
        {
            //Mockdata
            var orderId = Guid.NewGuid();
            _orderServiceMock.Setup(s => s.GetOrderById(orderId))
                .ThrowsAsync(new KeyNotFoundException("Order not found"));
            
            //Act
            var result = await _controller.GetOrder(orderId);
            
            //Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
            Assert.Contains("Order not found", notFoundResult.Value?.ToString());
        }

        [Fact]
        public async Task GetOrdersFiltered_ReturnsOk_WhenOrdersExist()
        {
            //Mockdata
            var filters = new Filter();
            var expectedOrders = new PagedResult<OrderDto>
            {
                Items = new List<OrderDto>
                {
                    new OrderDto { 
                        OrderId = Guid.NewGuid(), 
                        Customer = "Test Customer", 
                        Total = 100.00m, 
                        CreatedAt = DateTime.UtcNow 
                    }
                },
                TotalCount = 1
            };
            _orderServiceMock.Setup(s => s.GetFilteredOrders(filters))
                .ReturnsAsync(expectedOrders);
            
            //Act
            var result = await _controller.GetOrdersFiltered(filters);
           
            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedOrders = Assert.IsType<PagedResult<OrderDto>>(okResult.Value);
            Assert.Equal(1, returnedOrders.TotalCount);
        }

        [Fact]
        public async Task GetOrdersFiltered_ReturnsEmpty_NoOrdersExist()
        {
            //Mockdata
            var filters = new Filter(); // customize as needed
            var emptyResult = new PagedResult<OrderDto>
            {
                Items = new List<OrderDto>(),
                TotalCount = 0,
                PageSize = 10,
                CurrentPage = 1
            };
            _orderServiceMock.Setup(s => s.GetFilteredOrders(filters))
                .ReturnsAsync(emptyResult);

            //Act
            var result = await _controller.GetOrdersFiltered(filters);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnedOrders = Assert.IsType<PagedResult<OrderDto>>(okObjectResult.Value);
            Assert.Equal(0, returnedOrders.TotalCount);
        }

        [Fact]
        public async Task AddOrder_ReturnsCreatedAtAction_WhenOrderIsAdded()
        {
            // Arrange
            var newOrder = new OrderDto
            {
                OrderId = Guid.NewGuid(),
                Customer = "New Customer",
                Total = 150.00m,
                CreatedAt = DateTime.UtcNow
            };
            _orderServiceMock
                .Setup(s => s.AddOrder(newOrder))
                .ReturnsAsync(newOrder);
            
            // Act
            var result = await _controller.AddOrder(newOrder);
            
            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedOrders = Assert.IsType<OrderDto>(createdResult.Value);
            Assert.Equal("New Customer", returnedOrders.Customer);
            Assert.Equal(newOrder.OrderId, returnedOrders.OrderId);
        }

        [Fact]
        public async Task AddOrder_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            var newOrder = new OrderDto(); // Invalid order with no data
            _controller.ModelState.AddModelError("Customer", "Customer is required");
            
            // Act
            var result = await _controller.AddOrder(newOrder);
            
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task AddOrder_ReturnsConflict_WhenOrderAlreadyExists()
        {
            // Arrange
            var existingOrder = new OrderDto
            {
                OrderId = Guid.NewGuid(),
                Customer = "Existing Customer",
                Total = 200.00m,
                CreatedAt = DateTime.UtcNow
            };
            // Mock the service to throw an exception when trying to add an existing order
            _orderServiceMock
                .Setup(s => s.AddOrder(existingOrder))
                .ThrowsAsync(new InvalidOperationException("Order already exists"));
            
            // Act
            var result = await _controller.AddOrder(existingOrder);
            
            // Assert
            var conflictResult = Assert.IsType<ConflictObjectResult>(result.Result);
            Assert.Equal(409, conflictResult.StatusCode);
            Assert.Contains("Order already exists", conflictResult.Value?.ToString());
        }
    }
}

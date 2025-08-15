using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Service.OrderAPI.ContextData;
using OrderViewer.Service.OrderAPI.Dtos;
using OrderViewer.Service.OrderAPI.Interfaces;

namespace OrderViewer.Service.OrderAPI.Services
{
    public class ProductService(IMapper mapper, OrderService_DbContext orderService_DbContext, ILogger<OrderService> logger) : IProducService
    {
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly OrderService_DbContext _orderService_DbContext = orderService_DbContext ?? throw new ArgumentNullException(nameof(orderService_DbContext));
        private readonly ILogger<OrderService> logger = logger;
        public async Task<ProductDto> GetOrderProducts(Guid OrderId)
        {
            var orderWithProducts = _orderService_DbContext.Orders
                .Include(o => o.Products)
                .FirstOrDefault(o => o.OrderId == OrderId);

            if (orderWithProducts == null)
            {
                this.logger.LogWarning($"Order with ID {OrderId} not found");
            }

            return mapper.Map<ProductDto>(orderWithProducts);
        }
    }
}

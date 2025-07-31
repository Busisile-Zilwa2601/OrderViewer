using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Service.OrderAPI.ContextData;
using OrderViewer.Service.OrderAPI.Interfaces;
using OrderViewer.Service.OrderAPI.Dtos;
using OrderViewer.Service.OrderAPI.Models;

namespace OrderViewer.Service.OrderAPI.Services
{
    public class OrderService(IMapper mapper, OrderService_DbContext orderService_DbContext, ILogger<OrderService> logger) : IOrderService
    {
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly OrderService_DbContext _orderService_DbContext = orderService_DbContext ?? throw new ArgumentNullException(nameof(orderService_DbContext));
        private readonly ILogger<OrderService> logger = logger;

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orders = await _orderService_DbContext.Orders.ToListAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderById(Guid orderId)
        {
           var order = await _orderService_DbContext.Orders
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (order == null)
            {
                this.logger.LogWarning("Order with ID {orderId} not found.", orderId);
                throw new KeyNotFoundException($"Order with ID {orderId} not found.");
            }
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<PagedResult<OrderDto>> GetFilteredOrders(Filter filter)
        {
            var query = _orderService_DbContext.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(filter.OrderId))
                query = query.Where(o => o.OrderId.ToString().Contains(filter.OrderId));

            if (!string.IsNullOrEmpty(filter.Customer))
                query = query.Where(o => o.Customer.Contains(filter.Customer));

            if (!string.IsNullOrEmpty(filter.Status) && Enum.TryParse<OrderStatus>(filter.Status, out var statusEnum))
                query = query.Where(o => o.Status == statusEnum);

            if (filter.FromDate.HasValue)
            {
                query = query.Where(o => o.CreatedAt >= filter.FromDate.Value);
            }
            if (filter.ToDate.HasValue)
            {
                query = query.Where(o => o.CreatedAt <= filter.ToDate.Value);
            }

            var items = await query
                .OrderByDescending(o => o.CreatedAt)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(o => new OrderDto
                { 
                    OrderId = o.OrderId,
                    CreatedAt = o.CreatedAt,
                    Customer = o.Customer,
                    Status = o.Status.ToString(),
                    Total = o.Total,
                    
                }).ToListAsync();


            return new PagedResult<OrderDto>
            {
                Items = items,
                TotalCount = await query.CountAsync(),
                CurrentPage = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        public async Task<OrderDto> AddOrder(OrderDto orderDto)
        {
            if (orderDto.OrderId != Guid.Empty)
            {
                var exists = await _orderService_DbContext.Orders.AnyAsync(o => o.OrderId == orderDto.OrderId);
                this.logger.LogInformation("Checking order existance, orderId ={orderDto.OrderId }", orderDto.OrderId);
                if (exists)
                {
                    this.logger.LogWarning("Order with ID {orderDto.OrderId} already exists.", orderDto.OrderId);
                    throw new InvalidOperationException($"Order with ID {orderDto.OrderId} already exists.");
                }
            }

            var order = new Order
            {
                OrderId = orderDto.OrderId == Guid.Empty ? Guid.NewGuid() : orderDto.OrderId,
                Customer = orderDto.Customer,
                Status = Enum.Parse<OrderStatus>(orderDto.Status),
                Total = orderDto.Total,
                CreatedAt = DateTime.UtcNow
            };

            _orderService_DbContext.Add(order);
            await _orderService_DbContext.SaveChangesAsync();

            this.logger.LogInformation("Order with ID {order.OrderId} added successfully to the database.", order.OrderId);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> UpdateOrder(OrderDto orderDto)
        {
            this.logger.LogInformation("Updating order with ID {orderDto.OrderId} with data: {@orderDto}", orderDto.OrderId, orderDto);
            
            var order = await _orderService_DbContext.Orders
                .FirstOrDefaultAsync(o => o.OrderId == orderDto.OrderId);
            
            if (order == null)
            {
                this.logger.LogWarning("Order with ID {orderDto.OrderId} not found.", orderDto.OrderId);
                throw new KeyNotFoundException($"Order with ID {orderDto.OrderId} not found.");
            }
            order.Customer = orderDto.Customer;
            order.Status = Enum.Parse<OrderStatus>(orderDto.Status);
            order.Total = orderDto.Total;

            _orderService_DbContext.Update(order);
            await _orderService_DbContext.SaveChangesAsync();
            this.logger.LogInformation("Order with ID {order.OrderId} updated successfully in the database.", order.OrderId);
            
            return _mapper.Map<OrderDto>(order);
        }
    }
}

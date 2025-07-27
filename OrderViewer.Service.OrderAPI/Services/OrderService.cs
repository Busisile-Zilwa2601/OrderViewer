using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderViewer.Service.OrderAPI.ContextData;
using OrderViewer.Service.OrderAPI.Interfaces;
using OrderViewer.Service.OrderAPI.Dtos;
using OrderViewer.Service.OrderAPI.Models;

namespace OrderViewer.Service.OrderAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly OrderService_DbContext _orderService_DbContext;

        public OrderService(IMapper mapper, OrderService_DbContext orderService_DbContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderService_DbContext = orderService_DbContext ?? throw new ArgumentNullException(nameof(orderService_DbContext));
        }
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
                throw new KeyNotFoundException($"Order with ID {orderId} not found.");
            }
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<PagedResult<OrderDto>> GetFilteredOrders(Filter filter)
        {
            var query = _orderService_DbContext.Orders.AsQueryable();

            if(!string.IsNullOrEmpty(filter.Field) && !string.IsNullOrEmpty(filter.Value))
            {
                switch (filter.Field.ToLower())
                {
                    case "status":
                        if (Enum.TryParse<OrderStatus>(filter.Value, true, out var statusEnum)) 
                        {
                            query = query.Where(o => o.Status == statusEnum);
                        }
                        break;

                    case "customer":
                        query = query.Where(o => o.Customer.ToLower().Contains(filter.Value.ToLower()));
                        break;
                }
            }

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
    }
}

using OrderViewer.Service.OrderAPI.Dtos;

namespace OrderViewer.Service.OrderAPI.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderById(Guid orderId);
        Task<IEnumerable<OrderDto>> GetAllOrders();

        Task<PagedResult<OrderDto>> GetFilteredOrders(Filter filters);
        Task<OrderDto> AddOrder(OrderDto orderDto);
        Task<OrderDto> UpdateOrder(OrderDto orderDto);
    }
}

using OrderViewer.Web.Models;

namespace OrderViewer.Web.Interfaces
{
    public interface IOrderService
    {
        Task<PaginatedOrders?> GetOrdersAsync(OrderFilter orderFilter);

        Task<ResponseDto<OrderDto>?> GetOrderByIdAsync(Guid orderId);
        Task<ResponseDto<OrderDto>?> CreateOrderAysnc(OrderDto orderDto);
        Task<ResponseDto<OrderDto>?> UpdateOrderAysnc(OrderDto orderDto);
    }
}

using OrderViewer.Web.Models;

namespace OrderViewer.Web.Interfaces
{
    public interface IOrderService
    {
        Task<PaginatedOrders?> GetOrdersAsync(OrderFilter orderFilter);
    }
}

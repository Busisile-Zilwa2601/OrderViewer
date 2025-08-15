using OrderViewer.Service.OrderAPI.Dtos;

namespace OrderViewer.Service.OrderAPI.Interfaces
{
    public interface IProducService
    {
        Task<ProductDto> GetOrderProducts(Guid OrderId);
    }
}

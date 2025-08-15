using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using OrderViewer.Service.OrderAPI.Dtos;
using OrderViewer.Service.OrderAPI.Interfaces;

namespace OrderViewer.Service.OrderAPI.Controllers
{
    [Route("api/product")]
    public class OrderProductsController(IProducService producService, ILogger<OrderController> logger) : Controller
    {
        private readonly IProducService producService = producService ?? throw new ArgumentNullException(nameof(producService));
        private readonly ILogger<OrderController> logger = logger;

        [HttpGet("{OrderId}")]
        public async Task<ActionResult<ProductDto>> GetOrderProduct(Guid OrderId)
        {
            try
            {
                var orderProducts = await producService.GetOrderProducts(OrderId);
                this.logger.LogInformation($"Products with Order ID {OrderId} retrieved successfully.");
                return Ok(orderProducts);
            }
            catch (KeyNotFoundException ex)
            {
                this.logger.LogWarning(ex, "Order with ID {id} not found.", OrderId);
                return NotFound(new
                {
                    message = ex.Message,
                    status = 404
                });
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"An error occurred while retrieving products with order ID {OrderId}.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

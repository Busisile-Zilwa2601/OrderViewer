using Microsoft.AspNetCore.Mvc;
using OrderViewer.Service.OrderAPI.Dtos;
using OrderViewer.Service.OrderAPI.Interfaces;

namespace OrderViewer.Service.OrderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(Guid id) 
        {
            var order = await _orderService.GetOrderById(id);
            return order != null ? Ok(order) : NotFound($"Order with ID {id} not found.");
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersFiltered([FromQuery] Filter filters)
        {
            var result = await _orderService.GetFilteredOrders(filters);
            return Ok(result);
        }
    }
}

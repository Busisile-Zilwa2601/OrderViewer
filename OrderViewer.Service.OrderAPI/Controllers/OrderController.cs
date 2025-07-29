using Microsoft.AspNetCore.Mvc;
using OrderViewer.Service.OrderAPI.Dtos;
using OrderViewer.Service.OrderAPI.Interfaces;

namespace OrderViewer.Service.OrderAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
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
        [HttpPost]
        public async Task<ActionResult<OrderDto>> AddOrder([FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order data is required.");
            }
            try
            {
                var createdOrder = await _orderService.AddOrder(orderDto);
                return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.OrderId }, createdOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] OrderDto orderDto)
        {
            if (orderDto == null || id != orderDto.OrderId)
            {
                return BadRequest("Order data is invalid.");
            }
            try
            {
                var updatedOrder = await _orderService.UpdateOrder(orderDto);
                return Ok(updatedOrder);

            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

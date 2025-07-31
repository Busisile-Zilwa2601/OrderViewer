using Microsoft.AspNetCore.Mvc;
using OrderViewer.Service.OrderAPI.Dtos;
using OrderViewer.Service.OrderAPI.Interfaces;

namespace OrderViewer.Service.OrderAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController(IOrderService orderService, ILogger<OrderController> logger) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        private readonly ILogger<OrderController> logger = logger;

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(Guid id) 
        {
            try
            {
                var order = await _orderService.GetOrderById(id);
                this.logger.LogInformation("Order with ID {id} retrieved successfully.", id);
                return Ok(order);
            }
            catch (KeyNotFoundException ex)
            {
                this.logger.LogWarning(ex, "Order with ID {id} not found.", id);
                return NotFound(new { 
                    message = ex.Message,
                    status = 404
                });
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while retrieving order with ID {id}.", id);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("filtered")]
        public async Task<IActionResult> GetOrdersFiltered([FromQuery] Filter filters)
        {
            try
            {
                this.logger.LogInformation("Retrieving filtered orders with filters: {@filters}", filters);
                var result = await _orderService.GetFilteredOrders(filters);

                if (result == null)
                { 
                    this.logger.LogWarning("No orders found with the provided filters: {@filters}.", filters);
                    return NotFound(new
                    {
                        message = "No orders found with the provided filters.",
                        status = 404
                    });
                }

                this.logger.LogInformation("Filtered orders retrieved successfully {Count}.", result.Items.Count());
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                this.logger.LogWarning(ex, "Invalid filter parameters provided.");
                return BadRequest(new 
                { 
                    message = "Invalid filter parameters.", 
                    details = ex.Message,
                    status = 400
                });
            }
            catch (TimeoutException ex)
            {
                this.logger.LogError(ex, "Timeout occurred while filtering orders.");
                return StatusCode(504, new { message = "The request timed out.", details = ex.Message });
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Unhandled error occurred while filtering orders.");
                return StatusCode(500, new
                {
                    message = "An unexpected error occurred while processing your request.",
                    details = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> AddOrder([FromBody] OrderDto orderDto)
        {
            this.logger.LogInformation("Adding new order with data: {@orderDto}", orderDto);
            try
            {
                if (!ModelState.IsValid)
                {
                    this.logger.LogWarning("Invalid model state for order: {@orderDto}", orderDto);
                    return BadRequest( new { 
                        status = 400,
                        details = ModelState
                    });
                }

                var createdOrder = await _orderService.AddOrder(orderDto);
                this.logger.LogInformation("Order created successfully with ID: {OrderId}", createdOrder.OrderId);
                return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.OrderId }, createdOrder);
            }
            catch (ArgumentNullException ex)
            {
                this.logger.LogWarning(ex, "OrderDto was null.");
                return BadRequest(new 
                { 
                    message = "Order data is required.",
                    details = ex.Message,
                    status = 400
                });
            }
            catch (InvalidOperationException ex)
            {
                this.logger.LogWarning(ex, "Business rule violation while adding order.");
                return Conflict(new 
                { 
                    message = "Order could not be processed.", 
                    details = ex.Message,
                    status = 409
                });
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Unexpected error while adding order.");
                return StatusCode(500, new
                {
                    message = $"Internal server error",
                    details = ex.Message
            });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderDto orderDto)
        {
            if (orderDto == null )
            {
                return BadRequest("Order data is invalid.");
            }
            this.logger.LogInformation("Updating order with ID {id} with data: {@orderDto}", orderDto.OrderId, orderDto);
            try
            {
                if (orderDto.OrderId == Guid.Empty)
                {
                    logger.LogWarning("Order ID is required for updating an order.");
                    return BadRequest( new { 
                        message = "Order ID is required for updating an order.",
                        status = 400
                    });
                }

                if (!ModelState.IsValid)
                {
                    this.logger.LogWarning("Invalid model state for order: {@orderDto}", orderDto);
                    return BadRequest(new
                    {
                        status = 400,
                        details = ModelState
                    });
                }

                var updatedOrder = await _orderService.UpdateOrder(orderDto);

                if (updatedOrder == null)
                {
                    logger.LogWarning("Order with ID {OrderId} not found for update.", orderDto.OrderId);
                    return NotFound(new { 
                        message = $"Order with ID {orderDto.OrderId} not found.", 
                        status = 404 
                    });
                }
                this.logger.LogInformation("Order with ID {OrderId} updated successfully.", updatedOrder.OrderId);
                return Ok(updatedOrder);

            }
            catch (ArgumentException ex)
            {
                logger.LogWarning(ex, "Invalid argument provided while updating order.");
                return BadRequest(new { message = "Invalid data.", details = ex.Message, status = 400 });
            }
            catch (KeyNotFoundException ex)
            {
                logger.LogWarning(ex, "Order with ID {OrderId} not found.", orderDto.OrderId);
                return NotFound(new { 
                    message = $"Order with ID {orderDto.OrderId} not found.",
                    details = ex.Message, 
                    status = 404
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error occurred while updating order with ID {OrderId}", orderDto.OrderId);
                return StatusCode(500, new { message = "An internal server error occurred.", details = ex.Message });
            }
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OrderViewer.Web.Interfaces;
using OrderViewer.Web.Models;

namespace OrderViewer.Web.Controllers
{
    public class OrderViewerController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderViewerController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> GetOrderItems(Guid orderId)
        {
            var allItems = await _orderService.GetProductsByOrderId(orderId);
           
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            { 
                return PartialView("_OrderItems", allItems.Result);
            }
            return PartialView("_OrderItems", allItems.Result);
        }
        public async Task<IActionResult> OrderViewerIndex([FromQuery] OrderFilter orderFilter)
        {
            // Ensure defaults
            orderFilter.PageNumber = orderFilter.PageNumber <= 0 ? 1 : orderFilter.PageNumber;
            orderFilter.PageSize = orderFilter.PageSize <= 0 ? 10 : orderFilter.PageSize;
            
            var orders = await _orderService.GetOrdersAsync(orderFilter);

            if (orders.TotalPages > 0 && orderFilter.PageNumber > orders.TotalPages)
            {
                orderFilter.PageNumber = orders.TotalPages;
                orders = await _orderService.GetOrdersAsync(orderFilter);
            }
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_OrderTablePartial", orders); // Return partial view on AJAX
            }

            ViewBag.Filter = orderFilter;
            ViewBag.StatusOptions = Enum.GetValues(typeof(OrderStatus))
                .Cast<OrderStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString()
                })
                .ToList();

            if (orders == null) 
            {
                return View(new PaginatedOrders());
            }
            return View(orders);
        }
        public async Task<IActionResult> OrderPaginationPartial([FromQuery] OrderFilter orderFilter)
        {
            // Ensure defaults
            orderFilter.PageNumber = orderFilter.PageNumber <= 0 ? 1 : orderFilter.PageNumber;
            orderFilter.PageSize = orderFilter.PageSize <= 0 ? 10 : orderFilter.PageSize;

            var orders = await _orderService.GetOrdersAsync(orderFilter);
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
            {
                return PartialView("_PaginatingPartial", orders);
            }
            return PartialView("_PaginatingPartial", orders);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderSummary([FromQuery] OrderFilter filter)
        {
            // Ensure defaults
            filter.PageNumber = filter.PageNumber <= 0 ? 1 : filter.PageNumber;
            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;
            var orders = await _orderService.GetOrdersAsync(filter);
            var summary = new OrderSummary
            {
                Count = orders.Items.Count,
                GrandTotal = orders.Items.Sum(o => o.Total)
            };

            return Json(summary);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        { 
            var order = await _orderService.GetOrderByIdAsync(orderId);
            return Json(order);
        }

        public async Task<IActionResult> OrderCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderCreate(OrderDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto<OrderDto>? response = await _orderService.CreateOrderAysnc(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(OrderCreate));
                }
            }
            return View(model);
        }

        [HttpPatch]
        public async Task<IActionResult> OrderUpdate(OrderDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto<OrderDto>? response = await _orderService.UpdateOrderAysnc(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(OrderViewerIndex));
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MarkOrderAsPaid(Guid orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null || !order.IsSuccess) 
            {
                return BadRequest("No order found");
            }

            order.Result.Status = OrderStatus.Paid.ToString();
            await _orderService.UpdateOrderAysnc(order.Result);

            return PartialView("_OrderRowPartial", order);
        }

    }
}

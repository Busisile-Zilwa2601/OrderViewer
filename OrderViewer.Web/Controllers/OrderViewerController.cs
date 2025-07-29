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

        public async Task<IActionResult> OrderViewerIndex([FromQuery] OrderFilter orderFilter)
        {
            var orders = await _orderService.GetOrdersAsync(orderFilter);

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

        [HttpGet]
        public async Task<IActionResult> GetOrderSummary([FromQuery] OrderFilter filter)
        {
            var orders = await _orderService.GetOrdersAsync(filter);

            var summary = new
            {
                count = orders.Items.Count,
                grandTotal = orders.Items.Sum(o => o.Total)
            };

            return Json(summary);
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
    }
}

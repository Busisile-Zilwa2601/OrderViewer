using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;
using OrderViewer.Web.Interfaces;
using OrderViewer.Web.Models;
using OrderViewer.Web.Utils;

namespace OrderViewer.Web.Services
{
    public class OrderViewerService : IOrderService
    {
        private readonly IBaseService _baseService;

        public OrderViewerService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<PaginatedOrders?> GetOrdersAsync(OrderFilter orderFilter)
        {

            var response = await _baseService.SendAsync<PaginatedOrders>(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.OrderAPIBase + BuildOrderApiUrl(orderFilter)
            });

            if (response != null && response.IsSuccess && response.Message != null)
            {
                return response.Result;
            }

            return null;
        }

        //url builder
        public string BuildOrderApiUrl(OrderFilter orderFilter)
        {
            var baseUrl = "/api/order";

            var queryParams = new Dictionary<string, string?>
            {
                ["PageNumber"] = orderFilter.PageNumber.ToString(),
                ["PageSize"] = orderFilter.PageSize.ToString()
            };

            if (!string.IsNullOrWhiteSpace(orderFilter.Status))
                queryParams["Status"] = orderFilter.Status;

            if (!string.IsNullOrWhiteSpace(orderFilter.Customer))
                queryParams["Customer"] = orderFilter.Customer;

            if (orderFilter.FromDate.HasValue)
                queryParams["fromDate"] = orderFilter.FromDate.Value.ToString("o"); // ISO 8601 format

            if (orderFilter.ToDate.HasValue)
                queryParams["toDate"] = orderFilter.ToDate.Value.ToString("o");

            var urlWithQuery = QueryHelpers.AddQueryString(baseUrl, queryParams!);
            return urlWithQuery;
        }

    }
}

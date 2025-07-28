﻿namespace OrderViewer.Web.Models
{
    public class PaginatedOrders
    {
        public List<OrderDto> Items { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}

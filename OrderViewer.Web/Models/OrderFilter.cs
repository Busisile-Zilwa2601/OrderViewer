namespace OrderViewer.Web.Models
{
    public class OrderFilter
    {
        public string? OrderId { get; set; }
        public string? Customer { get; set; }
        public string? Status { get; set; }
        public string? Total { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

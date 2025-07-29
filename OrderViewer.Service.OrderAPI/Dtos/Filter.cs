namespace OrderViewer.Service.OrderAPI.Dtos
{
    public class Filter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? OrderId { get; set; }
        public string? Status { get; set; }
        public string? Customer { get; set; }

       public DateTime? FromDate { get; set; }
       public DateTime? ToDate { get; set; } 
    }
}

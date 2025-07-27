namespace OrderViewer.Service.OrderAPI.Models.Dto
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public string Customer { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

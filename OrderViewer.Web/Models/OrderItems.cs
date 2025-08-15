namespace OrderViewer.Web.Models
{
    public class OrderItems
    {
        public Guid OrderId { get; set; }
        public List<OrderDetails> Items { get; set; }
    }

    public class OrderDetails 
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

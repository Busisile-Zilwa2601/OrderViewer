namespace OrderViewer.Web.Models
{
    public class ProductDto
    {
        public Guid OrderId { get; set; }
        public List<ProductDetails> Products { get; set; }
    }

    public class ProductDetails
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

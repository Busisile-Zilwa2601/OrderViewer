using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderViewer.Service.OrderAPI.Models
{
    public class Product
    {
        public Guid ProductId { get; set; } // PK

        // Foreign key to Order
        public Guid OrderId { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }

        // Navigation property
        public Order Order { get; set; }
    }
}

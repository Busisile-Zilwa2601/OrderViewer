﻿using System.ComponentModel.DataAnnotations;

namespace OrderViewer.Web.Models
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal Total { get; set; }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "Order Date & Time")]
        public DateTime CreatedAt { get; set; }
    }
}

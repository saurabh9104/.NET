using System;
using System.Collections.Generic;

namespace ProductManagementSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }

        public Category Category { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

        public Product()
        {
            OrderDetails = new List<OrderDetails>();
        }

        public Product(int productId, string productName, int categoryId, decimal price, int quantity, int reorderLevel)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = categoryId;
            Price = price;
            Quantity = quantity;
            ReorderLevel = reorderLevel;
            OrderDetails = new List<OrderDetails>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Product_Management
{
    public class Product
    {
        // Use auto-properties to match repository expectations
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product() { }

        public Product(int productId, string productName, int categoryId, decimal price, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = categoryId;
            Price = price;
            Quantity = quantity;
        }
    }
}

using System;

namespace ProductManagementSystem.Models
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

        public OrderDetails()
        {
        }

        public OrderDetails(int orderDetailId, int orderId, int productId, int quantity, decimal price, decimal discount)
        {
            OrderDetailId = orderDetailId;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
            Discount = discount;
        }
    }
}

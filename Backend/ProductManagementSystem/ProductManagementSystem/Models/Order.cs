using System;
using System.Collections.Generic;

namespace ProductManagementSystem.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }

        public Order(int orderId, int customerId, int employeeId, DateTime orderDate, decimal totalAmount, string status, string remarks)
        {
            OrderId = orderId;
            CustomerId = customerId;
            EmployeeId = employeeId;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            Status = status;
            Remarks = remarks;
            OrderDetails = new List<OrderDetails>();
        }
    }
}

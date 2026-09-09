using System;
using System.Collections.Generic;

namespace ProductManagementSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }

        public Customer(int customerId, string customerName, string phone, string email, int addressId)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Phone = phone;
            Email = email;
            AddressId = addressId;
            Orders = new List<Order>();
        }
    }
}

using System;
using System.Collections.Generic;

namespace ProductManagementSystem.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }

        public EmployeeDetails EmployeeDetails { get; set; }
        public ICollection<Customer> Customers { get; set; }

        public Address()
        {
            Customers = new List<Customer>();
        }

        public Address(int addressId, string houseNo, string street, string city, string state, string pincode, string country)
        {
            AddressId = addressId;
            HouseNo = houseNo;
            Street = street;
            City = city;
            State = state;
            Pincode = pincode;
            Country = country;
            Customers = new List<Customer>();
        }
    }
}

using System;

namespace ProductManagementSystem.Models
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Salary { get; set; }
        public bool Active { get; set; }
        public int RoleId { get; set; }

        public Employee Employee { get; set; }
        public Address Address { get; set; }
        public Role Role { get; set; }

        public EmployeeDetails()
        {
        }

        public EmployeeDetails(int employeeId, int addressId, string phone, string email, DateTime dateOfBirth, DateTime joiningDate, string username, string password, decimal salary, bool active, int roleId)
        {
            EmployeeId = employeeId;
            AddressId = addressId;
            Phone = phone;
            Email = email;
            DateOfBirth = dateOfBirth;
            JoiningDate = joiningDate;
            Username = username;
            Password = password;
            Salary = salary;
            Active = active;
            RoleId = roleId;
        }
    }
}

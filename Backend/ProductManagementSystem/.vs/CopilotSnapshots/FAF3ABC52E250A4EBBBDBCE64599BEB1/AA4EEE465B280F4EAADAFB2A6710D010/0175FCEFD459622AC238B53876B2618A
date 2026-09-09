using System;
using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories;

namespace ProductManagementSystem.Services
{
    public class LoginService
    {
        private readonly EmployeeDetailsRepository _repository;

        public LoginService()
        {
            _repository = new EmployeeDetailsRepository();
        }

        /// <summary>
        /// Authenticates employee with username and password
        /// </summary>
        public EmployeeDetails Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username and password are required.");
                return null;
            }

            EmployeeDetails employee = _repository.GetByUsername(username);

            if (employee == null)
            {
                Console.WriteLine("Invalid username or password.");
                return null;
            }

            if (employee.Password != password)
            {
                Console.WriteLine("Invalid username or password.");
                return null;
            }

            if (!employee.Active)
            {
                Console.WriteLine("Employee account is inactive.");
                return null;
            }

            return employee;
        }

        /// <summary>
        /// Gets employee details by ID
        /// </summary>
        public EmployeeDetails GetEmployeeDetails(int employeeId)
        {
            return _repository.GetById(employeeId);
        }
    }
}
using System;
using System.Collections.Generic;

namespace ProductManagementSystem.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<EmployeeDetails> EmployeeDetails { get; set; }

        public Role()
        {
            Employees = new List<Employee>();
            EmployeeDetails = new List<EmployeeDetails>();
        }

        public Role(int roleId, string roleName, string description)
        {
            RoleId = roleId;
            RoleName = roleName;
            Description = description;
            Employees = new List<Employee>();
            EmployeeDetails = new List<EmployeeDetails>();
        }
    }
}

using System;
using System.Collections.Generic;

namespace ProductManagementSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new List<Employee>();
        }

        public Department(int departmentId, string departmentName, string description)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
            Description = description;
            Employees = new List<Employee>();
        }
    }
}

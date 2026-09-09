using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories;

namespace ProductManagementSystem.Services
{
    public class EmployeeService
    {
        private EmployeeRepository repository = new EmployeeRepository();

        public void AddEmployee(Employee employee)
        {
            repository.Add(employee);
        }

        public List<Employee> DisplayEmployees()
        {
            return repository.GetAll();
        }

        public Employee GetEmployee(int employeeId)
        {
            return repository.GetById(employeeId);
        }

        public void UpdateEmployee(Employee employee)
        {
            repository.Update(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            repository.Delete(employeeId);
        }

        public List<Employee> SearchEmployee(string employeeName)
        {
            return repository.SearchByName(employeeName);
        }
    }
}
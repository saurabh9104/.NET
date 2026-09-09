using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories;

namespace ProductManagementSystem.Services
{
    public class DepartmentService
    {
        private DepartmentRepository repository = new DepartmentRepository();

        public void AddDepartment(Department department)
        {
            repository.Add(department);
        }

        public List<Department> DisplayDepartments()
        {
            return repository.GetAll();
        }

        public Department GetDepartment(int departmentId)
        {
            return repository.GetById(departmentId);
        }

        public void UpdateDepartment(Department department)
        {
            repository.Update(department);
        }

        public void DeleteDepartment(int departmentId)
        {
            repository.Delete(departmentId);
        }

        public List<Department> SearchDepartment(string departmentName)
        {
            return repository.SearchByName(departmentName);
        }
    }
}
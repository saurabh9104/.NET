using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories;

namespace ProductManagementSystem.Services
{
    public class RoleService
    {
        private RoleRepository repository = new RoleRepository();

        public void AddRole(Role role)
        {
            repository.Add(role);
        }

        public List<Role> DisplayRoles()
        {
            return repository.GetAll();
        }

        public Role GetRole(int roleId)
        {
            return repository.GetById(roleId);
        }

        public void UpdateRole(Role role)
        {
            repository.Update(role);
        }

        public void DeleteRole(int roleId)
        {
            repository.Delete(roleId);
        }

        public List<Role> SearchRole(string roleName)
        {
            return repository.SearchByName(roleName);
        }
    }
}
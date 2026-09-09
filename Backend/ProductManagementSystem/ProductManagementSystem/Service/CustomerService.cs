using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories;

namespace ProductManagementSystem.Services
{
    public class CustomerService
    {
        private CustomerRepository repository = new CustomerRepository();

        public void AddCustomer(Customer customer)
        {
            repository.Add(customer);
        }

        public List<Customer> DisplayCustomers()
        {
            return repository.GetAll();
        }

        public Customer GetCustomer(int customerId)
        {
            return repository.GetById(customerId);
        }

        public void UpdateCustomer(Customer customer)
        {
            repository.Update(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            repository.Delete(customerId);
        }

        public List<Customer> SearchCustomer(string customerName)
        {
            return repository.SearchByName(customerName);
        }
    }
}
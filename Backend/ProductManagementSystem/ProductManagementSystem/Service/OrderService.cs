using ProductManagementSystem.Models;
using ProductManagementSystem.Repositories;

namespace ProductManagementSystem.Services
{
    public class OrderService
    {
        private OrderRepository repository = new OrderRepository();

        public void CreateOrder(Order order)
        {
            repository.Add(order);
        }

        public List<Order> DisplayOrders()
        {
            return repository.GetAll();
        }

        public Order GetOrder(int orderId)
        {
            return repository.GetById(orderId);
        }

        public void UpdateOrder(Order order)
        {
            repository.Update(order);
        }

        public void DeleteOrder(int orderId)
        {
            repository.Delete(orderId);
        }

        public List<Order> GetOrdersByCustomer(int customerId)
        {
            return repository.GetByCustomer(customerId);
        }

        public List<Order> GetOrdersByEmployee(int employeeId)
        {
            return repository.GetByEmployee(employeeId);
        }

        public List<Order> GetOrdersByStatus(string status)
        {
            return repository.GetByStatus(status);
        }

        public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return repository.GetOrdersByDateRange(startDate, endDate);
        }

        public void UpdateStatus(int orderId, string status)
        {
            repository.UpdateStatus(orderId, status);
        }
    }
}
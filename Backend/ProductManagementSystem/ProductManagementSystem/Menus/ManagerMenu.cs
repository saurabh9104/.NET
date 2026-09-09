using ProductManagementSystem.Models;
using ProductManagementSystem.Service;
using ProductManagementSystem.Services;
using System;

namespace ProductManagementSystem.Menus
{
    public class ManagerMenu
    {
        public static void Display()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("\n===== MANAGER MENU =====");
                Console.WriteLine("1. Category Management");
                Console.WriteLine("2. Product Management");
                Console.WriteLine("3. Customer Management");
                Console.WriteLine("4. Orders Management");
                Console.WriteLine("5. Logout");
                Console.WriteLine("========================");
                Console.Write("Select an option (1-5): ");

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        CategoryManagement();
                        break;
                    case "2":
                        ProductManagement();
                        break;
                    case "3":
                        CustomerManagement();
                        break;
                    case "4":
                        OrdersManagement();
                        break;
                    case "5":
                        isRunning = false;
                        Console.WriteLine("\n✅ Logged out successfully.");
                        break;
                    default:
                        Console.WriteLine("❌ Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CategoryManagement()
        {
            CategoryService categoryService = new CategoryService();

            Console.Clear();

            Console.WriteLine("===== CATEGORY MANAGEMENT =====");
            Console.WriteLine("1. View All Categories");
            Console.WriteLine("2. Add Category");
            Console.WriteLine("3. Update Category");
            Console.WriteLine("4. Delete Category");
            Console.WriteLine("5. Search Category");
            Console.WriteLine("6. Back");
            Console.Write("Select Option : ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    List<Category> categories = categoryService.DisplayCategories();

                    foreach (Category category in categories)
                    {
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine($"Category Id   : {category.CategoryId}");
                        Console.WriteLine($"Category Name : {category.CategoryName}");
                        Console.WriteLine($"Description   : {category.Description}");
                    }

                    break;

                case "2":

                    Category newCategory = new Category();

                    Console.Write("Category Name : ");
                    newCategory.CategoryName = Console.ReadLine();

                    Console.Write("Description : ");
                    newCategory.Description = Console.ReadLine();

                    categoryService.AddCategory(newCategory);

                    Console.WriteLine("Category Added Successfully.");
                    break;

                case "3":

                    Category updateCategory = new Category();

                    Console.Write("Category Id : ");
                    updateCategory.CategoryId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Category Name : ");
                    updateCategory.CategoryName = Console.ReadLine();

                    Console.Write("Description : ");
                    updateCategory.Description = Console.ReadLine();

                    categoryService.UpdateCategory(updateCategory);

                    Console.WriteLine("Category Updated Successfully.");
                    break;

                case "4":

                    Console.Write("Category Id : ");

                    int categoryId = Convert.ToInt32(Console.ReadLine());

                    categoryService.DeleteCategory(categoryId);

                    Console.WriteLine("Category Deleted Successfully.");
                    break;

                case "5":

                    Console.Write("Category Name : ");

                    string categoryName = Console.ReadLine();

                    List<Category> searchCategories = categoryService.SearchCategory(categoryName);

                    foreach (Category category in searchCategories)
                    {
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine($"Category Id   : {category.CategoryId}");
                        Console.WriteLine($"Category Name : {category.CategoryName}");
                        Console.WriteLine($"Description   : {category.Description}");
                    }

                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void ProductManagement()
        {
            ProductService productService = new ProductService();
            Console.Clear();
            Console.WriteLine("\n===== PRODUCT MANAGEMENT =====");
            Console.WriteLine("1. View All Products");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Search Product");
            Console.WriteLine("6. Back to Main Menu");
            Console.WriteLine("===============================");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    List<Product> products = productService.DisplayProducts();

                    foreach (Product product in products)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"Id             : {product.ProductId}");
                        Console.WriteLine($"Name           : {product.ProductName}");
                        Console.WriteLine($"Category Id    : {product.CategoryId}");
                        Console.WriteLine($"Price          : {product.Price}");
                        Console.WriteLine($"Quantity       : {product.Quantity}");
                        Console.WriteLine($"Reorder Level  : {product.ReorderLevel}");
                    }
                    break;

                case "2":
                    Product newProduct = new Product();

                    Console.Write("Product Name : ");
                    newProduct.ProductName = Console.ReadLine();

                    Console.Write("Category Id : ");
                    newProduct.CategoryId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Price : ");
                    newProduct.Price = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Quantity : ");
                    newProduct.Quantity = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Reorder Level : ");
                    newProduct.ReorderLevel = Convert.ToInt32(Console.ReadLine());

                    productService.AddProduct(newProduct);

                    Console.WriteLine("Product Added Successfully.");
                    break; ;

                case "3":
                    Product updateProduct = new Product();

                    Console.Write("Product Id : ");
                    updateProduct.ProductId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Product Name : ");
                    updateProduct.ProductName = Console.ReadLine();

                    Console.Write("Category Id : ");
                    updateProduct.CategoryId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Price : ");
                    updateProduct.Price = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Quantity : ");
                    updateProduct.Quantity = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Reorder Level : ");
                    updateProduct.ReorderLevel = Convert.ToInt32(Console.ReadLine());

                    productService.UpdateProduct(updateProduct);

                    Console.WriteLine("Product Updated Successfully.");
                    break;

                case "4":
                    Console.Write("Enter Product Id : ");
                    int productId = Convert.ToInt32(Console.ReadLine());

                    productService.DeleteProduct(productId);

                    Console.WriteLine("Product Deleted Successfully.");
                    break;

                case "5":
                    Console.Write("Enter Product Name : ");
                    string productName = Console.ReadLine();

                    List<Product> searchProducts = productService.SearchProduct(productName);

                    foreach (Product product in searchProducts)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"Id             : {product.ProductId}");
                        Console.WriteLine($"Name           : {product.ProductName}");
                        Console.WriteLine($"Category Id    : {product.CategoryId}");
                        Console.WriteLine($"Price          : {product.Price}");
                        Console.WriteLine($"Quantity       : {product.Quantity}");
                        Console.WriteLine($"Reorder Level  : {product.ReorderLevel}");
                    }

                    break;

                case "6":
                    return;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void CustomerManagement()
        {
            CustomerService customerService = new CustomerService();

            Console.Clear();

            Console.WriteLine("===== CUSTOMER MANAGEMENT =====");
            Console.WriteLine("1. View All Customers");
            Console.WriteLine("2. Add Customer");
            Console.WriteLine("3. Update Customer");
            Console.WriteLine("4. Delete Customer");
            Console.WriteLine("5. Search Customer");
            Console.WriteLine("6. Back");
            Console.Write("Select Option : ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    List<Customer> customers = customerService.DisplayCustomers();

                    foreach (Customer customer in customers)
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine($"Customer Id   : {customer.CustomerId}");
                        Console.WriteLine($"Customer Name : {customer.CustomerName}");
                        Console.WriteLine($"Phone         : {customer.Phone}");
                        Console.WriteLine($"Email         : {customer.Email}");
                        Console.WriteLine($"Address Id    : {customer.AddressId}");
                    }
                    break;

                case "2":

                    Customer newCustomer = new Customer();

                    Console.Write("Customer Name : ");
                    newCustomer.CustomerName = Console.ReadLine();

                    Console.Write("Phone : ");
                    newCustomer.Phone = Console.ReadLine();

                    Console.Write("Email : ");
                    newCustomer.Email = Console.ReadLine();

                    Console.Write("Address Id : ");
                    newCustomer.AddressId = Convert.ToInt32(Console.ReadLine());

                    customerService.AddCustomer(newCustomer);

                    Console.WriteLine("Customer Added Successfully.");
                    break;

                case "3":

                    Customer updateCustomer = new Customer();

                    Console.Write("Customer Id : ");
                    updateCustomer.CustomerId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Customer Name : ");
                    updateCustomer.CustomerName = Console.ReadLine();

                    Console.Write("Phone : ");
                    updateCustomer.Phone = Console.ReadLine();

                    Console.Write("Email : ");
                    updateCustomer.Email = Console.ReadLine();

                    Console.Write("Address Id : ");
                    updateCustomer.AddressId = Convert.ToInt32(Console.ReadLine());

                    customerService.UpdateCustomer(updateCustomer);

                    Console.WriteLine("Customer Updated Successfully.");
                    break;

                case "4":

                    Console.Write("Customer Id : ");
                    int customerId = Convert.ToInt32(Console.ReadLine());

                    customerService.DeleteCustomer(customerId);

                    Console.WriteLine("Customer Deleted Successfully.");
                    break;

                case "5":

                    Console.Write("Customer Name : ");
                    string customerName = Console.ReadLine();

                    List<Customer> searchCustomers = customerService.SearchCustomer(customerName);

                    foreach (Customer customer in searchCustomers)
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine($"Customer Id   : {customer.CustomerId}");
                        Console.WriteLine($"Customer Name : {customer.CustomerName}");
                        Console.WriteLine($"Phone         : {customer.Phone}");
                        Console.WriteLine($"Email         : {customer.Email}");
                        Console.WriteLine($"Address Id    : {customer.AddressId}");
                    }
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void OrdersManagement()
        {
            OrderService orderService = new OrderService();

            Console.Clear();

            Console.WriteLine("===== ORDERS MANAGEMENT =====");
            Console.WriteLine("1. View All Orders");
            Console.WriteLine("2. Create Order");
            Console.WriteLine("3. Update Order");
            Console.WriteLine("4. Delete Order");
            Console.WriteLine("5. Search By Customer");
            Console.WriteLine("6. Search By Employee");
            Console.WriteLine("7. Search By Status");
            Console.WriteLine("8. Update Status");
            Console.WriteLine("9. Search By Date Range");
            Console.WriteLine("10. Back");
            Console.Write("Select Option : ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    List<Order> orders = orderService.DisplayOrders();

                    foreach (Order order in orders)
                    {
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine($"Order Id     : {order.OrderId}");
                        Console.WriteLine($"Customer Id  : {order.CustomerId}");
                        Console.WriteLine($"Employee Id  : {order.EmployeeId}");
                        Console.WriteLine($"Order Date   : {order.OrderDate}");
                        Console.WriteLine($"Total Amount : {order.TotalAmount}");
                        Console.WriteLine($"Status       : {order.Status}");
                        Console.WriteLine($"Remarks      : {order.Remarks}");
                    }

                    break;

                case "2":

                    Order newOrder = new Order();

                    Console.Write("Customer Id : ");
                    newOrder.CustomerId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Employee Id : ");
                    newOrder.EmployeeId = Convert.ToInt32(Console.ReadLine());

                    newOrder.OrderDate = DateTime.Now;

                    Console.Write("Total Amount : ");
                    newOrder.TotalAmount = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Status : ");
                    newOrder.Status = Console.ReadLine();

                    Console.Write("Remarks : ");
                    newOrder.Remarks = Console.ReadLine();

                    orderService.CreateOrder(newOrder);

                    Console.WriteLine("Order Created Successfully.");

                    break;

                case "3":

                    Order updateOrder = new Order();

                    Console.Write("Order Id : ");
                    updateOrder.OrderId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Customer Id : ");
                    updateOrder.CustomerId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Employee Id : ");
                    updateOrder.EmployeeId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Order Date : ");
                    updateOrder.OrderDate = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Total Amount : ");
                    updateOrder.TotalAmount = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Status : ");
                    updateOrder.Status = Console.ReadLine();

                    Console.Write("Remarks : ");
                    updateOrder.Remarks = Console.ReadLine();

                    orderService.UpdateOrder(updateOrder);

                    Console.WriteLine("Order Updated Successfully.");

                    break;

                case "4":

                    Console.Write("Order Id : ");

                    int orderId = Convert.ToInt32(Console.ReadLine());

                    orderService.DeleteOrder(orderId);

                    Console.WriteLine("Order Deleted Successfully.");

                    break;

                case "5":

                    Console.Write("Customer Id : ");

                    int customerId = Convert.ToInt32(Console.ReadLine());

                    var customerOrders = orderService.GetOrdersByCustomer(customerId);

                    foreach (Order order in customerOrders)
                    {
                        Console.WriteLine($"{order.OrderId}  {order.TotalAmount}  {order.Status}");
                    }

                    break;

                case "6":

                    Console.Write("Employee Id : ");

                    int employeeId = Convert.ToInt32(Console.ReadLine());

                    var employeeOrders = orderService.GetOrdersByEmployee(employeeId);

                    foreach (Order order in employeeOrders)
                    {
                        Console.WriteLine($"{order.OrderId}  {order.TotalAmount}  {order.Status}");
                    }

                    break;

                case "7":

                    Console.Write("Status : ");

                    string status = Console.ReadLine();

                    var statusOrders = orderService.GetOrdersByStatus(status);

                    foreach (Order order in statusOrders)
                    {
                        Console.WriteLine($"{order.OrderId}  {order.TotalAmount}  {order.Status}");
                    }

                    break;

                case "8":

                    Console.Write("Order Id : ");

                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("New Status : ");

                    string newStatus = Console.ReadLine();

                    orderService.UpdateStatus(id, newStatus);

                    Console.WriteLine("Status Updated Successfully.");

                    break;

                case "9":

                    Console.Write("Start Date (yyyy-MM-dd): ");
                    DateTime start = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("End Date (yyyy-MM-dd): ");
                    DateTime end = Convert.ToDateTime(Console.ReadLine());

                    var dateOrders = orderService.GetOrdersByDateRange(start, end);

                    foreach (Order order in dateOrders)
                    {
                        Console.WriteLine($"{order.OrderId}  {order.OrderDate:d}  {order.TotalAmount}");
                    }

                    break;

                case "10":
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}

using System;

namespace ProductManagementSystem.Menus
{
    public class EmployeeMenu
    {
        public static void Display()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("\n===== EMPLOYEE MENU =====");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Create Order");
                Console.WriteLine("3. View Customers");
                Console.WriteLine("4. Logout");
                Console.WriteLine("=========================");
                Console.Write("Select an option (1-4): ");

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        ViewProducts();
                        break;

                    case "2":
                        CreateOrder();
                        break;

                    case "3":
                        ViewCustomers();
                        break;

                    case "4":
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

        private static void ViewProducts()
        {
            Console.Clear();
            Console.WriteLine("\n===== VIEW PRODUCTS =====");
            Console.WriteLine("1. View All Products");
            Console.WriteLine("2. Search Product");
            Console.WriteLine("3. Back to Main Menu");
            Console.WriteLine("=========================");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n(Display All Products)");
                    break;

                case "2":
                    Console.WriteLine("\n(Search Product)");
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("\nInvalid Option.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void CreateOrder()
        {
            Console.Clear();
            Console.WriteLine("\n===== ORDER MANAGEMENT =====");
            Console.WriteLine("1. Create New Order");
            Console.WriteLine("2. View My Orders");
            Console.WriteLine("3. Back to Main Menu");
            Console.WriteLine("============================");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n(Create Order)");
                    break;

                case "2":
                    Console.WriteLine("\n(Display My Orders)");
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("\nInvalid Option.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void ViewCustomers()
        {
            Console.Clear();
            Console.WriteLine("\n===== CUSTOMER INFORMATION =====");
            Console.WriteLine("1. View All Customers");
            Console.WriteLine("2. Search Customer");
            Console.WriteLine("3. Back to Main Menu");
            Console.WriteLine("================================");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n(Display All Customers)");
                    break;

                case "2":
                    Console.WriteLine("\n(Search Customer)");
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("\nInvalid Option.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
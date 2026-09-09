using System;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;
using ProductManagementSystem.Utilities;
using ProductManagementSystem.Menus;

class Program
{
    private static LoginService _loginService = new LoginService();
    private static EmployeeDetails _currentUser = null;

    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("  Product Management System");
        Console.WriteLine("========================================\n");

        // Check database connection
        if (!DBHelper.TestConnection())
        {
            Console.WriteLine("❌ Error: Cannot connect to database.");
            Console.WriteLine("Please check your connection string in DBHelper.cs");
            return;
        }

        Console.WriteLine("✅ Database connection successful.\n");

        // Login loop
        while (_currentUser == null)
        {
            DisplayLoginMenu();
        }

        // Display menu based on role
        MenuRouter.DisplayMenuByRole(_currentUser.RoleId, _currentUser);
        //DisplayMenuByRole();

        Console.WriteLine("\nThank you for using Product Management System!");
    }

    /// <summary>
    /// Displays login menu and handles authentication
    /// </summary>
    static void DisplayLoginMenu()
    {
        Console.WriteLine("========== LOGIN ==========");
        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = ReadPassword();

        _currentUser = _loginService.Authenticate(username, password);

        if (_currentUser != null)
        {
            Console.WriteLine($"\n✅ Login successful! Welcome, {username}\n");
            System.Threading.Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("\n❌ Login failed. Please try again.\n");
        }
    }

    /// <summary>
    /// Routes to menu based on user role
    /// </summary>
    static void DisplayMenuByRole()
    {
        // RoleId: 1 = Admin, 2 = Manager, 6 = Employee
        switch (_currentUser.RoleId)
        {
            case 1:
                AdminMenu.Display();
                break;
            case 2:
                ManagerMenu.Display();
                break;
            default:
                EmployeeMenu.Display();
                break;
        }
    }

    /// <summary>
    /// Reads password without displaying it
    /// </summary>
    static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }
}

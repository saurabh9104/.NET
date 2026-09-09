using System;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Menus
{
    /// <summary>
    /// Helper class with common menu utilities
    /// </summary>
    public static class MenuHelper
    {
        public static void ShowFeatureComingSoon(string featureName)
        {
            Console.Clear();
            Console.WriteLine($"\n--- {featureName} ---");
            Console.WriteLine("🚧 Feature coming soon!");
            Console.WriteLine("(Under development)");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void ChangePassword(EmployeeDetails currentUser)
        {
            Console.Clear();
            Console.WriteLine("\n--- Change Password ---");
            Console.Write("Current Password: ");
            string currentPassword = ReadPassword();

            if (currentPassword != currentUser.Password)
            {
                Console.WriteLine("❌ Current password is incorrect.");
                Console.ReadKey();
                return;
            }

            Console.Write("New Password: ");
            string newPassword = ReadPassword();

            Console.Write("Confirm Password: ");
            string confirmPassword = ReadPassword();

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("❌ Passwords do not match.");
                Console.ReadKey();
                return;
            }

            if (newPassword.Length < 6)
            {
                Console.WriteLine("❌ Password must be at least 6 characters long.");
                Console.ReadKey();
                return;
            }

            currentUser.Password = newPassword;
            Console.WriteLine("✅ Password changed successfully!");
            Console.ReadKey();
        }

        public static string ReadPassword()
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
}

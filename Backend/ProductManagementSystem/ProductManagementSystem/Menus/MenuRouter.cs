using ProductManagementSystem.Models;
using System;

namespace ProductManagementSystem.Menus
{
    /// <summary>
    /// Defines available user roles in the system
    /// </summary>
    public enum UserRole
    {
        Admin = 1,
        Manager = 2,
        HR = 3,
        Sales = 4,
        Inventory = 5,
        Employee = 6
    }

    /// <summary>
    /// Manages role-based menu navigation
    /// </summary>
    public static class MenuRouter
    {
        /// <summary>
        /// Routes to appropriate menu based on employee role
        /// </summary>
        public static void DisplayMenuByRole(int roleId, EmployeeDetails currentUser)
        {
            switch ((UserRole)roleId)
            {
                case UserRole.Admin:
                    AdminMenu.Display();
                    break;
                case UserRole.Manager:
                    ManagerMenu.Display();
                    break;
                //case UserRole.HR:
                //    HRMenu.DisplayMenu(currentUser);
                //    break;
                //case UserRole.Sales:
                //    SalesMenu.DisplayMenu(currentUser);
                //    break;
                //case UserRole.Inventory:
                //    InventoryMenu.DisplayMenu(currentUser);
                //    break;
                case UserRole.Employee:
                    EmployeeMenu.Display();
                    break;
                default:
                    Console.WriteLine("❌ Unknown role. Access denied.");
                    break;
            }
        }

        /// <summary>
        /// Gets role name from role ID
        /// </summary>
        public static string GetRoleName(int roleId)
        {
            return ((UserRole)roleId).ToString();
        }
    }
}

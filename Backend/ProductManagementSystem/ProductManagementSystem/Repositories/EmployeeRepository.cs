using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Utilities;

namespace ProductManagementSystem.Repositories
{
    public class EmployeeRepository
    {
        // CREATE
        public void Add(Employee employee)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"INSERT INTO Employee
                             (EmployeeName, DepartmentId, RoleId, Email, Phone)
                             VALUES
                             (@EmployeeName, @DepartmentId, @RoleId, @Email, @Phone)";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            cmd.Parameters.AddWithValue("@RoleId", employee.RoleId);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@Phone", employee.Phone);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        public Employee GetById(int employeeId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Employee WHERE EmployeeId = @EmployeeId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new Employee(
                        reader.GetInt32("EmployeeId"),
                        reader.GetString("EmployeeName"),
                        reader.GetInt32("DepartmentId"),
                        reader.GetString("Email"),
                        reader.GetString("Phone"),
                        reader.GetInt32("RoleId")
                    );
                }
            }
            return null;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Employee";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    employees.Add(new Employee(
                        reader.GetInt32("EmployeeId"),
                        reader.GetString("EmployeeName"),
                        reader.GetInt32("DepartmentId"),
                        reader.GetString("Email"),
                        reader.GetString("Phone"),
                        reader.GetInt32("RoleId")
                    ));
                }
            }
            return employees;
        }

        public List<Employee> GetByDepartment(int departmentId)
        {
            List<Employee> employees = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Employee WHERE DepartmentId = @DepartmentId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    employees.Add(new Employee(
                        reader.GetInt32("EmployeeId"),
                        reader.GetString("EmployeeName"),
                        reader.GetInt32("DepartmentId"),
                        reader.GetString("Email"),
                        reader.GetString("Phone"),
                        reader.GetInt32("RoleId")
                    ));
                }
            }
            return employees;
        }

        public List<Employee> GetByRole(int roleId)
        {
            List<Employee> employees = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Employee WHERE RoleId = @RoleId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@RoleId", roleId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    employees.Add(new Employee(
                        reader.GetInt32("EmployeeId"),
                        reader.GetString("EmployeeName"),
                        reader.GetInt32("DepartmentId"),
                        reader.GetString("Email"),
                        reader.GetString("Phone"),
                        reader.GetInt32("RoleId")
                    ));
                }
            }
            return employees;
        }

        // UPDATE
        public void Update(Employee employee)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE Employee 
                             SET EmployeeName = @EmployeeName, 
                                 DepartmentId = @DepartmentId, 
                                 RoleId = @RoleId, 
                                 Email = @Email, 
                                 Phone = @Phone 
                             WHERE EmployeeId = @EmployeeId";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            cmd.Parameters.AddWithValue("@RoleId", employee.RoleId);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@Phone", employee.Phone);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int employeeId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

            con.Open();
            cmd.ExecuteNonQuery();
        }
        


        // SEARCH
        public List<Employee> SearchByName(string name)
        {
            List<Employee> employees = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Employee WHERE EmployeeName LIKE @Name";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Name", $"%{name}%");

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    employees.Add(new Employee(
                        reader.GetInt32("EmployeeId"),
                        reader.GetString("EmployeeName"),
                        reader.GetInt32("DepartmentId"),
                        reader.GetString("Email"),
                        reader.GetString("Phone"),
                        reader.GetInt32("RoleId")
                    ));
                }
            }
            return employees;
        }
    }
}

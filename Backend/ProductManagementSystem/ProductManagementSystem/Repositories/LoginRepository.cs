using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Utilities;

namespace ProductManagement.Repository
{
    public class LoginRepository
    {
        public Employee Login(string username, string password)
        {
            Employee employee = null;

            using (MySqlConnection connection = DBHelper.GetConnection())
            {
                string query = @"
                SELECT
                    e.EmployeeId,
                    e.EmployeeName,
                    e.DepartmentId,
                    e.RoleId,
                    e.Email,
                    e.Phone,
                    r.RoleName
                FROM Employee e
                INNER JOIN EmployeeDetails ed
                    ON e.EmployeeId = ed.EmployeeId
                INNER JOIN Role r
                    ON e.RoleId = r.RoleId
                WHERE ed.Username = @Username
                  AND ed.Password = @Password
                  AND ed.Active = 1";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    employee = new Employee
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        EmployeeName = reader["EmployeeName"].ToString(),
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                        RoleId = Convert.ToInt32(reader["RoleId"]),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),

                        // Add this property to Employee model
                        RoleName = reader["RoleName"].ToString()
                    };
                }

                reader.Close();
            }

            return employee;
        }
    }
}
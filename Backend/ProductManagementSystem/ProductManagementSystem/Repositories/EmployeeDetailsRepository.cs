using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Utilities;

namespace ProductManagementSystem.Repositories
{
    public class EmployeeDetailsRepository
    {
        // CREATE
        public void Add(EmployeeDetails employeeDetails)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"INSERT INTO EmployeeDetails
                             (EmployeeId, AddressId, Phone, Email, DateOfBirth, JoiningDate, Username, Password, Salary, Active, RoleId)
                             VALUES
                             (@EmployeeId, @AddressId, @Phone, @Email, @DateOfBirth, @JoiningDate, @Username, @Password, @Salary, @Active, @RoleId)";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@EmployeeId", employeeDetails.EmployeeId);
            cmd.Parameters.AddWithValue("@AddressId", employeeDetails.AddressId);
            cmd.Parameters.AddWithValue("@Phone", employeeDetails.Phone);
            cmd.Parameters.AddWithValue("@Email", employeeDetails.Email);
            cmd.Parameters.AddWithValue("@DateOfBirth", employeeDetails.DateOfBirth);
            cmd.Parameters.AddWithValue("@JoiningDate", employeeDetails.JoiningDate);
            cmd.Parameters.AddWithValue("@Username", employeeDetails.Username);
            cmd.Parameters.AddWithValue("@Password", employeeDetails.Password);
            cmd.Parameters.AddWithValue("@Salary", employeeDetails.Salary);
            cmd.Parameters.AddWithValue("@Active", employeeDetails.Active);
            cmd.Parameters.AddWithValue("@RoleId", employeeDetails.RoleId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        public EmployeeDetails GetById(int employeeId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM EmployeeDetails WHERE EmployeeId = @EmployeeId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new EmployeeDetails(
                        reader.GetInt32("EmployeeId"),
                        reader.GetInt32("AddressId"),
                        reader.GetString("Phone"),
                        reader.GetString("Email"),
                        reader.GetDateTime("DateOfBirth"),
                        reader.GetDateTime("JoiningDate"),
                        reader.GetString("Username"),
                        reader.GetString("Password"),
                        reader.GetDecimal("Salary"),
                        reader.GetBoolean("Active"),
                        reader.GetInt32("RoleId")
                    );
                }
            }
            return null;
        }

        public List<EmployeeDetails> GetAll()
        {
            List<EmployeeDetails> employeeDetails = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM EmployeeDetails";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    employeeDetails.Add(new EmployeeDetails(
                        reader.GetInt32("EmployeeId"),
                        reader.GetInt32("AddressId"),
                        reader.GetString("Phone"),
                        reader.GetString("Email"),
                        reader.GetDateTime("DateOfBirth"),
                        reader.GetDateTime("JoiningDate"),
                        reader.GetString("Username"),
                        reader.GetString("Password"),
                        reader.GetDecimal("Salary"),
                        reader.GetBoolean("Active"),
                        reader.GetInt32("RoleId")
                    ));
                }
            }
            return employeeDetails;
        }

        public List<EmployeeDetails> GetActiveEmployees()
        {
            List<EmployeeDetails> employeeDetails = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM EmployeeDetails WHERE Active = true";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    employeeDetails.Add(new EmployeeDetails(
                        reader.GetInt32("EmployeeId"),
                        reader.GetInt32("AddressId"),
                        reader.GetString("Phone"),
                        reader.GetString("Email"),
                        reader.GetDateTime("DateOfBirth"),
                        reader.GetDateTime("JoiningDate"),
                        reader.GetString("Username"),
                        reader.GetString("Password"),
                        reader.GetDecimal("Salary"),
                        reader.GetBoolean("Active"),
                        reader.GetInt32("RoleId")
                    ));
                }
            }
            return employeeDetails;
        }

        public List<EmployeeDetails> GetInactiveEmployees()
        {
            List<EmployeeDetails> employeeDetails = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM EmployeeDetails WHERE Active = false";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    employeeDetails.Add(new EmployeeDetails(
                        reader.GetInt32("EmployeeId"),
                        reader.GetInt32("AddressId"),
                        reader.GetString("Phone"),
                        reader.GetString("Email"),
                        reader.GetDateTime("DateOfBirth"),
                        reader.GetDateTime("JoiningDate"),
                        reader.GetString("Username"),
                        reader.GetString("Password"),
                        reader.GetDecimal("Salary"),
                        reader.GetBoolean("Active"),
                        reader.GetInt32("RoleId")
                    ));
                }
            }
            return employeeDetails;
        }

        // UPDATE
        public void Update(EmployeeDetails employeeDetails)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE EmployeeDetails 
                             SET AddressId = @AddressId, 
                                 Phone = @Phone, 
                                 Email = @Email, 
                                 DateOfBirth = @DateOfBirth, 
                                 JoiningDate = @JoiningDate, 
                                 Username = @Username, 
                                 Password = @Password, 
                                 Salary = @Salary, 
                                 Active = @Active, 
                                 RoleId = @RoleId 
                             WHERE EmployeeId = @EmployeeId";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@EmployeeId", employeeDetails.EmployeeId);
            cmd.Parameters.AddWithValue("@AddressId", employeeDetails.AddressId);
            cmd.Parameters.AddWithValue("@Phone", employeeDetails.Phone);
            cmd.Parameters.AddWithValue("@Email", employeeDetails.Email);
            cmd.Parameters.AddWithValue("@DateOfBirth", employeeDetails.DateOfBirth);
            cmd.Parameters.AddWithValue("@JoiningDate", employeeDetails.JoiningDate);
            cmd.Parameters.AddWithValue("@Username", employeeDetails.Username);
            cmd.Parameters.AddWithValue("@Password", employeeDetails.Password);
            cmd.Parameters.AddWithValue("@Salary", employeeDetails.Salary);
            cmd.Parameters.AddWithValue("@Active", employeeDetails.Active);
            cmd.Parameters.AddWithValue("@RoleId", employeeDetails.RoleId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int employeeId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "DELETE FROM EmployeeDetails WHERE EmployeeId = @EmployeeId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // SEARCH & AUTHENTICATION
        public EmployeeDetails GetByUsername(string username)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM EmployeeDetails WHERE Username = @Username";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Username", username);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new EmployeeDetails(
                        reader.GetInt32("EmployeeId"),
                        reader.GetInt32("AddressId"),
                        reader.GetString("Phone"),
                        reader.GetString("Email"),
                        reader.GetDateTime("DateOfBirth"),
                        reader.GetDateTime("JoiningDate"),
                        reader.GetString("Username"),
                        reader.GetString("Password"),
                        reader.GetDecimal("Salary"),
                        reader.GetBoolean("Active"),
                        reader.GetInt32("RoleId")
                    );
                }
            }
            return null;
        }

        public bool ValidateCredentials(string username, string password)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT COUNT(*) FROM EmployeeDetails WHERE Username = @Username AND Password = @Password AND Active = true";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }
    }
}

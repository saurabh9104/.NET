using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Utilities;

namespace ProductManagementSystem.Repositories
{
    public class OrderRepository
    {
        // CREATE
        public void Add(Order order)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"INSERT INTO Orders
                             (CustomerId, EmployeeId, OrderDate, TotalAmount, Status, Remarks)
                             VALUES
                             (@CustomerId, @EmployeeId, @OrderDate, @TotalAmount, @Status, @Remarks)";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            cmd.Parameters.AddWithValue("@EmployeeId", order.EmployeeId);
            cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
            cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
            cmd.Parameters.AddWithValue("@Status", order.Status);
            cmd.Parameters.AddWithValue("@Remarks", order.Remarks ?? "");

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        public Order GetById(int orderId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Orders WHERE OrderId = @OrderId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@OrderId", orderId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new Order(
                        reader.GetInt32("OrderId"),
                        reader.GetInt32("CustomerId"),
                        reader.GetInt32("EmployeeId"),
                        reader.GetDateTime("OrderDate"),
                        reader.GetDecimal("TotalAmount"),
                        reader.GetString("Status"),
                        reader.GetString("Remarks")
                    );
                }
            }
            return null;
        }

        public List<Order> GetAll()
        {
            List<Order> orders = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Orders";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    orders.Add(new Order(
                        reader.GetInt32("OrderId"),
                        reader.GetInt32("CustomerId"),
                        reader.GetInt32("EmployeeId"),
                        reader.GetDateTime("OrderDate"),
                        reader.GetDecimal("TotalAmount"),
                        reader.GetString("Status"),
                        reader.GetString("Remarks")
                    ));
                }
            }
            return orders;
        }

        public List<Order> GetByCustomer(int customerId)
        {
            List<Order> orders = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Orders WHERE CustomerId = @CustomerId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@CustomerId", customerId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    orders.Add(new Order(
                        reader.GetInt32("OrderId"),
                        reader.GetInt32("CustomerId"),
                        reader.GetInt32("EmployeeId"),
                        reader.GetDateTime("OrderDate"),
                        reader.GetDecimal("TotalAmount"),
                        reader.GetString("Status"),
                        reader.GetString("Remarks")
                    ));
                }
            }
            return orders;
        }

        public List<Order> GetByEmployee(int employeeId)
        {
            List<Order> orders = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Orders WHERE EmployeeId = @EmployeeId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    orders.Add(new Order(
                        reader.GetInt32("OrderId"),
                        reader.GetInt32("CustomerId"),
                        reader.GetInt32("EmployeeId"),
                        reader.GetDateTime("OrderDate"),
                        reader.GetDecimal("TotalAmount"),
                        reader.GetString("Status"),
                        reader.GetString("Remarks")
                    ));
                }
            }
            return orders;
        }

        public List<Order> GetByStatus(string status)
        {
            List<Order> orders = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Orders WHERE Status = @Status";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Status", status);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    orders.Add(new Order(
                        reader.GetInt32("OrderId"),
                        reader.GetInt32("CustomerId"),
                        reader.GetInt32("EmployeeId"),
                        reader.GetDateTime("OrderDate"),
                        reader.GetDecimal("TotalAmount"),
                        reader.GetString("Status"),
                        reader.GetString("Remarks")
                    ));
                }
            }
            return orders;
        }

        // UPDATE
        public void Update(Order order)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE Orders 
                             SET CustomerId = @CustomerId, 
                                 EmployeeId = @EmployeeId, 
                                 OrderDate = @OrderDate, 
                                 TotalAmount = @TotalAmount, 
                                 Status = @Status, 
                                 Remarks = @Remarks 
                             WHERE OrderId = @OrderId";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@OrderId", order.OrderId);
            cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            cmd.Parameters.AddWithValue("@EmployeeId", order.EmployeeId);
            cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
            cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
            cmd.Parameters.AddWithValue("@Status", order.Status);
            cmd.Parameters.AddWithValue("@Remarks", order.Remarks ?? "");

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void UpdateStatus(int orderId, string status)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "UPDATE Orders SET Status = @Status WHERE OrderId = @OrderId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@OrderId", orderId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int orderId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "DELETE FROM Orders WHERE OrderId = @OrderId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@OrderId", orderId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // SEARCH
        public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Order> orders = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Orders WHERE OrderDate BETWEEN @StartDate AND @EndDate";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    orders.Add(new Order(
                        reader.GetInt32("OrderId"),
                        reader.GetInt32("CustomerId"),
                        reader.GetInt32("EmployeeId"),
                        reader.GetDateTime("OrderDate"),
                        reader.GetDecimal("TotalAmount"),
                        reader.GetString("Status"),
                        reader.GetString("Remarks")
                    ));
                }
            }
            return orders;
        }
    }
}

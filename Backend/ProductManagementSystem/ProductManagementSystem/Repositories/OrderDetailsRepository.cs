using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Utilities;

namespace ProductManagementSystem.Repositories
{
    public class OrderDetailsRepository
    {
        // CREATE
        public void Add(OrderDetails orderDetails)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"INSERT INTO OrderDetails
                             (OrderId, ProductId, Quantity, Price, Discount)
                             VALUES
                             (@OrderId, @ProductId, @Quantity, @Price, @Discount)";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@OrderId", orderDetails.OrderId);
            cmd.Parameters.AddWithValue("@ProductId", orderDetails.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", orderDetails.Quantity);
            cmd.Parameters.AddWithValue("@Price", orderDetails.Price);
            cmd.Parameters.AddWithValue("@Discount", orderDetails.Discount);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        public OrderDetails GetById(int orderDetailId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM OrderDetails WHERE OrderDetailId = @OrderDetailId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@OrderDetailId", orderDetailId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new OrderDetails(
                        reader.GetInt32("OrderDetailId"),
                        reader.GetInt32("OrderId"),
                        reader.GetInt32("ProductId"),
                        reader.GetInt32("Quantity"),
                        reader.GetDecimal("Price"),
                        reader.GetDecimal("Discount")
                    );
                }
            }
            return null;
        }

        public List<OrderDetails> GetAll()
        {
            List<OrderDetails> orderDetails = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM OrderDetails";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    orderDetails.Add(new OrderDetails(
                        reader.GetInt32("OrderDetailId"),
                        reader.GetInt32("OrderId"),
                        reader.GetInt32("ProductId"),
                        reader.GetInt32("Quantity"),
                        reader.GetDecimal("Price"),
                        reader.GetDecimal("Discount")
                    ));
                }
            }
            return orderDetails;
        }

        public List<OrderDetails> GetByOrder(int orderId)
        {
            List<OrderDetails> orderDetails = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM OrderDetails WHERE OrderId = @OrderId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@OrderId", orderId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    orderDetails.Add(new OrderDetails(
                        reader.GetInt32("OrderDetailId"),
                        reader.GetInt32("OrderId"),
                        reader.GetInt32("ProductId"),
                        reader.GetInt32("Quantity"),
                        reader.GetDecimal("Price"),
                        reader.GetDecimal("Discount")
                    ));
                }
            }
            return orderDetails;
        }

        public List<OrderDetails> GetByProduct(int productId)
        {
            List<OrderDetails> orderDetails = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM OrderDetails WHERE ProductId = @ProductId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@ProductId", productId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    orderDetails.Add(new OrderDetails(
                        reader.GetInt32("OrderDetailId"),
                        reader.GetInt32("OrderId"),
                        reader.GetInt32("ProductId"),
                        reader.GetInt32("Quantity"),
                        reader.GetDecimal("Price"),
                        reader.GetDecimal("Discount")
                    ));
                }
            }
            return orderDetails;
        }

        // UPDATE
        public void Update(OrderDetails orderDetails)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE OrderDetails 
                             SET OrderId = @OrderId, 
                                 ProductId = @ProductId, 
                                 Quantity = @Quantity, 
                                 Price = @Price, 
                                 Discount = @Discount 
                             WHERE OrderDetailId = @OrderDetailId";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@OrderDetailId", orderDetails.OrderDetailId);
            cmd.Parameters.AddWithValue("@OrderId", orderDetails.OrderId);
            cmd.Parameters.AddWithValue("@ProductId", orderDetails.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", orderDetails.Quantity);
            cmd.Parameters.AddWithValue("@Price", orderDetails.Price);
            cmd.Parameters.AddWithValue("@Discount", orderDetails.Discount);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int orderDetailId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "DELETE FROM OrderDetails WHERE OrderDetailId = @OrderDetailId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@OrderDetailId", orderDetailId);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}

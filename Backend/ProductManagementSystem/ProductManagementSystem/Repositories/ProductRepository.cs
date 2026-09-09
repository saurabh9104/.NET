using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Utilities;

namespace ProductManagementSystem.Repositories
{
    public class ProductRepository
    {
        // CREATE
        public void Add(Product product)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"INSERT INTO Product
                             (ProductName, CategoryId, Price, Quantity, ReorderLevel)
                             VALUES
                             (@ProductName, @CategoryId, @Price, @Quantity, @ReorderLevel)";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        public Product GetById(int productId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Product WHERE ProductId = @ProductId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@ProductId", productId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new Product(
                        reader.GetInt32("ProductId"),
                        reader.GetString("ProductName"),
                        reader.GetInt32("CategoryId"),
                        reader.GetDecimal("Price"),
                        reader.GetInt32("Quantity"),
                        reader.GetInt32("ReorderLevel")
                    );
                }
            }
            return null;
        }

        public List<Product> GetAll()
        {
            List<Product> products = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Product";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    products.Add(new Product(
                        reader.GetInt32("ProductId"),
                        reader.GetString("ProductName"),
                        reader.GetInt32("CategoryId"),
                        reader.GetDecimal("Price"),
                        reader.GetInt32("Quantity"),
                        reader.GetInt32("ReorderLevel")
                    ));
                }
            }
            return products;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            List<Product> products = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Product WHERE CategoryId = @CategoryId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    products.Add(new Product(
                        reader.GetInt32("ProductId"),
                        reader.GetString("ProductName"),
                        reader.GetInt32("CategoryId"),
                        reader.GetDecimal("Price"),
                        reader.GetInt32("Quantity"),
                        reader.GetInt32("ReorderLevel")
                    ));
                }
            }
            return products;
        }

        // UPDATE
        public void Update(Product product)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE Product 
                             SET ProductName = @ProductName, 
                                 CategoryId = @CategoryId, 
                                 Price = @Price, 
                                 Quantity = @Quantity, 
                                 ReorderLevel = @ReorderLevel 
                             WHERE ProductId = @ProductId";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int productId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "DELETE FROM Product WHERE ProductId = @ProductId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@ProductId", productId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // SEARCH
        public List<Product> SearchByName(string name)
        {
            List<Product> products = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Product WHERE ProductName LIKE @Name";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Name", $"%{name}%");

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    products.Add(new Product(
                        reader.GetInt32("ProductId"),
                        reader.GetString("ProductName"),
                        reader.GetInt32("CategoryId"),
                        reader.GetDecimal("Price"),
                        reader.GetInt32("Quantity"),
                        reader.GetInt32("ReorderLevel")
                    ));
                }
            }
            return products;
        }

        // STOCK MANAGEMENT
        public List<Product> GetLowStockProducts()
        {
            List<Product> products = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Product WHERE Quantity <= ReorderLevel";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    products.Add(new Product(
                        reader.GetInt32("ProductId"),
                        reader.GetString("ProductName"),
                        reader.GetInt32("CategoryId"),
                        reader.GetDecimal("Price"),
                        reader.GetInt32("Quantity"),
                        reader.GetInt32("ReorderLevel")
                    ));
                }
            }
            return products;
        }

        public void UpdateQuantity(int productId, int newQuantity)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "UPDATE Product SET Quantity = @Quantity WHERE ProductId = @ProductId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Quantity", newQuantity);
            cmd.Parameters.AddWithValue("@ProductId", productId);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}

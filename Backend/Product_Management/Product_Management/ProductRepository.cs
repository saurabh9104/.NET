using System;
using MySql.Data.MySqlClient;

namespace Product_Management
{
    public class ProductRepository
    {
        // Insert
        public void AddProduct(Product product)
        {
            try
            {
                using var con = DBHelper.GetOpenConnection();
                var query = @"INSERT INTO Product
                                (ProductName,CategoryId,Price,Quantity)
                                VALUES
                                (@name,@category,@price,@quantity)";

                using var cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", product.ProductName ?? string.Empty);
                cmd.Parameters.AddWithValue("@category", product.CategoryId);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@quantity", product.Quantity);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException msex)
            {
                Console.Error.WriteLine("Database error while inserting product: " + msex.Message);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unexpected error while inserting product: " + ex.Message);
            }
        }

        // Display
        public void DisplayProducts()
        {
            try
            {
                using var con = DBHelper.GetOpenConnection();
                var query = @"SELECT p.ProductId, p.ProductName, c.CategoryName, p.Price, p.Quantity 
                      FROM Product p
                      JOIN Category c ON p.CategoryId = c.CategoryId";
                using var cmd = new MySqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("ID\tName\tCategory\tPrice\tQty");
                Console.WriteLine("-------------------------------------------------------");

                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}\t{reader.GetString(1)}\t{reader.GetString(2)}\t{reader.GetDecimal(3)}\t{reader.GetDecimal(4)}");
                }
            }
            catch (MySqlException msex)
            {
                Console.Error.WriteLine("Database error while displaying products: " + msex.Message);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unexpected error while displaying products: " + ex.Message);
            }
        }

        // Update
        public void UpdateProduct(Product product)
        {
            try
            {
                using var con = DBHelper.GetOpenConnection();
                var query = @"UPDATE Product
                                SET ProductName=@name,
                                    CategoryId=@category,
                                    Price=@price,
                                    Quantity=@quantity
                                WHERE ProductId=@id";

                using var cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", product.ProductId);
                cmd.Parameters.AddWithValue("@name", product.ProductName ?? string.Empty);
                cmd.Parameters.AddWithValue("@category", product.CategoryId);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@quantity", product.Quantity);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException msex)
            {
                Console.Error.WriteLine("Database error while updating product: " + msex.Message);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unexpected error while updating product: " + ex.Message);
            }
        }

        // Delete
        public void DeleteProduct(int id)
        {
            try
            {
                using var con = DBHelper.GetOpenConnection();
                var query = "DELETE FROM Product WHERE ProductId=@id";
                using var cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException msex)
            {
                Console.Error.WriteLine("Database error while deleting product: " + msex.Message);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unexpected error while deleting product: " + ex.Message);
            }
        }
    }
}
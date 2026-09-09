using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Utilities;

namespace ProductManagementSystem.Repositories
{
    public class CategoryRepository
    {
        // CREATE
        public void Add(Category category)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"INSERT INTO Category
                             (CategoryName, Description, LastUpdate)
                             VALUES
                             (@CategoryName, @Description, @LastUpdate)";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            cmd.Parameters.AddWithValue("@Description", category.Description);
            cmd.Parameters.AddWithValue("@LastUpdate", category.LastUpdate);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        public Category GetById(int categoryId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Category WHERE CategoryId = @CategoryId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new Category(
                        reader.GetInt32("CategoryId"),
                        reader.GetString("CategoryName"),
                        reader.GetString("Description"),
                        reader.GetDateTime("LastUpdate")
                    );
                }
            }
            return null;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Category";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    categories.Add(new Category(
                        reader.GetInt32("CategoryId"),
                        reader.GetString("CategoryName"),
                        reader.GetString("Description"),
                        reader.GetDateTime("LastUpdate")
                    ));
                }
            }
            return categories;
        }

        // UPDATE
        public void Update(Category category)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE Category 
                             SET CategoryName = @CategoryName, 
                                 Description = @Description, 
                                 LastUpdate = @LastUpdate 
                             WHERE CategoryId = @CategoryId";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@CategoryId", category.CategoryId);
            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            cmd.Parameters.AddWithValue("@Description", category.Description);
            cmd.Parameters.AddWithValue("@LastUpdate", category.LastUpdate);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int categoryId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "DELETE FROM Category WHERE CategoryId = @CategoryId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // SEARCH
        public List<Category> SearchByName(string name)
        {
            List<Category> categories = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Category WHERE CategoryName LIKE @Name";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Name", $"%{name}%");

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    categories.Add(new Category(
                        reader.GetInt32("CategoryId"),
                        reader.GetString("CategoryName"),
                        reader.GetString("Description"),
                        reader.GetDateTime("LastUpdate")
                    ));
                }
            }
            return categories;
        }
    }
}

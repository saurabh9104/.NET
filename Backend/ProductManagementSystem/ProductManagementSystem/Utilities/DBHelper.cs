using MySql.Data.MySqlClient;
using System;

namespace ProductManagementSystem.Utilities
{
    public static class DBHelper
    {
        // Connection string - Update with your database credentials
        private static readonly string ConnectionString = "Server=127.0.0.1;Database=ProductManagementSystem;User Id=root;Password=@S123456p;Port=3306;";

        /// <summary>
        /// Gets a new MySQL database connection
        /// </summary>
        /// <returns>MySqlConnection object</returns>
        public static MySqlConnection GetConnection()
        {
            try
            {
                return new MySqlConnection(ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception($"Database connection error: {ex.Message}");
            }
        }

        /// <summary>
        /// Tests the database connection
        /// </summary>
        /// <returns>True if connection is successful, False otherwise</returns>
        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection con = GetConnection())
                {
                    con.Open();
                    return con.State == System.Data.ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

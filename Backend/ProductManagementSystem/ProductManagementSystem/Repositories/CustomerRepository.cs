using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Utilities;

namespace ProductManagementSystem.Repositories
{
    public class CustomerRepository
    {
        // CREATE
        public void Add(Customer customer)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"INSERT INTO Customer
                             (CustomerName, Phone, Email, AddressId)
                             VALUES
                             (@CustomerName, @Phone, @Email, @AddressId)";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
            cmd.Parameters.AddWithValue("@Phone", customer.Phone);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@AddressId", customer.AddressId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        public Customer GetById(int customerId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Customer WHERE CustomerId = @CustomerId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@CustomerId", customerId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new Customer(
                        reader.GetInt32("CustomerId"),
                        reader.GetString("CustomerName"),
                        reader.GetString("Phone"),
                        reader.GetString("Email"),
                        reader.GetInt32("AddressId")
                    );
                }
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Customer";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    customers.Add(new Customer(
                        reader.GetInt32("CustomerId"),
                        reader.GetString("CustomerName"),
                        reader.GetString("Phone"),
                        reader.GetString("Email"),
                        reader.GetInt32("AddressId")
                    ));
                }
            }
            return customers;
        }

        // UPDATE
        public void Update(Customer customer)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE Customer 
                             SET CustomerName = @CustomerName, 
                                 Phone = @Phone, 
                                 Email = @Email, 
                                 AddressId = @AddressId 
                             WHERE CustomerId = @CustomerId";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
            cmd.Parameters.AddWithValue("@Phone", customer.Phone);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@AddressId", customer.AddressId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int customerId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "DELETE FROM Customer WHERE CustomerId = @CustomerId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@CustomerId", customerId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // SEARCH
        public List<Customer> SearchByName(string name)
        {
            List<Customer> customers = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Customer WHERE CustomerName LIKE @Name";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Name", $"%{name}%");

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    customers.Add(new Customer(
                        reader.GetInt32("CustomerId"),
                        reader.GetString("CustomerName"),
                        reader.GetString("Phone"),
                        reader.GetString("Email"),
                        reader.GetInt32("AddressId")
                    ));
                }
            }
            return customers;
        }

        public Customer GetByEmail(string email)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Customer WHERE Email = @Email";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Email", email);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new Customer(
                        reader.GetInt32("CustomerId"),
                        reader.GetString("CustomerName"),
                        reader.GetString("Phone"),
                        reader.GetString("Email"),
                        reader.GetInt32("AddressId")
                    );
                }
            }
            return null;
        }

        public Customer GetByPhone(string phone)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Customer WHERE Phone = @Phone";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Phone", phone);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new Customer(
                        reader.GetInt32("CustomerId"),
                        reader.GetString("CustomerName"),
                        reader.GetString("Phone"),
                        reader.GetString("Email"),
                        reader.GetInt32("AddressId")
                    );
                }
            }
            return null;
        }
    }
}

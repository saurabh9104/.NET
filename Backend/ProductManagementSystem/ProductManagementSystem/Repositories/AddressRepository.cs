using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Utilities;

namespace ProductManagementSystem.Repositories
{
    public class AddressRepository
    {
        // CREATE
        public void Add(Address address)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"INSERT INTO Address
                             (HouseNo, Street, City, State, Pincode, Country)
                             VALUES
                             (@HouseNo, @Street, @City, @State, @Pincode, @Country)";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@HouseNo", address.HouseNo);
            cmd.Parameters.AddWithValue("@Street", address.Street);
            cmd.Parameters.AddWithValue("@City", address.City);
            cmd.Parameters.AddWithValue("@State", address.State);
            cmd.Parameters.AddWithValue("@Pincode", address.Pincode);
            cmd.Parameters.AddWithValue("@Country", address.Country);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        public Address GetById(int addressId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Address WHERE AddressId = @AddressId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@AddressId", addressId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new Address(
                        reader.GetInt32("AddressId"),
                        reader.GetString("HouseNo"),
                        reader.GetString("Street"),
                        reader.GetString("City"),
                        reader.GetString("State"),
                        reader.GetString("Pincode"),
                        reader.GetString("Country")
                    );
                }
            }
            return null;
        }

        public List<Address> GetAll()
        {
            List<Address> addresses = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Address";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    addresses.Add(new Address(
                        reader.GetInt32("AddressId"),
                        reader.GetString("HouseNo"),
                        reader.GetString("Street"),
                        reader.GetString("City"),
                        reader.GetString("State"),
                        reader.GetString("Pincode"),
                        reader.GetString("Country")
                    ));
                }
            }
            return addresses;
        }

        // UPDATE
        public void Update(Address address)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE Address 
                             SET HouseNo = @HouseNo, 
                                 Street = @Street, 
                                 City = @City, 
                                 State = @State, 
                                 Pincode = @Pincode, 
                                 Country = @Country 
                             WHERE AddressId = @AddressId";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@AddressId", address.AddressId);
            cmd.Parameters.AddWithValue("@HouseNo", address.HouseNo);
            cmd.Parameters.AddWithValue("@Street", address.Street);
            cmd.Parameters.AddWithValue("@City", address.City);
            cmd.Parameters.AddWithValue("@State", address.State);
            cmd.Parameters.AddWithValue("@Pincode", address.Pincode);
            cmd.Parameters.AddWithValue("@Country", address.Country);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int addressId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "DELETE FROM Address WHERE AddressId = @AddressId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@AddressId", addressId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // SEARCH
        public List<Address> SearchByCity(string city)
        {
            List<Address> addresses = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Address WHERE City LIKE @City";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@City", $"%{city}%");

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    addresses.Add(new Address(
                        reader.GetInt32("AddressId"),
                        reader.GetString("HouseNo"),
                        reader.GetString("Street"),
                        reader.GetString("City"),
                        reader.GetString("State"),
                        reader.GetString("Pincode"),
                        reader.GetString("Country")
                    ));
                }
            }
            return addresses;
        }

        public List<Address> SearchByState(string state)
        {
            List<Address> addresses = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Address WHERE State LIKE @State";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@State", $"%{state}%");

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    addresses.Add(new Address(
                        reader.GetInt32("AddressId"),
                        reader.GetString("HouseNo"),
                        reader.GetString("Street"),
                        reader.GetString("City"),
                        reader.GetString("State"),
                        reader.GetString("Pincode"),
                        reader.GetString("Country")
                    ));
                }
            }
            return addresses;
        }

        public List<Address> SearchByCountry(string country)
        {
            List<Address> addresses = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Address WHERE Country LIKE @Country";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Country", $"%{country}%");

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    addresses.Add(new Address(
                        reader.GetInt32("AddressId"),
                        reader.GetString("HouseNo"),
                        reader.GetString("Street"),
                        reader.GetString("City"),
                        reader.GetString("State"),
                        reader.GetString("Pincode"),
                        reader.GetString("Country")
                    ));
                }
            }
            return addresses;
        }
    }
}

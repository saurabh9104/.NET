using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Utilities;

namespace ProductManagementSystem.Repositories
{
    public class RoleRepository
    {
        // CREATE
        public void Add(Role role)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"INSERT INTO Role
                             (RoleName, Description)
                             VALUES
                             (@RoleName, @Description)";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
            cmd.Parameters.AddWithValue("@Description", role.Description);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        public Role GetById(int roleId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Role WHERE RoleId = @RoleId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@RoleId", roleId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new Role(
                        reader.GetInt32("RoleId"),
                        reader.GetString("RoleName"),
                        reader.GetString("Description")
                    );
                }
            }
            return null;
        }

        public List<Role> GetAll()
        {
            List<Role> roles = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Role";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    roles.Add(new Role(
                        reader.GetInt32("RoleId"),
                        reader.GetString("RoleName"),
                        reader.GetString("Description")
                    ));
                }
            }
            return roles;
        }

        // UPDATE
        public void Update(Role role)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE Role 
                             SET RoleName = @RoleName, 
                                 Description = @Description 
                             WHERE RoleId = @RoleId";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@RoleId", role.RoleId);
            cmd.Parameters.AddWithValue("@RoleName", role.RoleName);
            cmd.Parameters.AddWithValue("@Description", role.Description);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int roleId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "DELETE FROM Role WHERE RoleId = @RoleId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@RoleId", roleId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // SEARCH
        public List<Role> SearchByName(string name)
        {
            List<Role> roles = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Role WHERE RoleName LIKE @Name";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Name", $"%{name}%");

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    roles.Add(new Role(
                        reader.GetInt32("RoleId"),
                        reader.GetString("RoleName"),
                        reader.GetString("Description")
                    ));
                }
            }
            return roles;
        }
    }
}

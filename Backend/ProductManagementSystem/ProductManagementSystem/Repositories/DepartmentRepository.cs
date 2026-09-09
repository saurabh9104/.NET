using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ProductManagementSystem.Models;
using ProductManagementSystem.Utilities;

namespace ProductManagementSystem.Repositories
{
    public class DepartmentRepository
    {
        // CREATE
        public void Add(Department department)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"INSERT INTO Department
                             (DepartmentName, Description)
                             VALUES
                             (@DepartmentName, @Description)";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
            cmd.Parameters.AddWithValue("@Description", department.Description);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        public Department GetById(int departmentId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Department WHERE DepartmentId = @DepartmentId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new Department(
                        reader.GetInt32("DepartmentId"),
                        reader.GetString("DepartmentName"),
                        reader.GetString("Description")
                    );
                }
            }
            return null;
        }

        public List<Department> GetAll()
        {
            List<Department> departments = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Department";

            MySqlCommand cmd = new(query, con);

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    departments.Add(new Department(
                        reader.GetInt32("DepartmentId"),
                        reader.GetString("DepartmentName"),
                        reader.GetString("Description")
                    ));
                }
            }
            return departments;
        }

        // UPDATE
        public void Update(Department department)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = @"UPDATE Department 
                             SET DepartmentName = @DepartmentName, 
                                 Description = @Description 
                             WHERE DepartmentId = @DepartmentId";

            MySqlCommand cmd = new(query, con);

            cmd.Parameters.AddWithValue("@DepartmentId", department.DepartmentId);
            cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
            cmd.Parameters.AddWithValue("@Description", department.Description);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void Delete(int departmentId)
        {
            using MySqlConnection con = DBHelper.GetConnection();

            string query = "DELETE FROM Department WHERE DepartmentId = @DepartmentId";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // SEARCH
        public List<Department> SearchByName(string name)
        {
            List<Department> departments = new();

            using MySqlConnection con = DBHelper.GetConnection();

            string query = "SELECT * FROM Department WHERE DepartmentName LIKE @Name";

            MySqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Name", $"%{name}%");

            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    departments.Add(new Department(
                        reader.GetInt32("DepartmentId"),
                        reader.GetString("DepartmentName"),
                        reader.GetString("Description")
                    ));
                }
            }
            return departments;
        }
    }
}

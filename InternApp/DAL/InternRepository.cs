using InternApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InternApp.DAL
{
    public class InternRepository
    {
        private readonly DbHelper _dbHelper;

        public InternRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Get All Interns
        public List<Intern> GetInterns()
        {
            List<Intern> interns = new();

            using SqlConnection con = _dbHelper.GetConnection();

            string query = "SELECT * FROM Interns";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                interns.Add(new Intern
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Department = reader["Department"].ToString(),
                    DurationInMonths = Convert.ToInt32(reader["DurationInMonths"])
                });
            }

            return interns;
        }

        // Add Intern
        public void AddIntern(Intern intern)
        {
            using SqlConnection con = _dbHelper.GetConnection();

            string query = @"INSERT INTO Interns(Name,Email,Department,DurationInMonths)
                             VALUES(@Name,@Email,@Department,@DurationInMonths)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Name", intern.Name);
            cmd.Parameters.AddWithValue("@Email", intern.Email);
            cmd.Parameters.AddWithValue("@Department", intern.Department);
            cmd.Parameters.AddWithValue("@DurationInMonths", intern.DurationInMonths);

            con.Open();

            cmd.ExecuteNonQuery();
        }

        // Get Intern By Id
        public Intern GetInternById(int id)
        {
            Intern intern = new();

            using SqlConnection con = _dbHelper.GetConnection();

            string query = "SELECT * FROM Interns WHERE Id=@Id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                intern.Id = Convert.ToInt32(reader["Id"]);
                intern.Name = reader["Name"].ToString();
                intern.Email = reader["Email"].ToString();
                intern.Department = reader["Department"].ToString();
                intern.DurationInMonths = Convert.ToInt32(reader["DurationInMonths"]);
            }

            return intern;
        }

        // Update Intern
        public void UpdateIntern(Intern intern)
        {
            using SqlConnection con = _dbHelper.GetConnection();

            string query = @"UPDATE Interns
                             SET Name=@Name,
                                 Email=@Email,
                                 Department=@Department,
                                 DurationInMonths=@DurationInMonths
                             WHERE Id=@Id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Id", intern.Id);
            cmd.Parameters.AddWithValue("@Name", intern.Name);
            cmd.Parameters.AddWithValue("@Email", intern.Email);
            cmd.Parameters.AddWithValue("@Department", intern.Department);
            cmd.Parameters.AddWithValue("@DurationInMonths", intern.DurationInMonths);

            con.Open();

            cmd.ExecuteNonQuery();
        }

        // Delete Intern
        public void DeleteIntern(int id)
        {
            using SqlConnection con = _dbHelper.GetConnection();

            string query = "DELETE FROM Interns WHERE Id=@Id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();

            cmd.ExecuteNonQuery();
        }
    }
}

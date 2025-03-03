using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.BusinessLayer.IRepository;
using TurfBooking.BusinessLayer.Model;

namespace TurfBooking.DataAccessLayer.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public int Create(Admin admin)
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("CreateAdmin", con);
            cmd.Parameters.AddWithValue("@Email", admin.Email);
            cmd.Parameters.AddWithValue("@Password", admin.Password);

            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();

            con.Close();
            return result;
        }

        public Admin GetByEmail(string email)
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetAdminByEmail", conn);
            cmd.Parameters.AddWithValue("@Email", email);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            var admin = new Admin();

            while (reader.Read())
            {
                admin.Id = Convert.ToInt32(reader["AdminId"]);
                admin.Email = Convert.ToString(reader["Email"]);
                admin.Password = Convert.ToString(reader["Password"]);
            }

            if (admin.Id == 0)
            {
                return null;
            }
            conn.Close();
            return admin;
        }
    }
}

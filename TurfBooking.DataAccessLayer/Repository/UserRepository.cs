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
    public class UserRepository : IUserRepository
    {
        public int Create(User user)
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("CreateUser", con);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();

            con.Close();
            return result;
        }

        public int Delete(int userId)
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("DeleteUser", con);
            cmd.Parameters.AddWithValue("@UserId", userId);

            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();

            con.Close();

            return result;
        }

        public List<User> GetAllUser()
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("GetAllUser", con);
            cmd.CommandType= CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            var userList = new List<User>();

            while(reader.Read())
            {
                var user = new User
                {
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Name = Convert.ToString(reader["Name"]),
                    Email = Convert.ToString(reader["Email"]),
                    PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]),
                    Password = Convert.ToString(reader["Password"])
                };
                userList.Add(user);
            }

            con.Close();
            return userList;
        }

        public User GetById(int userId)
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetById", conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            var user = new User();

            while(reader.Read())
            {
                user.UserId = Convert.ToInt32(reader["UserId"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.Email = Convert.ToString(reader["Email"]);
                user.PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]);
                user.Password = Convert.ToString(reader["Password"]);
            }
            conn.Close();
            return user;
        }

        public int Update(User user)
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("UpdateUser", conn);
            cmd.Parameters.AddWithValue("@UserId", user.Name);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();

            conn.Close();

            return result;
        }

        public User GetByEmail(string email)
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetUserByEmail", conn);
            cmd.Parameters.AddWithValue("@Email", email);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            var user = new User();

            while (reader.Read())
            {
                user.UserId = Convert.ToInt32(reader["UserId"]);
                user.Name = Convert.ToString(reader["Name"]);
                user.Email = Convert.ToString(reader["Email"]);
                user.PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]);
                user.Password = Convert.ToString(reader["Password"]);
            }

            if(user.UserId == 0)
            {
                return null;
            }
            conn.Close();
            return user;
        }

        public List<Booking> GetUserBookingsById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

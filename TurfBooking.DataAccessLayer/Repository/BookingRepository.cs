using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.BusinessLayer.IRepository;
using TurfBooking.BusinessLayer.Model;
using TurfBooking.DataAccessLayer.DatabaseConnections;

namespace TurfBooking.DataAccessLayer.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public int Create(Booking booking)
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            SqlCommand cmd = new SqlCommand("CreateBooking",con);
            cmd.Parameters.AddWithValue("@Name", booking.Name);
            cmd.Parameters.AddWithValue("@Email", booking.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", booking.PhoneNumber);
            cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate.ToDateTime(TimeOnly.MinValue)); 
            cmd.Parameters.AddWithValue("@StartTime", booking.StartTime.ToTimeSpan()); 
            cmd.Parameters.AddWithValue("@EndTime", booking.EndTime.ToTimeSpan()); 

            cmd.Parameters.AddWithValue("@TurfId", 1);
            cmd.Parameters.AddWithValue("@UserId", booking.UserId);
            cmd.Parameters.AddWithValue("BookingStatus", booking.Status);
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result; 
        }
        public void Delete(int bookingId)
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteBooking", con);
            cmd.Parameters.AddWithValue("@BookingId", bookingId);
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Booking> GetAllBooking()
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("GetAllBooking", con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            var BookingList = new List<Booking>();
            while (sqlDataReader.Read())
            {
                Booking booking = new Booking();
                booking.BookingId = Convert.ToInt32(sqlDataReader["BookingId"]);
                booking.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
                booking.TurfId = Convert.ToInt32(sqlDataReader["TurfId"]);
                booking.Email = Convert.ToString(sqlDataReader["Email"]);
                booking.PhoneNumber = Convert.ToDouble(sqlDataReader["PhoneNumber"]);
                booking.BookingDate = DateOnly.FromDateTime(Convert.ToDateTime(sqlDataReader["BookingDate"]));
                booking.StartTime = TimeOnly.FromTimeSpan((TimeSpan)sqlDataReader["StartTime"]);
                booking.EndTime = TimeOnly.FromTimeSpan((TimeSpan)sqlDataReader["EndTime"]);
                booking.Status = Convert.ToBoolean(sqlDataReader["Status"]);
                BookingList.Add(booking);
            }
            return BookingList;
        }
        public Booking GetById(int bookingId)
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetById", conn);
            cmd.Parameters.AddWithValue("@UserId", bookingId);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            var booking = new Booking();

            while (reader.Read())
            {
                booking.BookingId = Convert.ToInt32(reader["BookingId"]);
                booking.Name = Convert.ToString(reader["Name"]);
                booking.Email = Convert.ToString(reader["Email"]);
                booking.TurfId = Convert.ToInt32(reader["TurfId"]);
                booking.PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]);
                booking.UserId = Convert.ToInt32(reader["UserId"]);
                booking.StartTime = TimeOnly.FromTimeSpan((TimeSpan)reader["StartTime"]);
                booking.EndTime = TimeOnly.FromTimeSpan((TimeSpan)reader["EndTime"]);
                booking.BookingDate = DateOnly.FromDateTime((DateTime)reader["BookingDate"]);
                booking.Status = Convert.ToBoolean(reader["Status"]);
            }
            conn.Close();

            return booking;
        }

        public int Update(Booking booking)
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateBooking", con);
            cmd.Parameters.AddWithValue("@BookingId", booking.BookingId);
            //cmd.Parameters.AddWithValue("@Name", booking.Name);
            //cmd.Parameters.AddWithValue("@Email", booking.Email);
            //cmd.Parameters.AddWithValue("@PhoneNumber", booking.PhoneNumber);
            cmd.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
            cmd.Parameters.AddWithValue("@StartTime", booking.StartTime);
            cmd.Parameters.AddWithValue("@Endtime", booking.EndTime);
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public List<Booking> GetBookingsByUserId(int userId)
        {
            List<Booking> bookings = new List<Booking>();
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Booking WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bookings.Add(new Booking
                    {
                        BookingId = Convert.ToInt32(reader["BookingId"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        TurfId = Convert.ToInt32(reader["TurfId"]),
                        UserId = Convert.ToInt32(reader["UserId"]),
                        PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]),
                        StartTime = TimeOnly.FromTimeSpan((TimeSpan)reader["StartTime"]),
                        EndTime = TimeOnly.FromTimeSpan((TimeSpan)reader["EndTime"]),
                        BookingDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["BookingDate"])),
                        Status = Convert.ToBoolean(reader["Status"]) 
                    });
                }

                reader.Close();
            }

            return bookings;
        }


    }
}

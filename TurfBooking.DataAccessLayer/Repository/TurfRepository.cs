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
    public class TurfRepository : ITurfRepository
    {
        public IEnumerable<Turf> GetAllTurf()
        {
            string connectionString = "Server=localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("GetAllTurf", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            var turfList = new List<Turf>();

            while (reader.Read())
            {
                var turf = new Turf
                {
                    TurfId = Convert.ToInt32(reader["TurfId"]),
                    Location = Convert.ToString(reader["Location"]),
                    Availability = Convert.ToBoolean(reader["Availability"])
                };
                turfList.Add(turf);
            }

            con.Close();

            if(turfList.Count == 0)
            {
                return null;
            }
            return turfList;
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.BusinessLayer.IRepository;

namespace TurfBooking.DataAccessLayer.DatabaseConnections
{
    public class TurfDbConnection : ITurfDbConnection
    {
        private string connectionString = "localhost;Database=TurfBooking;Integrated Security=True;TrustServerCertificate=Yes";

        public void Open()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
        }
        public void Close()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Close();
        }
    }
}

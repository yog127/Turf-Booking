using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurfBooking.BusinessLayer.Model
{
    public class BookingResponse
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TurfId { get; set; }
        public double PhoneNumber { get; set; }
        public int UserId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DateOnly BookingDate { get; set; }
        public Boolean Status { get; set; }
    }
}

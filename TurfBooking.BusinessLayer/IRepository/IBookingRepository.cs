using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.BusinessLayer.Model;

namespace TurfBooking.BusinessLayer.IRepository
{
    public interface IBookingRepository
    {
        public int Create(Booking booking);
        public int Update(Booking booking);
        public void Delete(int bookingId);
        public List<Booking> GetAllBooking();
        public List<Booking> GetBookingsByUserId(int userId);


    }
}

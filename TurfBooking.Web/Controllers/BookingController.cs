using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using TurfBooking.BusinessLayer.IRepository;
using TurfBooking.BusinessLayer.Model;

namespace TurfBooking.Web.Controllers
{
    public class BookingController : Controller
    {
        IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository) 
        {
            _bookingRepository = bookingRepository;
        }
        public IActionResult Booking()
        {
            List<Booking> bookings = _bookingRepository.GetAllBooking();
            List<BookingResponse> bookingResponses = bookings.Select(b => new BookingResponse
            {
                BookingId = b.BookingId,
                Name = b.Name,
                Email = b.Email,
                TurfId = b.TurfId,
                PhoneNumber = b.PhoneNumber,
                UserId = b.UserId,
                StartTime = b.StartTime,
                EndTime = b.EndTime,
                BookingDate = b.BookingDate,
                Status = b.Status
            }).ToList();
            return View(bookingResponses);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            _bookingRepository.Create(booking);
            return RedirectToAction("Booking");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {            
            return View();
        }
        [HttpPost]
        public IActionResult Update(Booking booking)
        {
            _bookingRepository.Update(booking);
            return RedirectToAction("Booking");
        }
        public IActionResult GetById(int id)
        {
            var booking = _bookingRepository.GetAllBooking();
            return View(booking);
        }

    }
}

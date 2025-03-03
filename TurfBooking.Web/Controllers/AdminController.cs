using Microsoft.AspNetCore.Mvc;
using TurfBooking.BusinessLayer.IRepository;
using TurfBooking.BusinessLayer.Model;
using TurfBooking.BusinessLayer.Model.DTOs;
using TurfBooking.DataAccessLayer.Repository;

namespace TurfBooking.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IBookingRepository _bookingRepository;

        public AdminController(IAdminRepository adminRepository, IBookingRepository bookingRepository)
        {
            _adminRepository = adminRepository;
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdminLoginModel adminLoginModel)
        {
            var admin = _adminRepository.GetByEmail(adminLoginModel.Email);

            if (admin != null && (admin.Password == adminLoginModel.Password))
            {
                TempData["Message"] = "Login Successful";
                HttpContext.Session.SetInt32("AdminId",admin.Id);
                ViewBag.LoginFlag = true;
                return RedirectToAction("HomePage", "Admin");
            }
            TempData["Message"] = "Invalid Credential";
            return RedirectToAction("Login");
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
        public IActionResult HomePage()
        {
            return View();
        }
    }
}

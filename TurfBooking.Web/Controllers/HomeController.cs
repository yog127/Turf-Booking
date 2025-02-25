using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TurfBooking.BusinessLayer.IRepository;
using TurfBooking.BusinessLayer.Model;

namespace TurfBooking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITurfRepository _turfRepository;

        public HomeController(ITurfRepository turfRepository)
        {
            _turfRepository = turfRepository;
        }

        public IActionResult HomePage()
        {
            //var userId = HttpContext.Session.GetInt32("UserId");

            var turfList = _turfRepository.GetAllTurf();
            return View(turfList);  
        }
    }
}

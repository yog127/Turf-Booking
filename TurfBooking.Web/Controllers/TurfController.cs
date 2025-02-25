using Microsoft.AspNetCore.Mvc;

namespace TurfBooking.Web.Controllers
{
    public class TurfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TurfBooking.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

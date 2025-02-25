using Microsoft.AspNetCore.Mvc;
using TurfBooking.BusinessLayer.IRepository;
using TurfBooking.BusinessLayer.Model;
using TurfBooking.BusinessLayer.Model.DTOs;

namespace TurfBooking.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            _userRepository.Create(user);
            TempData["Message"] = "Registration successful! You can now log in.";
            return RedirectToAction("HomePage", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLogiModel)
        {
            var user = _userRepository.GetByEmail(userLogiModel.Email);

            if(user != null && (user.Password == userLogiModel.Password)){
                TempData["Message"] = "Login Successful";
                HttpContext.Session.SetInt32("UserId", user.UserId);
                ViewBag.LoginFlag = true;
                return RedirectToAction("HomePage", "Home");
            }
            TempData["Message"] = "Invalid Credential";
            return RedirectToAction("Login");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("HomePage", "Home");
        }
    }
}

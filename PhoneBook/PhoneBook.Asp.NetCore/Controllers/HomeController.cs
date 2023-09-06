using Microsoft.AspNetCore.Mvc;
using Services;

namespace PhoneBook.Asp.NetCore.Controllers
{
    public class HomeController : Controller
    {
        [Route("/{Id?}/{message?}")]
        public IActionResult Enter(string message, string Id = "SignUp")
        {
            ViewBag.message = TempData["message"] as string;
            if (TempData["id"] as string != null)
            {
                Id = TempData["id"] as string;
            }
            if (Id == "Login")
            {
                return View("Login");
            }
            return View("SignUp");
        }
        [HttpPost]
        [Route("/{email?}/{name?}/{password?}")]
        public IActionResult SignUp(string email, string name, string password)
        {
            UserServices userService = new UserServices();
            var response = userService.SignUp(name, email, password);
            TempData["message"] = response.message;
            if (response.isSuccess)
            {
                return View("UserPanel");
            }
            return RedirectToAction("Enter");
        }
        [HttpPost]
        [Route("/{email?}/{password?}")]
        public IActionResult Login(string email, string password)
        {
            UserServices userService = new UserServices();
            var response = userService.LogIn(email, password);
            if (response.isSuccess)
            {
                return View("UserPanel");
            }
            TempData["message"] = response.message;
            TempData["Id"] = "Login";
            return RedirectToAction("Enter");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
namespace PhoneBook.Asp.NetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Entrance()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public Response SignUp(string email, string name, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                return new Response()
                {
                    isSuccess = false,
                    message = "Please make sure your passwords match!"
                };
            }
            UserServices userService = new UserServices();
            var response = userService.SignUp(name, email, password);
            if (response.isSuccess)
            {
                TempData["email"] = email;
                TempData["password"] = password;
                RedirectToAction("EnterOTP", "Home");
            }
            return response;
        }
        [HttpPost]
        [AllowAnonymous]
        public Response Login(string email, string password)
        {
            UserServices userService = new UserServices();
            var response = userService.LogIn(email, password);
            if (response.isSuccess)
            {
                TempData["email"] = email;
                TempData["password"] = password;
                RedirectToAction("Panel", "UserPanel");
            }
            return response;
        }
        public IActionResult EnterOTP()
        {

            ViewBag.email = TempData["email"] as string;
            ViewBag.password = TempData["password"] as string;
            return View();
        }
        public void OTPCorrectionCheck(string email, string password)
        {
            TempData["email"] = email;
            TempData["password"] = password;
            RedirectToAction("Panel", "UserPanel");
        }
    }
}

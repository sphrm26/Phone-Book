using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace PhoneBook.Asp.NetCore.Controllers
{
    public class OTPController : Controller
    {
        public IActionResult EnterOTP()
        {
            string email = TempData["email"] as string;
            string password = TempData["password"] as string;
            UserServices userService = new UserServices();
            userService.SendOTP(email);
            TempData["email"] = email;
            TempData["password"] = password;
            return View();
        }
    }
}

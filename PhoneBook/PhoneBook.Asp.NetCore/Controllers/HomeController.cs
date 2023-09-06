using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace PhoneBook.Asp.NetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Enter(string Id = "SingUp")
        {
            if(Id == "Login")
            {
                return View("Login");
            }
            return View("SignUp");
        }
        public Object SignUp(string email, string name, string password)
        {
            UserServices userService = new UserServices();
            if (userService.SignUp(name, email, password).isSuccess)
            {
                
            }
            return RedirectToAction("Index");
        }
    }
}

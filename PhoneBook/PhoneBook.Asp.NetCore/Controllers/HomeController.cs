using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Asp.NetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

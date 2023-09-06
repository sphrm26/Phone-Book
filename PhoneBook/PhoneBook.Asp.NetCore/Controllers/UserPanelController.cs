using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Asp.NetCore.Controllers
{
    public class UserPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

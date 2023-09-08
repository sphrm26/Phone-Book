using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Asp.NetCore.Controllers
{
    public class UserPanelController : Controller
    {
        public IActionResult Panel(/*string email, string password*/)
        {
            return View();
        }
        public string Test()
        {
            return "sepehr";
        }
    }
}

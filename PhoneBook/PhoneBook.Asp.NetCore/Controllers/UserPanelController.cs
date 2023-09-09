using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.Asp.NetCore.Controllers
{
    public class UserPanelController : Controller
    {
        public IActionResult Panel()
        {
            string email = TempData["email"] as string;
            string password = TempData["password"] as string;
            int Id = int.Parse(TempData["Id"] as string);
            Console.WriteLine(Id+ " " + email);
            return View();
        }
    }
}

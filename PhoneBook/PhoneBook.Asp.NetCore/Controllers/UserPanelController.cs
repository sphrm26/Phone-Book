using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace PhoneBook.Asp.NetCore.Controllers
{
    public class UserPanelController : Controller
    {
        public IActionResult Panel()
        {
            string email = TempData["email"] as string;
            string password = TempData["password"] as string;
            return View();
        }
        public Response AddContact(string email, string password, string first_name, string last_name, string phone_number)
        {
            UserServices userService = new UserServices();
            var response = userService.LogIn(email, password);

            string objSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(response.objects[0]);
            int Id = ((dynamic)Newtonsoft.Json.JsonConvert.DeserializeObject(objSerialized)).Id;

            if (!response.isSuccess)
            {
                return new Response()
                {
                    isSuccess = false,
                    message = "security error!"
                };
            }
            ContactServices contactService = new ContactServices();
            response = contactService.AddContact(Id, first_name, last_name, phone_number);
            return response;
        }
    }
}

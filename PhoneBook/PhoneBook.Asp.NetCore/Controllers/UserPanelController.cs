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

            if (!response.isSuccess)
            {
                return new Response()
                {
                    isSuccess = false,
                    message = "security error!"
                };
            }

            string objSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(response.objects[0]);
            int User_Id = ((dynamic)Newtonsoft.Json.JsonConvert.DeserializeObject(objSerialized)).Id;

            ContactServices contactService = new ContactServices();
            response = contactService.AddContact(User_Id, first_name, last_name, phone_number);
            return response;
        }
        public Response EditContact(string email, string password, string first_name, string last_name, string phone_number, int Id)
        {
            UserServices userService = new UserServices();
            var response = userService.LogIn(email, password);

            if (!response.isSuccess)
            {
                return new Response()
                {
                    isSuccess = false,
                    message = "security error!"
                };
            }

            string objSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(response.objects[0]);
            int User_Id = ((dynamic)Newtonsoft.Json.JsonConvert.DeserializeObject(objSerialized)).Id;

            ContactServices contactService = new ContactServices();
            response = contactService.UpdateContact(Id, User_Id, first_name, last_name, phone_number);
            return response;
        }
        public Response DeleteContact(string email, string password, int Id)
        {
            UserServices userService = new UserServices();
            var response = userService.LogIn(email, password);

            if (!response.isSuccess)
            {
                return new Response()
                {
                    isSuccess = false,
                    message = "security error!"
                };
            }

            ContactServices contactService = new ContactServices();
            response = contactService.DeleteContact(Id);
            return response;
        }
    }
}

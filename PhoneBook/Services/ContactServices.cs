using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ContactServices
    {
        private UnitOfWork db = new UnitOfWork();
        public Response GetAllContact(int User_Id)
        {
            return new Response()
            {
                objects = db.ContactRepository.GetAllContacts(User_Id).ToList<Object>(),
                isSuccess = true
            };
        }
    }
}

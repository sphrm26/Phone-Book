﻿using DataAccessLayer;
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
                objects = db.ContactRepository.GetAllContacts(User_Id).ToList<object>(),
                isSuccess = true
            };
        }
        public Response AddContact(int User_Id, string first_name, string last_name, string phone_number)
        {
            db.ContactRepository.AddContact(new Contact()
            {
                first_name = first_name,
                last_name = last_name,
                phone_number = phone_number,
                user_Id = User_Id
            });
            return new Response()
            {
                isSuccess = true,
                message = "new contact successfuly added"
            };
        }
        public Response UpdateContact(int Id, int User_Id, string first_name, string last_name, string phone_number)
        {
            db.ContactRepository.UpdateContact(new Contact()
            {
                Id = Id,
                first_name = first_name,
                last_name = last_name,
                phone_number = phone_number,
                user_Id = User_Id
            });
            return new Response() 
            {
                isSuccess = true,
                message = "contact successfuly update"
            };
        }
        public Response DeleteContact(int Id)
        {
            db.ContactRepository.DeleteContact(Id);
            return new Response() 
            {
                isSuccess = true,
                message = "contact successfuly deleted"
            };
        }
    }
}

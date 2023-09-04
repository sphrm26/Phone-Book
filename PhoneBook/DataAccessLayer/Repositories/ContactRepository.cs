using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IContactRepository
    {
        bool AddContact(Contact contact);
        List<Contact> GetAllContacts(int user_Id);
        bool UpdateContact(Contact contact);
        bool DeleteContact(int contactId);
    }
}

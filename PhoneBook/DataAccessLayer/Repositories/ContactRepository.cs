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
    public class ContactRepository : IContactRepository
    {
        private string _connectionString;
        public ContactRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool AddContact(Contact contact)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@first_name", contact.first_name);
                    parameters.Add("@last_name", contact.last_name);
                    parameters.Add("@phone_number", contact.phone_number);
                    parameters.Add("@user_Id", contact.user_Id);
                    db.Execute("AddContact", parameters, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<Contact> GetAllContacts(int user_Id)
        {
            List<Contact> list;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@user_Id", user_Id);
                list = db.Query<Contact>("GetAllContacts", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return list;
        }
    }
}

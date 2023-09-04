using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork
    {
        string connectionString = @"Data Source = DESKTOP-7HLK92Q\SEPEHRSQL;Initial Catalog=PhoneBook;User ID=sa;Password=sphrm26sphrm26;";

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(connectionString);
                }

                return _userRepository;
            }
        }

        private IContactRepository _contactRepository;
        public IContactRepository ContactRepository
        {
            get
            {
                if (_contactRepository == null)
                {
                    _contactRepository = new ContactRepository(connectionString);
                }

                return _contactRepository;
            }
        }
    }
}

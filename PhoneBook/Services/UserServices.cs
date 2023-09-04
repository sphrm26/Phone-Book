using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices
    {
        private UnitOfWork db = new UnitOfWork();
        public response signUp(string name, string email, string password)
        {
            //تکراری نبودن
            //autentication
            db.UserRepository.AddUser(new User()
            {
                email = email,
                password = password,
                name = name
            });
            return new response() { };
        }
        public response logIn(string email, string password)
        {
            //پیدا کردن با ایمیل
            //چک کردن رمز
            return new response() { };
        }
    }
}

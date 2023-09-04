using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        bool AddUser(User user);
        User FindUserByEmail(string email);
        bool UpdateUser(User user);
        bool DeleteUser(int user_Id);
    }
}

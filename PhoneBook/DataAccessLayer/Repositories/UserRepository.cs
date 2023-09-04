using Models;

namespace DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        bool AddUser(User user);
        User FindUserByEmail(string email);
        bool UpdateUser(User user);
        bool DeleteUser(int user_Id);
    }
    public class UserRepository : IUserRepository
    {
    }
}

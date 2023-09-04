using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Data;

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
        private string _connectionString;
        public UserRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool AddUser(User user)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@name", user.name);
                    parameters.Add("@password", user.password);
                    parameters.Add("@email", user.email);

                    db.Execute("AddUser", parameters, commandType: CommandType.StoredProcedure);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public User? FindUserByEmail(string email)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);

                return db.Query<User>("GetUserByEmail", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();                
            }
        }
    }
}

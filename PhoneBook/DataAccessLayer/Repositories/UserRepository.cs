using Microsoft.Data.SqlClient;
using Models;
using System.Data;
using System;
using Dapper;

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
        bool AddUser(User user)
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

    }
}

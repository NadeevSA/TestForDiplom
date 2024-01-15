using Dapper;
using OOP.Context;
using OOP.Contracts;
using OOP.Interfaces;
using System.Data;

namespace OOP.Provides
{
    public class UserProviderDapper : IUserProviderDapper
    {
        private readonly IDbConnection _connection;

        public UserProviderDapper(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<User> GetAll()
        {
            return _connection.Query<User>("SELECT * FROM Users").ToList();
        }

        public List<User> GetById(Guid userId)
        {
            return _connection.Query<User>("SELECT * FROM Users WHERE Id = @userId", new { userId }).ToList();
        }

        public int Add(User user)
        {
            user.id = Guid.NewGuid();
            var sqlQuery = "INSERT INTO Users (id, name, gender) VALUES(@id, @name, @gender)";
            return _connection.Execute(sqlQuery, user);
        }

        public int Update(User user)
        {
            var sqlQuery = "UPDATE Users SET name = @name, gender = @gender WHERE Id = @id";
            return _connection.Execute(sqlQuery, user);
        }

        public int Remove(Guid userId)
        {
            var sqlQuery = $"DELETE FROM Users WHERE id = @userId";
            return _connection.Execute(sqlQuery, new { userId });
        }
    }
}

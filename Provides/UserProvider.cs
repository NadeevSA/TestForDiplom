using OOP.Context;
using OOP.Contracts;
using OOP.Interfaces;

namespace OOP.Provides
{
    public class UserProvider : IUserProvider
    {
        private readonly MainContext _mainContext;
        private readonly string _connectionString;

        public UserProvider(MainContext mainContext, string connectionString)
        {
            _mainContext = mainContext;
            _connectionString = connectionString;
        }

        public List<User> GetAll()
        {
            return _mainContext.users.ToList();
        }

        public User GetById(Guid userId)
        {
            return _mainContext.users.FirstOrDefault(u => u.id == userId);
        }

        public int Add(IEnumerable<User> users)
        {
            _mainContext.users.AddRange(users);
            var result = _mainContext.SaveChanges();
            _mainContext.Dispose();

            return result;
        }
        public int Update(User user)
        {
            var result = 0;
            using (var db = new MainContext(_connectionString))
            {
                db.users.Update(user);
                result = db.SaveChanges();
            }

            return result;
        }

        public int Remove(User user)
        {
            var result = 0;
            using (var db = new MainContext(_connectionString))
            {
                db.users.Remove(user);
                result = db.SaveChanges();
            }

            return result;
        }
    }
}

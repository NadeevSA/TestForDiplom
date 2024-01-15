using OOP.Contracts;

namespace OOP.Interfaces
{
    public interface IUserProvider
    {
        public List<User> GetAll();
        public User GetById(Guid userId);
        public int Add(IEnumerable<User> users);
        public int Update(User user);
        public int Remove(User user);
    }
}

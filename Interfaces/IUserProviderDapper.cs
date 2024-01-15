using OOP.Contracts;

namespace OOP.Interfaces
{
    public interface IUserProviderDapper
    {
        public List<User> GetAll();
        public List<User> GetById(Guid userId);
        public int Add(User user);
        public int Update(User user);
        public int Remove(Guid userId);
    }
}
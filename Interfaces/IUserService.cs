using OOP.Contracts;

namespace OOP.Interfaces
{
    public interface IUserService
    {
        public List<User> GetAll();
        public List<User> GetAllInDapper();
        public User GetById(Guid userId);
        public int Update(User user);
        public int UpdateInDapper(User user);
        public int Add(IEnumerable<User> users);
        public int AddInDapper(User users);
        public int Remove(Guid userId);
        public int RemoveInDapper(Guid userId);
    }
}

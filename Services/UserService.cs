using OOP.Contracts;
using OOP.Interfaces;

namespace OOP.Services
{
    public class UserService : IUserService
    {
        private readonly IUserProvider _userProvider;
        private readonly IUserProviderDapper _userProviderDapper;
        private readonly IMyLogger _logger;

        public UserService(
            IUserProvider userProvider, 
            IUserProviderDapper userProviderDapper,
            IMyLogger logger)
        {
            _userProvider = userProvider;
            _userProviderDapper = userProviderDapper;
            _logger = logger;
        }

        public List<User> GetAll()
        {
            var result = _userProvider.GetAll();
            _logger.Info($"Get {string.Join(',', result)} through EF.");

            return result;
        }

        public List<User> GetAllInDapper()
        {
            var result = _userProviderDapper.GetAll();
            _logger.Info($"Get {string.Join(',', result)} through dapper.");

            return result;
        }

        public User GetById(Guid userId)
        {
            var result = _userProvider.GetById(userId);
            if (result == null)
            {
                _logger.Error($"{nameof(User)} with id = {userId} is not found through EF");
                return null;
            }
            _logger.Info($"Get {nameof(User)} by id = {userId} through EF.");

            return result;
        }

        public int Add(IEnumerable<User> users)
        {
            var result = _userProvider.Add(users);
            if (result == users.Count())
            {
                _logger.Info($"аdded {result} through EF");
            }
            else
            {
                _logger.Error($"Added {result} of {users.Count()} {nameof(User)} through EF.");
            }

            return result;
        }

        public int AddInDapper(User users)
        {
            var result = _userProviderDapper.Add(users);
            if (result == 1)
            {
                _logger.Info($"Added {result} through dapper");
            }
            else
            {
                _logger.Error($"didn't added {result} {nameof(User)} through dapper.");
            }

            return result;
        }

        public int Update(User user)
        {
            var result = _userProvider.Update(user);
            if (result == 0)
            {
                _logger.Info($"Updated {result} through EF.");
            }
            else
            {
                _logger.Error($"Didn't updated {result} {nameof(User)} through EF.");
            }

            return result;
        }

        public int UpdateInDapper(User users)
        {
            var result =  _userProviderDapper.Update(users);
            if (result == 0)
            {
                _logger.Info($"Updated {result} through dapper.");
            }
            else
            {
                _logger.Error($"Didn't updated {result} {nameof(User)} through dapper.");
            }

            return result;
        }

        public int Remove(Guid userId)
        {
            var user = _userProvider.GetById(userId);
            var result = _userProvider.Remove(user);
            if (result == 0)
            {
                _logger.Info($"Deleted {result} through EF.");
            }
            else
            {
                _logger.Error($"Didn't deleted {result} {nameof(User)} through EF.");
            }

            return result;
        }

        public int RemoveInDapper(Guid userId)
        {
            var result = _userProviderDapper.Remove(userId);
            if (result == 0)
            {
                _logger.Info($"Deleted {result} through dapper.");
            }
            else
            {
                _logger.Error($"Didn't deleted {result} {nameof(User)} through dapper.");
            }

            return result;
        }
    }
}

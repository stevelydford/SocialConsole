using System.Collections.Generic;
using System.Linq;

namespace SocialConsole
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
        }

        public void RegisterUser(string userName)
        {
            if (GetUser(userName) == null)
            {
                _users.Add(new User(userName));
            }
        }

        public User GetUser(string userName)
        {
            return _users.FirstOrDefault(x => x.Name == userName);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace SocialConsole.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
        }

        public User RegisterUser(string userName)
        {
            var user = GetUser(userName);

            if (user == null)
            {
                user = new User(userName);
                _users.Add(user);
            }

            return user;
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
using System.Collections.Generic;

namespace SocialConsole
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(string userName);
        void RegisterUser(string userName);
    }
}

using System.Collections.Generic;

namespace SocialConsole.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(string userName);
        User RegisterUser(string userName);
    }
}
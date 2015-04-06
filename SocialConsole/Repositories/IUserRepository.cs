using System.Collections.Generic;
using SocialConsole.Domain;

namespace SocialConsole.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(string userName);
        User RegisterUser(string userName);
    }
}
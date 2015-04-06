using System.Collections.Generic;

namespace SocialConsole
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(string userName);
        User RegisterUser(string userName);
    }
}
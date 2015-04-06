using System.Collections.Generic;
using SocialConsole.Repositories;

namespace SocialConsole.Commands
{
    public interface ICommand
    {
       CommandResponse Execute(List<string> arguments, IUserRepository userRepository);
    }
}
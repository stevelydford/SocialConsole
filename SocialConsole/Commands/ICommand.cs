using System.Collections.Generic;

namespace SocialConsole.Commands
{
    public interface ICommand
    {
       CommandResponse Execute(List<string> arguments, IUserRepository userRepository);
    }
}
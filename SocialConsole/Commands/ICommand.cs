using System.Collections.Generic;
using SocialConsole.Repositories;

namespace SocialConsole.Commands
{
    public interface ICommand
    {
        List<string> Arguments { get; set; }
        IUserRepository UserRepository { get; set; }

        CommandResponse Execute();
    }
}
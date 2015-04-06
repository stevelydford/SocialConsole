using System;
using System.Collections.Generic;
using SocialConsole.Repositories;

namespace SocialConsole.Commands
{
    public class NullCommand: ICommand
    {
        public List<string> Arguments { get; set; }
        public IUserRepository UserRepository { get; set; }

        public CommandResponse Execute()
        {
            return new CommandResponse(CommandResponseStatus.Error);
        }
    }
}
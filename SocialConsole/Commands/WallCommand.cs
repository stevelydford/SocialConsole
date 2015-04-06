using System;
using System.Collections.Generic;
using SocialConsole.Repositories;

namespace SocialConsole.Commands
{
    public class WallCommand : ICommand
    {
        public List<string> Arguments { get; set; }
        public IUserRepository UserRepository { get; set; }

        public CommandResponse Execute()
        {
            try
            {
                var user = UserRepository.GetUser(Arguments[0]);
                var response = new CommandResponse(CommandResponseStatus.Ok, user.GetWall());
                return response;
            }
            catch (Exception exception)
            {
                var response = new CommandResponse(CommandResponseStatus.Error);
                response.Payload.Add(exception.ToString());
                return response;
            }
        }
    }
}
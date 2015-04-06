using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SocialConsole.Repositories;

namespace SocialConsole.Commands
{
    public class WallCommand : ICommand
    {
        public CommandResponse Execute(List<string> arguments, IUserRepository userRepository)
        {
            try
            {
                var user = userRepository.GetUser(arguments[0]);
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

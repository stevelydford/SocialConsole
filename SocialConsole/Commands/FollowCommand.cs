using System;
using System.Collections.Generic;
using SocialConsole.Repositories;

namespace SocialConsole.Commands
{
    public class FollowCommand : ICommand
    {
        public CommandResponse Execute(List<string> arguments, IUserRepository userRepository)
        {
            try
            {
                var user = userRepository.GetUser(arguments[0]);
                user.Friends.Add(userRepository.GetUser(arguments[2]));
                return new CommandResponse(CommandResponseStatus.Ok);
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

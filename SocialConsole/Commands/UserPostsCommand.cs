using System;
using System.Collections.Generic;
using System.Linq;
using SocialConsole.Repositories;

namespace SocialConsole.Commands
{
    public class UserPostsCommand : ICommand
    {
        public CommandResponse Execute(List<string> arguments, IUserRepository userRepository)
        {
            try
            {
                var user = userRepository.GetUser(arguments[0]);
                var payload = new List<string>();
                payload.AddRange(user.Posts.Select(post => post.ToString()));
                var response = new CommandResponse(CommandResponseStatus.Ok, payload);
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

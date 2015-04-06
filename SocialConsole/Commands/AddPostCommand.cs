using System;
using System.Collections.Generic;
using System.Linq;
using SocialConsole.Domain;
using SocialConsole.Repositories;

namespace SocialConsole.Commands
{
    public class AddPostCommand : ICommand
    {
        public CommandResponse Execute(List<string> arguments, IUserRepository userRepository)
        {
            try
            {
                var user = userRepository.GetUser(arguments[0]);
                var post = string.Join(" ", arguments.Skip(2).Take(arguments.Count - 2));
                user.Posts.Add(new Post(post));
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

using System;
using System.Collections.Generic;
using System.Linq;
using SocialConsole.Domain;
using SocialConsole.Repositories;

namespace SocialConsole.Commands
{
    public class AddPostCommand : ICommand
    {
        public List<string> Arguments { get; set; }
        public IUserRepository UserRepository { get; set; }

        public CommandResponse Execute()
        {
            try
            {
                var user = UserRepository.GetUser(Arguments[0]);
                var post = string.Join(" ", Arguments.Skip(2).Take(Arguments.Count - 2));
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

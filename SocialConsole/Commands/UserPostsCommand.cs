using System;
using System.Collections.Generic;
using System.Linq;
using SocialConsole.Repositories;

namespace SocialConsole.Commands
{
    public class UserPostsCommand : ICommand
    {
        public List<string> Arguments { get; set; }
        public IUserRepository UserRepository { get; set; }

        public CommandResponse Execute()
        {
            try
            {
                var user = UserRepository.GetUser(Arguments[0]);
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
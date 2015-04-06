using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SocialConsole.Commands;
using SocialConsole.Repositories;

namespace SocialConsole
{
    public class MessageHandler
    {
        private readonly IUserRepository _userRepository;

        public MessageHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<string> Process(string input)
        {
            var arguments = ParseArguments(input);
            var response = new List<string>();
            var user = _userRepository.RegisterUser(arguments[0]);

            if (arguments.Count == 1)
            {
                response.AddRange(user.Posts.Select(post => post.ToString()));
            }
            else if (arguments[1] == "->")
            {
                var command = new AddPostCommand();
                command.Execute(arguments, _userRepository);
            }
            else if (arguments[1] == "follows")
            {
                var command = new FollowCommand();
                command.Execute(arguments, _userRepository);
            }
            else if (arguments[1] == "wall")
            {
                var command = new WallCommand();
                var commandResponse = command.Execute(arguments, _userRepository);
                if (commandResponse.Status == CommandResponseStatus.Ok)
                {
                    response.AddRange(commandResponse.Payload);
                }
            }

            return response;
        }

        private static List<string> ParseArguments(string input)
        {
            return input.Split(' ').ToList();
        }
    }
}
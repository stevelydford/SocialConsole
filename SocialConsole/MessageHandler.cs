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
            _userRepository.RegisterUser(arguments[0]);
            var commandArgument = "";

            commandArgument = arguments.Count == 1 ? "userPosts" : arguments[1];

            switch (commandArgument)
            {
                case "userPosts":
                    {
                        var command = new UserPostsCommand();
                        var commandResponse = command.Execute(arguments, _userRepository);
                        if (commandResponse.Status == CommandResponseStatus.Ok)
                        {
                            response.AddRange(commandResponse.Payload);
                        }
                    }
                    break;
                case "->":
                    {
                        var command = new AddPostCommand();
                        command.Execute(arguments, _userRepository);
                    }
                    break;

                case "follows":
                    {
                        var command = new FollowCommand();
                        command.Execute(arguments, _userRepository);
                    }
                    break;

                case "wall":
                    {
                        var command = new WallCommand();
                        var commandResponse = command.Execute(arguments, _userRepository);
                        if (commandResponse.Status == CommandResponseStatus.Ok)
                        {
                            response.AddRange(commandResponse.Payload);
                        }
                    }
                    break;
            }

            return response;
        }

        private static List<string> ParseArguments(string input)
        {
            return input.Split(' ').ToList();
        }
    }
}
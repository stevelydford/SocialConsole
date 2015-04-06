using System.Collections.Generic;
using SocialConsole.Repositories;

namespace SocialConsole.Commands
{
    public class CommandFactory
    {
        public ICommand CreateCommand(List<string> arguments, IUserRepository userRepository)
        {
            ICommand command = new NullCommand();
            if (arguments.Count == 0)
            {
                return command;
            }

            var commandArgument = arguments.Count == 1 ? "userPosts" : arguments[1];
            switch (commandArgument)
            {
                case "userPosts":
                    {
                        command = new UserPostsCommand();
                    }
                    break;
                case "->":
                    {
                        command = new AddPostCommand();
                    }
                    break;

                case "follows":
                    {
                        command = new FollowCommand();
                    }
                    break;

                case "wall":
                    {
                        command = new WallCommand();
                    }
                    break;
            }

            command.Arguments = arguments;
            command.UserRepository = userRepository;
            return command;
        }
    }
}
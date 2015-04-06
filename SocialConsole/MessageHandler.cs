using System.Collections.Generic;
using System.Linq;
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
            _userRepository.RegisterUser(arguments[0]);
            var response = new List<string>();

            var commandFactory = new CommandFactory();
            var command = commandFactory.CreateCommand(arguments, _userRepository);
            
            var commandResponse = command.Execute();
            if (commandResponse.Status == CommandResponseStatus.Ok && commandResponse.Payload.Count > 0)
            {
                response.AddRange(commandResponse.Payload);
            }
            
            return response;
        }

        private static List<string> ParseArguments(string input)
        {
            return input.Split(' ').ToList();
        }
    }
}
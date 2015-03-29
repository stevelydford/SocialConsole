using System.Collections.Generic;
using System.Linq;

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
                response.AddRange(user.Messages);
            }
            else if (arguments[1] == "->")
            {
                AddUserMessage(arguments, user);
            }

            return response;
        }

        private static void AddUserMessage(IReadOnlyCollection<string> arguments, User user)
        {
            var message = string.Join(" ", arguments.Skip(2).Take(arguments.Count - 2));
            user.Messages.Add(message);
        }

        private static List<string> ParseArguments(string input)
        {
            return input.Split(' ').ToList();
        }
    }
}

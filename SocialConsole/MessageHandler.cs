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

            _userRepository.RegisterUser(arguments[0]);

            var response = new List<string>();
            return response;
        }

        private static List<string> ParseArguments(string input)
        {
            return input.Split(' ').ToList();
        }
    }
}

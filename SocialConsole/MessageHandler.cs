using System.Collections.Generic;
using System.Linq;

namespace SocialConsole
{
    public class MessageHandler
    {
        public List<string> Arguments { get; set; }

        public List<string> Process(string input)
        {
            Arguments = input.Split(' ').ToList();
            return Arguments;
        }
    }
}

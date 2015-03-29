using System.Collections.Generic;
using System.Linq;

namespace SocialConsole
{
    public class MessageHandler
    {
        public List<User> Users { get; set; }

        public List<string> Arguments { get; set; }

        public MessageHandler()
        {
            Users = new List<User>();
        }

        public List<string> Process(string input)
        {
            Arguments = input.Split(' ').ToList();

            if (Users.FirstOrDefault(x => x.Name == Arguments[0]) == null)
            {
                Users.Add(new User(Arguments[0]));
            }

            var response = new List<string>();
            return response;


        }
    }
}

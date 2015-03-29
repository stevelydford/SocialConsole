
using System.Collections.Generic;

namespace SocialConsole
{
    public class User
    {
        public string Name { get; set; }

        public List<string> Posts { get; set; }

        public User(string name)
        {
            Name = name;
            Posts = new List<string>();
        }
    }
}

using System.Collections.Generic;

namespace SocialConsole
{
    public class User
    {
        public List<Post> Posts;

        public List<User> Friends; 
        
        public string Name { get; set; }
        
        public User(string name)
        {
            Name = name;
            Posts = new List<Post>();
            Friends = new List<User>();
        }
    }
}

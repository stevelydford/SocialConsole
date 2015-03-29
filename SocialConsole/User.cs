
using System.Collections.Generic;

namespace SocialConsole
{
    public class User
    {
        public string Name { get; set; }

        private readonly List<Post> _posts;

        public User(string name)
        {
            Name = name;
            _posts = new List<Post>();
        }

        public void AddPost(string body)
        {
            _posts.Add(new Post(body));
        }

        public List<Post> GetPosts()
        {
            return _posts;
        }
    }
}

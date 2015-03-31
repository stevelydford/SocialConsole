using System.Collections.Generic;

namespace SocialConsole
{
    public class User
    {
        private readonly List<Post> _posts;
        
        public string Name { get; set; }
        
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

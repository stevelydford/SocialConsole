using System.Collections.Generic;
using System.Linq;

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

        public List<string> GetWall()
        {
            var wallPosts = new List<WallPost>();

            foreach (var friend in Friends)
            {
                wallPosts.AddRange(friend.Posts.Select(post => new WallPost { User = friend, Post = post }));
            }

            return wallPosts.OrderBy(o => o.Post.Timestamp)
                .Select(post => string.Format("{0} - {1}", post.User.Name, post.Post.ToString()))
                .ToList();
        }

        private class WallPost
        {
            public User User { get; set; }
            public Post Post { get; set; }
        }
    }
}

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
            var allPosts = new List<WallPost>();

            foreach (var friend in Friends)
            {
                foreach (var post in friend.Posts)
                {
                    var wallPost = new WallPost { User = friend, Post = post };
                    allPosts.Add(wallPost);
                }
            }

            var wallPosts = new List<string>();
            foreach (var post in allPosts.OrderBy(o => o.Post.Timestamp))
            {
                wallPosts.Add(string.Format("{0} - {1}", post.User.Name, post.Post.ToString()));
            }

            return wallPosts;
        }

        private class WallPost
        {
            public User User { get; set; }
            public Post Post { get; set; }
        }
    }
}

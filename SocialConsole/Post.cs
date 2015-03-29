using System;

namespace SocialConsole
{
    public class Post
    {
        public string Body { get; set; }

        public DateTime TimeStamp { get; set; }

        public Post(string body)
        {
            Body = body;
            TimeStamp = DateTime.Now;
        }
    }
}

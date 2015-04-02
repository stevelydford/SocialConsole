using System;
using NUnit.Framework;

namespace SocialConsole.Tests
{
    [TestFixture]
    public class UserShould
    {
        [Test]
        public void HaveTheNamePropertySetByTheConstructor()
        {
            var user = new User("test");

            Assert.That(user.Name, Is.EqualTo("test"));
        }

        [Test]
        public void HaveANewListOfPostsCreatedOnInstantiation()
        {
            var user = new User("test");

            Assert.That(user.Posts, Is.Not.Null);
        }

        [Test]
        public void TimestampPosts()
        {
            var user = new User("test");
            user.Posts.Add(new Post("this is a test"));

            Assert.That(user.Posts[0].Timestamp, Is.GreaterThan(DateTime.Now.AddMinutes(-1)));
        }

        [Test]
        public void ReturnAllPostsWhenRequested()
        {
            var user = new User("test");
            user.Posts.Add(new Post("test post 1"));
            user.Posts.Add(new Post("test post 2"));
            user.Posts.Add(new Post("test post 3"));

            Assert.That(user.Posts.Count, Is.EqualTo(3));
        }

        [Test]
        public void HaveANewListOfFriendsCreatedOnInstantiation()
        {
            var user = new User("test");
            Assert.That(user.Friends, Is.Not.Null);
        }
    }
}

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

            Assert.That(user.GetPosts(), Is.Not.Null);
        }

        [Test]
        public void TimestampPosts()
        {
            var user = new User("test");
            user.AddPost("this is a test");

            Assert.That(user.GetPosts()[0].Timestamp, Is.GreaterThan(DateTime.Now.AddMinutes(-1)));
        }

        [Test]
        public void ReturnAllPostsWhenRequested()
        {
            var user = new User("test");
            user.AddPost("test post 1");
            user.AddPost("test post 2");
            user.AddPost("test post 3");

            Assert.That(user.GetPosts().Count, Is.EqualTo(3));
        }
    }
}

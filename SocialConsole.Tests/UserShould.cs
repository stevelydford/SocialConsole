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

        [Test]
        public void ReturnAllPostsFromAllFriendsWhenRequestedWhenTheUserHasOneFriend()
        {
            var userFriend = new User("alice");
            userFriend.Posts.Add(new Post("test 1"));
            userFriend.Posts.Add(new Post("test 2"));
            userFriend.Posts.Add(new Post("test 3"));

            var user = new User("bob");
            user.Friends.Add(userFriend);

            var result = user.GetWall();

            Assert.That(result[0], Is.EqualTo("alice - test 1 (0 seconds ago)"));
            Assert.That(result[1], Is.EqualTo("alice - test 2 (0 seconds ago)"));
            Assert.That(result[2], Is.EqualTo("alice - test 3 (0 seconds ago)"));

        }

        [Test]
        public void ReturnAllPostsFromAllFriendsInChronologicalOrderWhenTheUserHasMultipleFriends()
        {
            var userFriend1 = new User("alice");
            var userFriend2 = new User("bob");

            userFriend1.Posts.Add(new Post("userFriend1 test 1") { Timestamp = DateTime.Now.AddSeconds(-2) });
            userFriend2.Posts.Add(new Post("userFriend2 test 1") { Timestamp = DateTime.Now.AddSeconds(-1) });
            userFriend1.Posts.Add(new Post("userFriend1 test 2") { Timestamp = DateTime.Now });

            var user = new User("colin");
            user.Friends.Add(userFriend1);
            user.Friends.Add(userFriend2);

            var result = user.GetWall();

            Assert.That(result[0], Is.EqualTo("alice - userFriend1 test 1 (2 seconds ago)"));
            Assert.That(result[1], Is.EqualTo("bob - userFriend2 test 1 (1 second ago)"));
            Assert.That(result[2], Is.EqualTo("alice - userFriend1 test 2 (0 seconds ago)"));

        }
    }
}

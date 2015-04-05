using System;
using NUnit.Framework;

namespace SocialConsole.Tests
{
    [TestFixture]
    public class PostShould
    {
        [Test]
        public void SetThePostTextAndTimeStampOnInstantiation()
        {
            var post = new Post("test");

            Assert.That(post.Body, Is.EqualTo("test"));
            Assert.That(post.Timestamp, Is.Not.Null);
        }

        [Test]
        public void ReturnStringShowingNumberOfSecondsPostedIfNotPostedExactlyOneSecondAgo()
        {
            var post = new Post("test");

            Assert.That(post.ToString(), Is.EqualTo("test (0 seconds ago)"));
        }

        [Test]
        public void ReturnStringShowingNumberOfSecondsPostedIfPostedExactlyOneSecondAgo()
        {
            var post = new Post("test")
            {
                Timestamp = DateTime.Now.AddSeconds(-1)
            };

            Assert.That(post.ToString(), Is.EqualTo("test (1 second ago)"));
        }

        [Test]
        public void ReturnStringShowingNumberOfMinutesPostedIfPostedExactlyThanOneMinuteAgo()
        {
            var post = new Post("test")
            {
                Timestamp = DateTime.Now.AddMinutes(-1)
            };

            Assert.That(post.ToString(), Is.EqualTo("test (1 minute ago)"));
        }

        [Test]
        public void ReturnStringNumberOfSecondsPostedIfPostedMoreThanOneMinuteAgo()
        {
            var post = new Post("test")
            {
                Timestamp = DateTime.Now.AddMinutes(-2)
            };

            Assert.That(post.ToString(), Is.EqualTo("test (2 minutes ago)"));
        }

        [Test]
        public void ReturnStringShowingNumberOfMinutesPostedIfPostedExactlyOneHourAgo()
        {
            var post = new Post("test")
            {
                Timestamp = DateTime.Now.AddHours(-1)
            };

            Assert.That(post.ToString(), Is.EqualTo("test (1 hour ago)"));
        }

        [Test]
        public void ReturnStringNumberOfSecondsPostedIfPostedMoreThanOneHourAgo()
        {
            var post = new Post("test")
            {
                Timestamp = DateTime.Now.AddHours(-2)
            };

            Assert.That(post.ToString(), Is.EqualTo("test (2 hours ago)"));
        }

        [Test]
        public void ReturnStringShowingNumberOfMinutesPostedIfPostedExactlyOneDayAgo()
        {
            var post = new Post("test")
            {
                Timestamp = DateTime.Now.AddDays(-1)
            };

            Assert.That(post.ToString(), Is.EqualTo("test (1 day ago)"));
        }

        [Test]
        public void ReturnStringNumberOfSecondsPostedIfPostedMoreThanOneDayAgo()
        {
            var post = new Post("test")
            {
                Timestamp = DateTime.Now.AddDays(-2)
            };

            Assert.That(post.ToString(), Is.EqualTo("test (2 days ago)"));
        }
    }
}
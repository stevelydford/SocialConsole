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
            Assert.That(post.TimeStamp, Is.Not.Null);
        }
    }
}

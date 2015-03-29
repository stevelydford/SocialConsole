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
        public void HaveANewListOfMessagesCreatedOnInstantiation()
        {
            var user = new User("test");

            Assert.That(user.Messages, Is.Not.Null);
        }
    }
}

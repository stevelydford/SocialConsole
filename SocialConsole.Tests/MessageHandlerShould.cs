using NUnit.Framework;

namespace SocialConsole.Tests
{
    [TestFixture]
    public class MessageHandlerShould
    {
        private MessageHandler _messageHandler;

        [SetUp]
        public void Init()
        {
            _messageHandler = new MessageHandler();
        }

        [Test]
        public void ProcessAnInputStringAndReturnAListOfStrings()
        {
            const string input = "test";

            var result = _messageHandler.Process(input);

            Assert.That(result, Is.All.InstanceOf(typeof(string)));
        }

        [Test]
        public void SpiltInputStringBySpacesAndStoreAsListArguments()
        {
            _messageHandler.Process("alice follows bob");

            var result = _messageHandler.Arguments;

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo("alice"));
            Assert.That(result[1], Is.EqualTo("follows"));
            Assert.That(result[2], Is.EqualTo("bob"));
        }

        [Test]
        public void CreateANewUserAsNamedInTheFirstArgument()
        {
            _messageHandler.Process("alice follows bob");

            Assert.That(_messageHandler.Users[0].Name, Is.EqualTo("alice"));
        }

        [Test]
        public void NotCreateAUserThatAlreadyExists()
        {
            _messageHandler.Users.Add(new User("alice"));

            _messageHandler.Process("alice follows bob");

            Assert.That(_messageHandler.Users.Count, Is.EqualTo(1));
        }


    }
}

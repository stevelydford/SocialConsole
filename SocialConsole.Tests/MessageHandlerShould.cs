using NUnit.Framework;

namespace SocialConsole.Tests
{
    [TestFixture]
    public class MessageHandlerShould
    {
        private MessageHandler _messageHandler;
        private UserRepository _userRepository;

        [SetUp]
        public void Init()
        {
            _userRepository = new UserRepository();
            _messageHandler = new MessageHandler(_userRepository);
        }

        [Test]
        public void ProcessAnInputStringAndReturnAListOfStrings()
        {
            const string input = "test";

            var result = _messageHandler.Process(input);

            Assert.That(result, Is.All.InstanceOf(typeof(string)));
        }

        [Test]
        public void AttemptToAddANonRegisteredUser()
        {
            _messageHandler.Process("alice");

            Assert.That(_userRepository.GetUser("alice"), Is.Not.Null);
        }
    }
}

using NUnit.Framework;
using SocialConsole.Repositories;

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

        [Test]
        public void AddAPostToAUserWhenAsked()
        {
            _messageHandler.Process("alice -> this is a test");

            Assert.That(_userRepository.GetUser("alice").Posts.Count == 1);
        }
        
        [Test]
        public void RetrieveAllPostsForAUserWhenAsked()
        {
            _messageHandler.Process("alice -> this is a test");
            var result = _messageHandler.Process("alice");
            
            Assert.That(result[0], Is.EqualTo("this is a test (0 seconds ago)"));
        }

        [Test]
        public void ReturnAnEmptyListWhenAskedToRetrieveAllPostsForAUserThatHasNoPosts()
        {
            _messageHandler.Process("alice -> this is a test");
            var result = _messageHandler.Process("bob");

            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void AllowAUserToFollowAnother()
        {
            _messageHandler.Process("bob");
             _messageHandler.Process("alice follows bob");
            
            var user = _userRepository.GetUser("alice");

            Assert.That(user.Friends[0].Name, Is.EqualTo("bob"));
        }

        [Test]
        public void GetPostsFromAllFriends()
        {
            _messageHandler.Process("alice -> this is a test from Alice");
            _messageHandler.Process("bob -> this is a test from Bob");
            _messageHandler.Process("colin follows alice");
            _messageHandler.Process("colin follows bob");

            var result = _messageHandler.Process("colin wall");

            Assert.That(result[0], Is.EqualTo("alice - this is a test from Alice (0 seconds ago)"));
        }
    }
}
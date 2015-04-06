using System.Collections.Generic;
using NUnit.Framework;
using SocialConsole.Commands;

namespace SocialConsole.Tests.Commands
{
    [TestFixture]
    public class AddPostCommandShould
    {
        [Test]
        public void AddAPostToAUserWhenExecuted()
        {
            var arguments = new List<string>
            {
                "alice",
                "->",
                "this",
                "is",
                "a",
                "test"
            };
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var addPostCommand = new AddPostCommand();
            addPostCommand.Execute(arguments, userRepository);

            Assert.That(userRepository.GetUser("alice").Posts.Count == 1);
            Assert.That(userRepository.GetUser("alice").Posts[0].Body, Is.EqualTo("this is a test"));
        }

        [Test]
        public void SetCommandResultStatusToOkOnSuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice",
                "->",
                "test"
            };
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var addPostCommand = new AddPostCommand();
            var commandResult = addPostCommand.Execute(arguments, userRepository);

            Assert.That(commandResult.Status, Is.EqualTo(CommandResponseStatus.Ok));
        }

        [Test]
        public void ReturnAnEmptyPayloadOnSuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice",
                "->",
                "test"
            };
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var addPostCommand = new AddPostCommand();
            var commandResult = addPostCommand.Execute(arguments, userRepository);

            Assert.That(commandResult.Payload, Is.Empty);
        }

        [Test]
        public void SetCommandResultStatusToErrorOnUnsuccessfulExecution()
        {
            var emptyArgumentsList = new List<string>();
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var addPostCommand = new AddPostCommand();
            var commandResult = addPostCommand.Execute(emptyArgumentsList, userRepository);

            Assert.That(commandResult.Status, Is.EqualTo(CommandResponseStatus.Error));
        }

        [Test]
        public void ReturnAPayloadContainingAnErrorMessageOnUnsuccessfulExecution()
        {
            var emptyArgumentsList = new List<string>();
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var addPostCommand = new AddPostCommand();
            var commandResult = addPostCommand.Execute(emptyArgumentsList, userRepository);

            Assert.That(commandResult.Payload[0].StartsWith("System.ArgumentOutOfRangeException"));
        }
    }
}
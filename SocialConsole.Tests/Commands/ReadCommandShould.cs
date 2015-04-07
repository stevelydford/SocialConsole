using System.Collections.Generic;
using NUnit.Framework;
using SocialConsole.Commands;
using SocialConsole.Domain;
using SocialConsole.Repositories;

namespace SocialConsole.Tests.Commands
{
    [TestFixture]
    public class ReadCommandShould
    {
        [Test]
        public void ReturnAllUserPostsInPayloadWhenSuccessfullyExecuted()
        {
            var userRepository = new UserRepository();
            var user = userRepository.RegisterUser("alice");
            user.Posts.AddRange(
                new List<Post> { new Post("test1"), new Post("test2") }
            );

            var arguments = new List<string>
            {
                "alice"
            };

            var readCommand = new ReadCommand()
            {
                Arguments = arguments,
                UserRepository = userRepository
            };
            var commandResult = readCommand.Execute();

            Assert.That(commandResult.Payload.Count, Is.EqualTo(2));
            Assert.That(commandResult.Payload[0], Is.EqualTo("test1 (0 seconds ago)"));
            Assert.That(commandResult.Payload[1], Is.EqualTo("test2 (0 seconds ago)"));
        }

        [Test]
        public void SetCommandResultStatusToOkOnSuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice"
            };
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var readCommand = new ReadCommand()
            {
                Arguments = arguments,
                UserRepository = userRepository
            };
            var commandResult = readCommand.Execute();

            Assert.That(commandResult.Status, Is.EqualTo(CommandResponseStatus.Ok));
        }

        [Test]
        public void SetCommandResultStatusToErrorOnUnsuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice"
            };
            var emptyUserRepository = new UserRepository();

            var readCommand = new ReadCommand()
            {
                Arguments = arguments,
                UserRepository = emptyUserRepository
            };
            var commandResult = readCommand.Execute();

            Assert.That(commandResult.Status, Is.EqualTo(CommandResponseStatus.Error));
        }

        [Test]
        public void ReturnAPayloadContainingAnErrorMessageOnUnsuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice"
            };
            var emptyUserRepository = new UserRepository();

            var readCommand = new ReadCommand()
            {
                Arguments = arguments,
                UserRepository = emptyUserRepository
            };
            var commandResult = readCommand.Execute();

            Assert.That(commandResult.Payload[0].StartsWith("System.NullReferenceException"));
        }
    }
}

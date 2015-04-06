using System.Collections.Generic;
using NUnit.Framework;
using SocialConsole.Commands;
using SocialConsole.Repositories;

namespace SocialConsole.Tests.Commands
{
    [TestFixture]
    public class FollowCommandShould
    {
        [Test]
        public void AllowAUserToFollowAnotherUserWhenExecuted()
        {
            var arguments = new List<string>
            {
                "alice",
                "follows",
                "bob"
            };
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var followCommand = new FollowCommand()
            {
                Arguments = arguments,
                UserRepository = userRepository
            };
            followCommand.Execute();

            Assert.That(userRepository.GetUser("alice").Friends.Count, Is.EqualTo(1));
        }

        [Test]
        public void SetCommandResultStatusToOkOnSuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice",
                "follows",
                "bob"
            };
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var followCommand = new FollowCommand()
            {
                Arguments = arguments,
                UserRepository = userRepository
            };
            var commandResult = followCommand.Execute();

            Assert.That(commandResult.Status, Is.EqualTo(CommandResponseStatus.Ok));
        }

        [Test]
        public void ReturnAnEmptyPayloadOnSuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice",
                "follows",
                "bob"
            };
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var followCommand = new FollowCommand()
            {
                Arguments = arguments,
                UserRepository = userRepository
            };
            var commandResult = followCommand.Execute();

            Assert.That(commandResult.Payload, Is.Empty);
        }

        [Test]
        public void SetCommandResultStatusToErrorOnUnsuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice",
                "follows"
            };
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var followCommand = new FollowCommand()
            {
                Arguments = arguments,
                UserRepository = userRepository
            };
            var commandResult = followCommand.Execute();

            Assert.That(commandResult.Status, Is.EqualTo(CommandResponseStatus.Error));
        }

        [Test]
        public void ReturnAPayloadContainingAnErrorMessageOnUnsuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice",
                "follows"
            };
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var followCommand = new FollowCommand()
            {
                Arguments = arguments,
                UserRepository = userRepository
            };
            var commandResult = followCommand.Execute();

            Assert.That(commandResult.Payload[0].StartsWith("System.ArgumentOutOfRangeException"));
        }
    }
}

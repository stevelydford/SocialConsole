using System.Collections.Generic;
using NUnit.Framework;
using SocialConsole.Commands;

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
        
            var followCommand = new FollowCommand();
            followCommand.Execute(arguments, userRepository);

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

            var followCommand = new FollowCommand();
            var commandResult = followCommand.Execute(arguments, userRepository);

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

            var followCommand = new FollowCommand();
            var commandResult = followCommand.Execute(arguments, userRepository);

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

            var followCommand = new FollowCommand();
            var commandResult = followCommand.Execute(arguments, userRepository);

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

            var followCommand = new FollowCommand();
            var commandResult = followCommand.Execute(arguments, userRepository);

            Assert.That(commandResult.Payload[0].StartsWith("System.ArgumentOutOfRangeException"));
        }
    }
}

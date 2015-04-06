using System.Collections.Generic;
using NUnit.Framework;
using SocialConsole.Commands;
using SocialConsole.Domain;
using SocialConsole.Repositories;

namespace SocialConsole.Tests.Commands
{
    [TestFixture]
    public class WallCommandShould
    {
        [Test]
        public void ReturnAllPostsOnAUsersWallWhenExecuted()
        {
            var userRepository = new UserRepository();
            var user = userRepository.RegisterUser("alice");
            user.Friends.Add(new User("bob")
            {
                Posts = new List<Post> { new Post("test1"), new Post("test2") }
            });
            user.Friends.Add(new User("colin")
            {
                Posts = new List<Post> { new Post("test3") }
            });

            var arguments = new List<string>
            {
                "alice",
                "wall"
            };

            var wallCommand = new WallCommand();
            var commandResult = wallCommand.Execute(arguments, userRepository);

            Assert.That(commandResult.Payload.Count, Is.EqualTo(3));
            Assert.That(commandResult.Payload[0], Is.EqualTo("bob - test1 (0 seconds ago)"));
            Assert.That(commandResult.Payload[1], Is.EqualTo("bob - test2 (0 seconds ago)"));
            Assert.That(commandResult.Payload[2], Is.EqualTo("colin - test3 (0 seconds ago)"));
        }

        [Test]
        public void SetCommandResultStatusToOkOnSuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice",
                "wall"
            };
            var userRepository = new UserRepository();
            userRepository.RegisterUser("alice");

            var wallCommand = new WallCommand();
            var commandResult = wallCommand.Execute(arguments, userRepository);

            Assert.That(commandResult.Status, Is.EqualTo(CommandResponseStatus.Ok));
        }

        [Test]
        public void SetCommandResultStatusToErrorOnUnsuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice",
                "wall"
            };
            var emptyUserRepository = new UserRepository();

            var wallCommand = new WallCommand();
            var commandResult = wallCommand.Execute(arguments, emptyUserRepository);

            Assert.That(commandResult.Status, Is.EqualTo(CommandResponseStatus.Error));
        }

        [Test]
        public void ReturnAPayloadContainingAnErrorMessageOnUnsuccessfulExecution()
        {
            var arguments = new List<string>
            {
                "alice",
                "wall"
            };
            var emptyUserRepository = new UserRepository();

            var wallCommand = new WallCommand();
            var commandResult = wallCommand.Execute(arguments, emptyUserRepository);

            Assert.That(commandResult.Payload[0].StartsWith("System.NullReferenceException"));
        }
    }
}

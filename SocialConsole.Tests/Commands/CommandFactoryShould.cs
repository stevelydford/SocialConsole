﻿using System.Collections.Generic;
using NUnit.Framework;
using SocialConsole.Commands;
using SocialConsole.Repositories;

namespace SocialConsole.Tests.Commands
{
    [TestFixture]
    public class CommandFactoryShould
    {
        [Test]
        public void ReturnANullCommandIfArgumentIsNotMatched()
        {
            var arguments = new List<string>();
            var userRepository = new UserRepository();

            var commandFactory = new CommandFactory();
            var command = commandFactory.CreateCommand(arguments, userRepository);

            Assert.That(command, Is.InstanceOf<NullCommand>());
        }

        [Test]
        public void ReturnAReadCommandIfSentOnlyOneArgument()
        {
            var arguments = new List<string>() { "alice" };
            var userRepository = new UserRepository();

            var commandFactory = new CommandFactory();
            var command = commandFactory.CreateCommand(arguments, userRepository);

            Assert.That(command, Is.InstanceOf<ReadCommand>());
        }

        [Test]
        public void ReturnAPostCommandIfSecondArgumentMatched()
        {
            var arguments = new List<string>() { "alice", "->", "test" };
            var userRepository = new UserRepository();

            var commandFactory = new CommandFactory();
            var command = commandFactory.CreateCommand(arguments, userRepository);

            Assert.That(command, Is.InstanceOf<PostCommand>());
        }

        [Test]
        public void ReturnAFollowCommandIfSecondArgumentMatched()
        {
            var arguments = new List<string>() { "alice", "follows", "bob" };
            var userRepository = new UserRepository();

            var commandFactory = new CommandFactory();
            var command = commandFactory.CreateCommand(arguments, userRepository);

            Assert.That(command, Is.InstanceOf<FollowCommand>());
        }

        [Test]
        public void ReturnAWallCommandIfSecondArgumentMatched()
        {
            var arguments = new List<string>() { "alice", "wall" };
            var userRepository = new UserRepository();

            var commandFactory = new CommandFactory();
            var command = commandFactory.CreateCommand(arguments, userRepository);

            Assert.That(command, Is.InstanceOf<WallCommand>());
        }
    }
}
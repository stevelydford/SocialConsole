using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace SocialConsole.Tests
{
    [TestFixture]
    public class ConsoleHandlerShould
    {
        [Test]
        public void SendTheUserInputToTheMessageHandlerAndReceiveAListOfStringsInResponse()
        {
            var messageHandler = new MessageHandler(new UserRepository());
            const string inputString = "alice follows bob";

            var result = messageHandler.Process(inputString);
            Assert.That(result, Is.TypeOf<List<string>>());
        }

        [Test]
        public void ContinueToTakeUserInputUntilTheyEnterTheWordExit()
        {
            var stringReader = new StringReader(string.Format("bob->hello{0}bob{0}exit", Environment.NewLine));
            Console.SetIn(stringReader);

            var consoleHandler = new ConsoleHandler();
            var result = consoleHandler.Handle();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void OutputAllItemsInTheResponseToTheConsole()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(string.Format("bob -> hello{0}bob -> test{0}bob{0}exit", Environment.NewLine));
            Console.SetIn(stringReader);

            var consoleHandler = new ConsoleHandler();
            consoleHandler.Handle();

            const string expectedConsoleOutput = "> > > hello (0 seconds ago)\r\ntest (0 seconds ago)\r\n> ";
            
            Assert.That(stringWriter.ToString(), Is.EqualTo(expectedConsoleOutput));
        }
    }
}
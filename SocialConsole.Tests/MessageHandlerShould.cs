using System.Collections.Generic;
using NUnit.Framework;

namespace SocialConsole.Tests
{
    [TestFixture]
    public class MessageHandlerShould
    {
        [Test]
        public void ProcessAnInputStringAndReturnAListOfStrings()
        {
            var messageHandler = new MessageHandler();
            var input = "test";

            var result = messageHandler.Process(input);

            Assert.That(result, Is.All.InstanceOf(typeof(string)));
        }
    }
}

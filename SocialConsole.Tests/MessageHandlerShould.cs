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
            const string input = "test";

            var result = messageHandler.Process(input);

            Assert.That(result, Is.All.InstanceOf(typeof(string)));
        }

        [Test]
        public void SpiltInputStringBySpacesAndStoreAsListArguments()
        {
            var messageHandler = new MessageHandler();
            messageHandler.Process("alice follows bob");

            var result = messageHandler.Arguments;

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo("alice"));
            Assert.That(result[1], Is.EqualTo("follows"));
            Assert.That(result[2], Is.EqualTo("bob"));
        }


    }
}

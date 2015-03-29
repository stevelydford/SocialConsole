using System.Collections.Generic;
using NUnit.Framework;

namespace SocialConsole.Tests
{
    [TestFixture]
    public class ProgramShould
    {
        public void SendTheUserInputToTheMessageHandlerAndReceiveAListOfStringsInResponse()
        {
            var messageHandler = new MessageHandler();
            var inputString = "alice follows bob";

            var result = messageHandler.Process(inputString);
            Assert.That(result, Is.TypeOf<List<string>>());

        }
    }
}

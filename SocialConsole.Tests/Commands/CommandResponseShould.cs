using System.Collections.Generic;
using NUnit.Framework;
using SocialConsole.Commands;

namespace SocialConsole.Tests.Commands
{
    [TestFixture]
    public class CommandResponseShould
    {
        [Test]
        public void SetTheStatusAndPayloadOnConstruction()
        {
            var payload = new List<string> { "test1", "test2" };
            var commandResponse = new CommandResponse(CommandResponseStatus.Error, payload);

            Assert.That(commandResponse.Status, Is.EqualTo(CommandResponseStatus.Error));
            Assert.That(commandResponse.Payload[0], Is.EqualTo("test1"));
            Assert.That(commandResponse.Payload[1], Is.EqualTo("test2"));
        }

        [Test]
        public void SetTheStatusAndEmptyPayloadOnConstructionIfNoPayloadPassedIn()
        {
            var commandResponse = new CommandResponse(CommandResponseStatus.Ok);

            Assert.That(commandResponse.Status, Is.EqualTo(CommandResponseStatus.Ok));
            Assert.That(commandResponse.Payload, Is.Not.Null);
        }
    }
}

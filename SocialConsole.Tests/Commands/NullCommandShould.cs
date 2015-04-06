using NUnit.Framework;
using SocialConsole.Commands;

namespace SocialConsole.Tests.Commands
{
    [TestFixture]
    public class NullCommandShould
    {
        [Test]
        public void ReturnAnErrorResponseWhenExecuted()
        {
            var nullCommand = new NullCommand();
            var commandResponse = nullCommand.Execute();

            Assert.That(commandResponse.Status, Is.EqualTo(CommandResponseStatus.Error));
        }

    }
}
using System;
using System.IO;
using NUnit.Framework;

namespace SocialConsole.Tests
{
    [TestFixture]
    public class ProgramShould
    {
        [Test]
        public void CallTheHandleMethodOfSocialConsole()
        {
            var stringReader = new StringReader("exit");
            Console.SetIn(stringReader);

            var result = Program.Main(new string[] { });
            
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
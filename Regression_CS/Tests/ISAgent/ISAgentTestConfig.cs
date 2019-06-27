using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IonicSecurity.SDK;
using NUnit.Framework;

namespace ISAgentTest
{
    [TestFixture]
    class ISAgentTestConfig : ISAgentTestBase
    {
        [Test]
        public void AgentConfigInitBasic()
        {
            AgentConfig config = new AgentConfig();
            Assert.That(config.IsValid, Is.True);

            config.UserAgent = "Test User Agent";
            Assert.That(config.IsValid, Is.True);
            Assert.That(config.UserAgent == "Test User Agent", Is.True);

            config.HttpImpl = "Scripted";
            Assert.That(config.IsValid, Is.True);
            Assert.That(config.HttpImpl == "Scripted", Is.True);

            config.MaxRedirects = 5;
            Assert.That(config.IsValid, Is.True);
            Assert.That(config.MaxRedirects == 5, Is.True);
        }
    }
}

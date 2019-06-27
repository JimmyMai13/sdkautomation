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
    class ISAgentNetWrapperTestCreateDevice : ISAgentTestBase
    {
        [Test]
        [Category("CreateDevice")]
        public void AgentCreateDeviceNoInit()
        {
            Agent agent = new Agent();
            CreateDeviceRequest request = new CreateDeviceRequest();
            Assert.Throws<SdkException>(() => agent.CreateDevice(request));
        }

        [Test]
        [Category("CreateDevice")]
        public void AgentCreateDeviceSetRsaKey()
        {
            // generate RSA key pair
            RsaKeyGenerator generator = new RsaKeyGenerator();
            RsaPrivateKey privateKey = generator.GeneratePrivateKey(2048);
            RsaPublicKey publicKey = generator.GeneratePublicKey(privateKey);

            // set RSA keys into a CreateDeviceRequest object
            CreateDeviceRequest request = new CreateDeviceRequest();
            request.ClientRsaPrivateKey = privateKey;
            request.ClientRsaPublicKey = publicKey;
        }

        [Test]
        [Category("CreateDevice")]
        [Ignore("Not automating CreateDevice at this time")]
        public void AgentCreateDevice()
        {
            AgentConfig config = new AgentConfig();
            Agent agent = AgentTestUtils.getTestAgent(config);

            CreateDeviceRequest request = new CreateDeviceRequest();
            //request.SetServer("https://api.ionic.engineering");
            request.Server = "https://api.ionic.com";
            request.ETag = "XyZ";
            request.UidAuth = "username@domain";
            request.Token = "abCDEfghiJkLmNOp123=";
            request.EiRsaPublicKeyBase64 = "{A very long public key without newlines}";

            CreateDeviceResponse response = agent.CreateDevice(request);
            Assert.That(response.HttpResponseCode == 200, Is.True);
        }
    }
}

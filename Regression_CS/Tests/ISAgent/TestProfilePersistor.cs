using System;
using System.Collections.Generic;
using IonicSecurity.SDK;
using NUnit.Framework;

namespace ISAgentTest
{
    [TestFixture]
    public class TestProfilePersistor : ISAgentTestSetup
    {
        [Test]
        public void TestDefaultPersistor()
        {
            DeviceProfilePersistorPlaintext plainpersistor = new DeviceProfilePersistorPlaintext();
            plainpersistor.FilePath = "C:\\Users\\jimmy.inIS\\Desktop\\plaintext.txt";

            Console.WriteLine(plainpersistor.FilePath);

            DeviceProfilePersistorDefault persistor = new DeviceProfilePersistorDefault();

            //load profiles
            List<DeviceProfile> profiles = null;
            String activeDeviceId = null;
            plainpersistor.LoadAllProfiles(ref profiles, ref activeDeviceId);

            Console.WriteLine(activeDeviceId);

            Agent agent = new Agent();
            agent.Initialize(plainpersistor);

            CreateKeysRequest.Key requestKey = new CreateKeysRequest.Key("refid_test");
            requestKey.Attributes.Add("classifications", new List<string>());
            requestKey.Attributes["classifications"].Add("c1");

            CreateKeysRequest request = new CreateKeysRequest();
            request.Keys.Add(requestKey);

            CreateKeysResponse response = agent.CreateKeys(request);

            /*
            persistor.SaveAllProfiles(profiles, activeDeviceId);

            List<DeviceProfile> profiles2 = null;
            String activeDeviceId2 = null;
            persistor.LoadAllProfiles(ref profiles2, ref activeDeviceId2);

            Console.WriteLine("----------------");
            Console.WriteLine(activeDeviceId);

            Assert.AreEqual(profiles.Count, profiles2.Count);
            Assert.AreEqual(activeDeviceId, activeDeviceId2);
            */
        }

    }
}

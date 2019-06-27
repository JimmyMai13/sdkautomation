using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using IonicSecurity.SDK;
using ISDataStructures;

namespace ISAgentTest
{
    [TestFixture]
    class ISAgentTestBasic : ISAgentTestBase
    {
        [Test]
        public void AgentBasicTestKeys()
        {
            // create basic test key data
            String keyId = "testKeyId";
            byte[] keyBytes = new byte[] { 0x01, 0x01, 0x01, 0x03 };

            // create test key attributes
            AttributesDictionary keyAttributes = DataStructureHelpers.CreateTestAttributes();
            AttributesDictionary mutableKeyAttributes = DataStructureHelpers.CreateTestAttributes();
            KeyObligationsMap keyObligations = DataStructureHelpers.CreateTestObligations();

            // AgentKey constructors
            {
                // empty constructor
                AgentKey key = new AgentKey();
                Assert.AreEqual(key.Id, "");
                Assert.AreEqual(key.KeyBytes, new byte[] { });
                Assert.AreEqual(key.Attributes, new AttributesDictionary());
                Assert.AreEqual(key.Obligations, new KeyObligationsMap());
                // constructor with key ID and bytes
                key = new AgentKey(keyId, keyBytes);
                Assert.AreEqual(key.Id, keyId);
                Assert.AreEqual(key.KeyBytes, keyBytes);
                Assert.AreEqual(key.Attributes, new AttributesDictionary());
                Assert.AreEqual(key.Obligations, new KeyObligationsMap());

                // constructor with key ID, bytes, and attributes
                key = new AgentKey(keyId, keyBytes, keyAttributes, mutableKeyAttributes, keyObligations);
                Assert.AreEqual(key.Id, keyId);
                Assert.AreEqual(key.KeyBytes, keyBytes);
                Assert.AreEqual(key.Attributes, keyAttributes);
                Assert.AreEqual(key.MutableAttributes, mutableKeyAttributes);
                Assert.AreEqual(key.Obligations, keyObligations);
            }

            // AgentKey accessors
            {
                AgentKey key = new AgentKey();

                // get / set key ID
                key.Id = keyId;
                Assert.AreEqual(key.Id, keyId);

                // get / set key bytes
                key.KeyBytes = keyBytes;
                Assert.AreEqual(key.KeyBytes, keyBytes);

                // get / set key attributes
                key.Attributes = keyAttributes;
                Assert.AreEqual(key.Attributes, keyAttributes);
            }
        }

        [Test]
        public void AgentBasicMetadata()
        {
            // create agent for live server
            using (Agent agent = new Agent())
            {
                String val = agent.GetMetadata("ionic-agent");
                Assert.IsTrue(val.Contains(".NET"));
            }
        }
    }
}

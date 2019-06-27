using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IonicSecurity.SDK;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace ISAgentTest
{
    [SetUpFixture]
    public class ISAgentTestSetup
    {
        [OneTimeSetUp]
        public void Setup()
        {

            //initialize crypto module


            //setup logging
            Console.WriteLine("STARTING");
            String sLoggerConfigFile = AgentTestUtils.buildOutputPath("logger.log");
            LogBase log = LogFactory.GetInstance.CreateSimple(sLoggerConfigFile, true, LogSeverity.SEV_INFO);
            Log.SetSingleton(log);
            Log.LogInfo("ISAgentTestSetup", "We configured the logger successfully!");
        }

        [OneTimeTearDown]
        public void Shutdown()
        {
            Console.WriteLine("FINISHED");

        }
    }

    public class ISAgentTestBase
    {
       [TearDown]
       public void Teardown()
        {
            TestStatus result = TestContext.CurrentContext.Result.Outcome.Status;
        

            if (result == TestStatus.Failed)
            {
                Log.LogError("ISAgent", "TEST FAILURE: {0}", TestContext.CurrentContext.Test.FullName);
            }
        }
    }
}

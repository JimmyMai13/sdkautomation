using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using IonicSecurity.SDK;
using System.IO;

namespace ISAgentTest
{
    public partial class AgentTestUtils
    {
        public static string PATH_TEST_INPUTS = Environment.GetEnvironmentVariable("SDKAUTOMATION_ROOT") + "\\TestInputs\\";
        public static string PATH_TEST_OUTPUTS = Environment.GetEnvironmentVariable("SDKAUTOMATION_ROOT") + "\\TestOutputs\\";
        public static Agent getTestAgent(AgentConfig config = null)
        {
            Agent agent = new Agent();
            DeviceProfilePersistorPlaintext persistor = new DeviceProfilePersistorPlaintext();
            persistor.FilePath = AgentTestUtils.buildInputPath("plaintext.sep");
            if (config != null)
            {
                agent.Initialize(config, persistor);
            }
            else
            {
                agent.Initialize(persistor);
            }
            return agent;
        }

        public static String buildInputPath(String fileName)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine(Path.Combine(PATH_TEST_INPUTS, fileName));
            return Path.Combine(PATH_TEST_INPUTS, fileName);
        }

        public static String buildOutputPath(String fileName)
        {
            return Path.Combine(PATH_TEST_OUTPUTS, fileName);
        }

    }
}

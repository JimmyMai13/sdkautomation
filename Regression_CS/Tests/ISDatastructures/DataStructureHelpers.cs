using IonicSecurity.SDK;
using System.Collections.Generic;

namespace ISDataStructures
{
    public static class DataStructureHelpers
    {
        public static AttributesDictionary CreateTestAttributes()
        {
            AttributesDictionary keyAttributes = new AttributesDictionary();
            keyAttributes.Add("classifications", new List<string>());
            keyAttributes["classifications"].Add("c1");
            keyAttributes["classifications"].Add("c2");

            return keyAttributes;
        }
        public static KeyObligationsMap CreateTestObligations()
        {
            KeyObligationsMap keyObligations = new KeyObligationsMap();
            keyObligations.Add("ionic-offline-enabled", new List<string>() { "true" });
            keyObligations.Add("ionic-offline-duration-seconds", new List<string>() { "86400" }); // 1 day

            return keyObligations;
        }
    }
}
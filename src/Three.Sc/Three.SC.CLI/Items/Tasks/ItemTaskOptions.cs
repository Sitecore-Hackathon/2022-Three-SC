using Sitecore.DevEx.Client.Tasks;
using System.Collections.Generic;

namespace Three.SC.CLI.Tasks
{
    public class ItemTaskOptions : TaskOptionsBase
    {
        public string Config { get; set; }

        public string EnvironmentName { get; set; }

        public bool Verbose { get; set; }

        public bool Trace { get; set; }

        public List<string> Items { get; set; }

        public override void Validate()
        {
            this.Require("Config");
            this.Default("EnvironmentName", (object)"default");
        }
    }
}

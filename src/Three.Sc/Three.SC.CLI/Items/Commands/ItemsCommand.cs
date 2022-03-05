    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using System.CommandLine;

namespace Three.SC.CLI.Commands
{
    public class ItemsCommand : Command, ISubcommand
    {
        public ItemsCommand(string name, string description = null)
          : base(name, description)
        {
        }
    }
}

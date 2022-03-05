using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using Sitecore.DevEx.Client.Tasks;
using Three.SC.CLI.Tasks;
using System;
using System.CommandLine;
using System.Threading.Tasks;

namespace Three.SC.CLI.Commands
{
    public class LockedItemsListCommand : SubcommandBase<LockedItemsListTask, ItemTaskOptions>
    {
        public LockedItemsListCommand(IServiceProvider container)
          : base("listlocked", "Get locked items list", container)
        {
            ((Command)this).AddOption(ArgOptions.EnvironmentName);
            ((Command)this).AddOption(ArgOptions.Config);
            ((Command)this).AddOption(ArgOptions.Trace);
            ((Command)this).AddOption(ArgOptions.Items);
        }

        protected override async Task<int> Handle(LockedItemsListTask task, ItemTaskOptions args)
        {
            ((TaskOptionsBase)args).Validate();
            await task.Execute(args).ConfigureAwait(false);
            return 0;
        }

       
    }
}

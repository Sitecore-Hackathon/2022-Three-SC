using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Sitecore.Devex.Client.Cli.Extensibility;
using Sitecore.Devex.Client.Cli.Extensibility.Subcommands;
using Three.SC.CLI.Commands;
using Three.SC.CLI.Tasks;
using Three.SC.CLI.Client.Services;
using Sitecore.DevEx.Serialization.Client;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Diagnostics.CodeAnalysis;


namespace Three.SC.CLI
{
    public class RegisterExtension : ISitecoreCliExtension
    {
        public IEnumerable<ISubcommand> AddCommands(IServiceProvider container) => (IEnumerable<ISubcommand>)new ISubcommand[1]
        {
      RegisterExtension.CreateIndexCommand(container)
        };

        [ExcludeFromCodeCoverage]
        public void AddConfiguration(IConfigurationBuilder configBuilder)
        {
        }

        public void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSerialization()
                .AddSingleton<LockedItemsListCommand>().AddSingleton<IItemListService, ItemListService>()
                .AddSingleton<ILogger<LockedItemsListTask>>((Func<IServiceProvider, ILogger<LockedItemsListTask>>)(t => t.GetService<ILoggerFactory>().CreateLogger<LockedItemsListTask>()));

            serviceCollection.AddSerialization()
                .AddSingleton<UnLockItemsCommand>().AddSingleton<IItemModificationService, ItemModificationService>()
                .AddSingleton<ILogger<UnLockItemsTask>>((Func<IServiceProvider, ILogger<UnLockItemsTask>>)(t => t.GetService<ILoggerFactory>().CreateLogger<UnLockItemsTask>()));

            serviceCollection.TryAddTransient<ITreeSyncOperationExecutor, TreeSyncOperationExecutor>();
            serviceCollection.TryAddTransient<IEnvironmentConfigurationProvider, EnvironmentConfigurationProvider>();
        }

        private static ISubcommand CreateIndexCommand(IServiceProvider container)
        {
            ItemsCommand itemsCommand = new ItemsCommand("items", "working with locked items data");
            ((Symbol)itemsCommand).AddAlias("items");
            itemsCommand.AddCommand((Command)container.GetRequiredService<LockedItemsListCommand>());
            itemsCommand.AddCommand((Command)container.GetRequiredService<UnLockItemsCommand>());
            return (ISubcommand)itemsCommand;
        }
    }
}

using Microsoft.Extensions.Logging;
using Sitecore.DevEx.Client.Logging;
using Sitecore.DevEx.Configuration.Models;
using Three.SC.CLI.Client.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Three.SC.CLI.Tasks
{
    public class LockedItemsListTask
    {
        private readonly ILogger<LockedItemsListTask> _logger;
        private readonly IItemListService _ItemListService;
        private readonly IEnvironmentConfigurationProvider _configurationProvider;

        public LockedItemsListTask(
          IItemListService ItemListService,
          ILogger<LockedItemsListTask> logger,
          IEnvironmentConfigurationProvider configurationProvider)
        {
            this._ItemListService = ItemListService;
            this._logger = logger;
            this._configurationProvider = configurationProvider;
        }

        public async Task Execute(ItemTaskOptions args)
        {
            EnvironmentConfiguration configurationAsync = await this._configurationProvider.GetEnvironmentConfigurationAsync(args.Config, args.EnvironmentName);

            Stopwatch stopwatch = Stopwatch.StartNew();
            List<string> list = (await this._ItemListService.GetLockedItemsListAsync(configurationAsync, args.Items).ConfigureAwait(false)).ToList<string>();
            this._logger.LogTrace(string.Format("Locked Items: Loaded in {0}ms ({1} items).", (object)stopwatch.ElapsedMilliseconds, (object)list.Count));
            ColorLogExtensions.LogConsoleInformation((ILogger)this._logger, "Locked Items list:", new ConsoleColor?(ConsoleColor.Yellow), new ConsoleColor?());
            foreach (string str in list)
                ColorLogExtensions.LogConsoleInformation((ILogger)this._logger, str, new ConsoleColor?(ConsoleColor.Green), new ConsoleColor?());
            stopwatch = (Stopwatch)null;
        }
    }
}

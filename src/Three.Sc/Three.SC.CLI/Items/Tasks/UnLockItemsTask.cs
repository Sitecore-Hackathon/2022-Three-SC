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
    public class UnLockItemsTask
    {
        private readonly ILogger<UnLockItemsTask> _logger;
        private readonly IItemModificationService _ItemModificationService;
        private readonly IEnvironmentConfigurationProvider _configurationProvider;

        public UnLockItemsTask(
          IItemModificationService ItemModificationService,
          ILogger<UnLockItemsTask> logger,
          IEnvironmentConfigurationProvider configurationProvider)
        {
            this._ItemModificationService = ItemModificationService;
            this._logger = logger;
            this._configurationProvider = configurationProvider;
        }

        public async Task Execute(ItemTaskOptions args)
        {
            EnvironmentConfiguration configurationAsync = await this._configurationProvider.GetEnvironmentConfigurationAsync(args.Config, args.EnvironmentName);

            Stopwatch stopwatch = Stopwatch.StartNew();
            List<string> list = (await this._ItemModificationService.UnLockItemsAsync(configurationAsync, args.Items).ConfigureAwait(false)).ToList<string>();
            this._logger.LogTrace(string.Format("UnLock Items: Loaded in {0}ms ({1} items).", (object)stopwatch.ElapsedMilliseconds, (object)list.Count));
            ColorLogExtensions.LogConsoleInformation((ILogger)this._logger, "The following items could not be locked:", new ConsoleColor?(ConsoleColor.Yellow), new ConsoleColor?());
            foreach (string str in list)
                ColorLogExtensions.LogConsoleInformation((ILogger)this._logger, str, new ConsoleColor?(ConsoleColor.Green), new ConsoleColor?());
            stopwatch = (Stopwatch)null;
        }
    }
}

using Sitecore.DevEx.Configuration.Models;
using Three.SC.CLI.Client.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Three.SC.CLI.Client.Services
{
    public interface IItemModificationService
    {
        Task<IEnumerable<string>> UnLockItemsAsync(
          EnvironmentConfiguration configuration,
          IEnumerable<string> itemsIds,
          CancellationToken cancellationToken = default(CancellationToken));
    }
}

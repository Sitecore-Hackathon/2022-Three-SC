using Sitecore.DevEx.Configuration.Models;
using Three.SC.CLI.Client.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Three.SC.CLI.Client.Services
{
    public interface IItemListService
    {
        Task<IEnumerable<string>> GetLockedItemsListAsync(
          EnvironmentConfiguration configuration,
          IEnumerable<string> itemsNames,
          CancellationToken cancellationToken = default(CancellationToken));
    }
}

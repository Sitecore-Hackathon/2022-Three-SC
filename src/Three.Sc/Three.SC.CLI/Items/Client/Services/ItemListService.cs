using GraphQL.Common.Request;
using Sitecore.DevEx.Configuration.Models;
using Three.SC.CLI.Client.Models;
using Sitecore.DevEx.Serialization.Client.Datasources.Sc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Three.SC.CLI.Client.Services
{
    public class ItemListService : IItemListService
    {
        private const string _indexesList = "\nquery{\n  indexesList\n}";
        private const string _indexesStatisticsList = "\nquery{\n  indexesStatistic {\n    name,\n    hasDeletions,\n    lastUpdated,\n    numberOfDocuments,\n    numberOfFields,\n    numberOfTerms,\n    rebuildTime,\n    rebuildThroughputTime\n  }\n}";
        private readonly ISitecoreApiClient _apiClient;

        public ItemListService(ISitecoreApiClient apiClient) => this._apiClient = apiClient;

        public Task<IEnumerable<string>> GetLockedItemsListAsync(
          EnvironmentConfiguration configuration,
          IEnumerable<string> itemsNames,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            List<string> result = new List<string> { "Item1", "Item2", "Item3" };
            if (itemsNames != null && itemsNames.Count() > 0)
            {
                result.AddRange(itemsNames);
            }
            return Task.FromResult(result.AsEnumerable());

            //ISitecoreApiClient apiClient = this._apiClient;
            //if (apiClient.Endpoint == null)
            //{
            //    EnvironmentConfiguration environmentConfiguration;
            //    apiClient.Endpoint = environmentConfiguration = configuration;
            //}
            //return this._apiClient.RunQuery<IEnumerable<string>>("/sitecore/api/management", new GraphQLRequest()
            //{
            //    Query = "\nquery{\n  indexesList\n}",
            //    Variables = (object)new Dictionary<string, object>()
            //}, "indexesList", cancellationToken);
        }
    }
}

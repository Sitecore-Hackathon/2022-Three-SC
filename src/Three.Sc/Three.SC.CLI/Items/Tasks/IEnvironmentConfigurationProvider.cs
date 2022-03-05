using Sitecore.DevEx.Configuration.Models;
using System.Threading.Tasks;

namespace Three.SC.CLI.Tasks
{
    public interface IEnvironmentConfigurationProvider
    {
        Task<EnvironmentConfiguration> GetEnvironmentConfigurationAsync(
          string currentDirectory,
          string environmentName);
    }
}

using Microsoft.Extensions.Configuration;

namespace Betty_Games.Configuration
{
    internal class AppConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return default;
        }
    }
}

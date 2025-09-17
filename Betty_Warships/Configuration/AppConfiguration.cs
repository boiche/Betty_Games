using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Betty_Games.Configuration
{
    public class AppConfiguration : IConfigurationProvider
    {
        private readonly IConfigurationRoot _config;
        private readonly string _environment;

        public int BoardRows { get => _config.GetValue<int>("Board:Rows"); }
        public int BoardCols { get => _config.GetValue<int>("Board:Cols"); }
        public AppConfiguration()
        {
            _environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";
            _config = new ConfigurationBuilder()
                .SetBasePath($"{AppContext.BaseDirectory}/Configuration")
                .AddJsonFile($"appsettings.{_environment}.json", true, true)
                .Build();
        }

        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string? parentPath)
        {
            if (string.IsNullOrEmpty(parentPath))
                return [];

            var childKeys = new HashSet<string>(earlierKeys);

            IConfigurationSection section = _config.GetSection(parentPath);

            foreach (var child in section.GetChildren())
            {
                childKeys.Add(child.Key);
            }

            return childKeys;
        }
        public IChangeToken GetReloadToken() => default;
        public void Load() { }
        public void Set(string key, string? value) => _config[key] = value;
        public bool TryGet(string key, out string? value)
        {
            value = _config?[key];
            return value != null;
        }
    }
}

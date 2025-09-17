using Microsoft.Extensions.Configuration;

namespace Betty_Games.Configuration
{
    public class AppConfiguration(IConfiguration config) : IAppConfiguration
    {
        public int BoardRows { get => config.GetValue<int>("Board:Rows"); }
        public int BoardCols { get => config.GetValue<int>("Board:Cols"); }
    }
}

using Betty_Games.Configuration;
using Betty_Games.Interfaces;
using Betty_Games.Warships;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Betty_Games
{
    internal class Program
    {
        static void Main()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(config =>
                {
                    config.SetBasePath($"{AppContext.BaseDirectory}/Configuration");
                    config.AddJsonFile($"appsettings.Development.json", true, true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IGameController, WarshipsGameController>();
                    services.AddSingleton<IGameEngine, WarshipsGameEngine>();
                    services.AddSingleton<IGameRenderer, WarshipsGameRenderer>();
                    services.AddSingleton<IGameInputProvider, WarshipsInputProvider>();
                    services.AddSingleton<IAppConfiguration, AppConfiguration>();
                })
                .UseEnvironment(Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development")
                .UseConsoleLifetime();

            var host = builder.Build();
            var gameController = host.Services.GetService<IGameController>();
            gameController?.Run();
        }
    }
}

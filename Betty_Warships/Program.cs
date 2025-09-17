using Betty_Games.Configuration;
using Betty_Games.Interfaces;
using Betty_Games.Warships;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Betty_Games
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(config => config.Add(new AppConfigurationSource()))
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<AppConfiguration>(hostContext.Configuration);
                    services.AddHostedService<GameController>();
                    services.AddSingleton<IGameEngine, WarshipsGameEngine>();
                    services.AddSingleton<IGameRenderer, WarshipsGameRenderer>();
                })
                .UseEnvironment(Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development")
                .UseConsoleLifetime()
                .UseSerilog();

            var host = builder.Build();
            host.Run();
        }
    }
}

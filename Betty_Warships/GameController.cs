using Betty_Games.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Betty_Games
{
    public class GameController(IGameEngine gameEngine) : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            while (!gameEngine.IsGameOver)
            {
                gameEngine.MakeMove();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

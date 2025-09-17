using Betty_Games.Configuration;
using Betty_Games.Interfaces;

namespace Betty_Games.Warships
{
    public class WarshipsGameController(IGameEngine gameEngine, IAppConfiguration configuration) : IGameController
    {
        public void Restart()
        {
            gameEngine.Reset();
            Run();
        }

        public void Run()
        {
            if (configuration.BoardRows < 5)
                throw new ArgumentOutOfRangeException(nameof(IAppConfiguration.BoardRows), $"Configured rows cannot be less than 5");
            if (configuration.BoardCols < 5)
                throw new ArgumentOutOfRangeException(nameof(IAppConfiguration.BoardCols), $"Configured columns cannot be less than 5");

            while (!gameEngine.IsGameOver)
            {
                gameEngine.MakeMove();
            }

            Stop();
        }

        public void Stop()
        {
            gameEngine.GameRenderer.DisplayMessage("Game over! Thank you for playing!", MessageLevel.Info);
            gameEngine.GameRenderer.DisplayMessage("Start new game? Y/y (Yes), N/n (No)", MessageLevel.Info);
            string? input = gameEngine.GameInputProvider.ReadInput().ToString();

            if (input?.Length == 1 && char.ToLower(char.Parse(input)).Equals('y'))
                Restart();
        }
    }
}

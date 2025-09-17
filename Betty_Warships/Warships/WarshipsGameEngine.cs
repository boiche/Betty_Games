#nullable disable
using Betty_Games.Configuration;
using Betty_Games.Interfaces;
using Microsoft.Extensions.Options;

namespace Betty_Games.Warships
{
    public class WarshipsGameEngine : IGameEngine
    {
        private readonly IGameRenderer _gameRenderer;
        private readonly IOptions<AppConfiguration> _config;
        private Board _board;
        private bool _isGameOver;

        public WarshipsGameEngine(IGameRenderer gameRenderer, IOptions<AppConfiguration> config)
        {
            _gameRenderer = gameRenderer;
            _config = config;

            InitGame();
        }

        public bool IsGameOver => _isGameOver;
        public IGameRenderer GameRenderer => _gameRenderer;

        public void MakeMove()
        {
            Console.Write("Shoot at: ");
            if (!Command.TryParse(Console.ReadLine(), out Command command))
            {
                GameRenderer.DisplayMessage("Invalid command. Please enter coordinates in format [\\w][\\d].", MessageLevel.Warning);
                return;
            }
            if (command.Row >= _board.Rows || command.Col >= _board.Cols || command.Row < 0 || command.Col < 0)
            {
                GameRenderer.DisplayMessage("Coordinates out of bounds. Please try again.", MessageLevel.Warning);
                return;
            }

            if (_board.ShotAt(command))
            {
                GameRenderer.DisplayMessage("Hit!", MessageLevel.Info);
            }
            else
            {
                GameRenderer.DisplayMessage("Miss!", MessageLevel.Info);
            }

            GameRenderer.Render(_board);

            if (false)
                _isGameOver = true;
        }

        public void Reset()
        {
            InitGame();
        }

        private void InitGame()
        {
            _isGameOver = false;
            _board = new(_config.Value.BoardRows, _config.Value.BoardCols)
        }
    }
}

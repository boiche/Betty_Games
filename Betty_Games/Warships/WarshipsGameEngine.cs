#nullable disable
using Betty_Games.Configuration;
using Betty_Games.Interfaces;

namespace Betty_Games.Warships
{
    public class WarshipsGameEngine : IGameEngine
    {
        private readonly IGameRenderer _gameRenderer;
        private readonly IGameInputProvider _gameInputProvider;
        private readonly IAppConfiguration _config;
        private WarshipsBoard _board;
        private bool _isGameOver;

        public WarshipsGameEngine(IGameRenderer gameRenderer, IGameInputProvider gameInputProvider, IAppConfiguration config)
        {
            _gameRenderer = gameRenderer;
            _gameInputProvider = gameInputProvider;
            _config = config;
            InitialiseGame();
        }

        public bool IsGameOver => _isGameOver;
        public IGameRenderer GameRenderer => _gameRenderer;
        public IGameInputProvider GameInputProvider => _gameInputProvider;

        public void MakeMove()
        {
            GameRenderer.DisplayMessage("Shoot at: ", MessageLevel.Info);

            if (!WarshipsCommand.TryParse(_gameInputProvider.ReadInput().ToString(), out WarshipsCommand command))
            {
                GameRenderer.DisplayMessage($"Invalid command. Please enter coordinates in format [A-{WarshipsBoard.GetColName(_board.Rows - 1)}][1-{_board.Cols}].", MessageLevel.Warning);
                return;
            }
            if (command.Row >= _board.Rows || command.Col >= _board.Cols || command.Row < 0 || command.Col < 0)
            {
                GameRenderer.DisplayMessage($"Coordinates out of bounds. Must be within the range [A-{WarshipsBoard.GetColName(_board.Rows - 1)}][1-{_board.Cols}].", MessageLevel.Warning);
                return;
            }

            WarshipsShotStatus status = _board.ShotAt(command);

            switch (status)
            {
                case WarshipsShotStatus.Miss:
                    GameRenderer.DisplayMessage("Miss!", MessageLevel.Info); break;
                case WarshipsShotStatus.Hit:
                    GameRenderer.DisplayMessage("Hit!", MessageLevel.Info); break;
                case WarshipsShotStatus.Sunk:
                    GameRenderer.DisplayMessage("Ship Sunk!", MessageLevel.Info); break;
            }

            GameRenderer.Render(_board);

            if (_board.AllShipsSunk)
                _isGameOver = true;
        }

        public void Reset()
        {
            InitialiseGame();
        }
        private void InitialiseGame()
        {
            _isGameOver = false;
            _board = new WarshipsBoard(_config.BoardRows, _config.BoardCols);
        }
    }
}

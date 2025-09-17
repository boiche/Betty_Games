using Betty_Games.Interfaces;

namespace Betty_Games.Warships
{
    public class Board : IGameMap
    {
        private readonly char[,] _board;
        private readonly int _rows;
        private readonly int _cols;
        public int Rows => _rows;
        public int Cols => _cols;

        public static char EmptyCell { get => 'o'; }
        public static char HitCell { get => 'x'; }

        public char this[int row, int col]
        {
            get { return _board[row, col]; }
            set { _board[row, col] = value; }
        }

        public Board(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;

            _board = new char[_rows, _cols];
            InitializeBoard();
            PlaceShips();
        }

        internal bool ShotAt(Command command)
        {
            char currentSpot = this[command.Row, command.Col];
            bool isHit = currentSpot != EmptyCell && currentSpot != HitCell;
            if (isHit)
                _board[command.Row, command.Col] = 'x';

            return isHit;
        }
        private void InitializeBoard()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    _board[row, col] = EmptyCell;
                }
            }
        }
        private void PlaceShips()
        {
            int[] shipsLength = [5, 4, 3, 3, 2];
            for (int i = 0; i < shipsLength.Length; i++)
            {
                int currentShip = shipsLength[i];
                int startRow = Random.Shared.Next(0, _rows);
                int startCol = Random.Shared.Next(0, _cols);

                HashSet<int> attempts = [];
                while (attempts.Count < 4)
                {
                    int direction = Random.Shared.Next(0, 4); // 0: up, 1: right, 2: down, 3: left
                    if (!attempts.Add(direction))
                        continue;

                    if (startRow - currentShip < 0 && direction == 0)
                        continue;
                    if (startRow + currentShip >= _rows && direction == 2)
                        continue;
                    if (startCol + currentShip >= _cols && direction == 1)
                        continue;
                    if (startCol - currentShip < 0 && direction == 3)
                        continue;

                    if (TryPlaceShip(startRow, startCol, direction, currentShip, i))
                        break;
                }

                if (attempts.Count == 4)
                    i--;
            }
        }
        private bool TryPlaceShip(int startRow, int startCol, int direction, int currentShip, int shipId)
        {
            if (currentShip == 0)
                return true;

            if (_board[startRow, startCol] == EmptyCell)
            {
                _board[startRow, startCol] = char.Parse(shipId.ToString());
                return direction switch
                {
                    0 => TryPlaceShip(startRow - 1, startCol, direction, currentShip - 1, shipId),
                    1 => TryPlaceShip(startRow, startCol + 1, direction, currentShip - 1, shipId),
                    2 => TryPlaceShip(startRow + 1, startCol, direction, currentShip - 1, shipId),
                    3 => TryPlaceShip(startRow, startCol - 1, direction, currentShip - 1, shipId),
                    _ => false,
                };
            }
            else
                return false;
        }
    }
}

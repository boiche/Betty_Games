using Betty_Games.Interfaces;

namespace Betty_Games.Warships
{
    public class WarshipsBoard : IGameMap<char>
    {
        private readonly char[,] _board;
        private readonly int _rows;
        private readonly int _cols;
        private readonly Dictionary<int, int> _shipHP;
        private readonly int[] _shipsLength = [5, 4, 3, 3, 2];
        public int Rows => _rows;
        public int Cols => _cols;
        public bool AllShipsSunk { get => _shipHP.All(x => x.Value == 0); }

        public static char EmptyCell { get => '.'; }
        public static char HitCell { get => 'x'; }
        public static char MissCell { get => 'o'; }

        public char this[int row, int col]
        {
            get { return _board[row, col]; }
            set { _board[row, col] = value; }
        }

        public WarshipsBoard(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
            _shipHP = [];
            _board = new char[_rows, _cols];

            for (int i = 0; i < _shipsLength.Length; i++)
            {
                _shipHP.Add(i, _shipsLength[i]);
            }

            InitializeBoard();
            PlaceShips();
        }

        public WarshipsShotStatus ShotAt(WarshipsCommand command)
        {
            WarshipsShotStatus status;
            char currentCell = this[command.Row, command.Col];
            bool isHit = char.IsDigit(currentCell);
            if (isHit)
            {
                int shipId = int.Parse(currentCell.ToString());
                _shipHP[shipId]--;

                if (_shipHP[shipId] > 0)
                    status = WarshipsShotStatus.Hit;
                else
                    status = WarshipsShotStatus.Sunk;

                _board[command.Row, command.Col] = HitCell;
            }
            else
            {
                status = WarshipsShotStatus.Miss;

                if (currentCell == EmptyCell)
                    _board[command.Row, command.Col] = MissCell;
            }

            return status;
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
            for (int i = 0; i < _shipsLength.Length; i++)
            {
                int currentShip = _shipsLength[i];
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
        private bool TryPlaceShip(int startRow, int startCol, int direction, int currentShipLength, int shipId)
        {
            if (currentShipLength == 0)
                return true;

            if (_board[startRow, startCol] == EmptyCell)
            {
                _board[startRow, startCol] = char.Parse(shipId.ToString());

                var isPlaced = direction switch
                {
                    0 => TryPlaceShip(startRow - 1, startCol, direction, currentShipLength - 1, shipId),
                    1 => TryPlaceShip(startRow, startCol + 1, direction, currentShipLength - 1, shipId),
                    2 => TryPlaceShip(startRow + 1, startCol, direction, currentShipLength - 1, shipId),
                    3 => TryPlaceShip(startRow, startCol - 1, direction, currentShipLength - 1, shipId),
                    _ => false,
                };

                if (!isPlaced)
                    _board[startRow, startCol] = EmptyCell;

                return isPlaced;
            }
            else
                return false;
        }

        internal static string GetColName(int row)
        {
            if (row < 0)
                return string.Empty;

            int _base = 'Z' - 'A' + 1;

            int remainder;
            Stack<char> chars = [];

            while (row >= 0)
            {
                remainder = row % _base;
                chars.Push((char)('A' + remainder));
                row = row / _base - 1;
            }

            return new string([.. chars]);
        }
    }
}

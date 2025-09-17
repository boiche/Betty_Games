using Betty_Games.Interfaces;

namespace Betty_Games.Warships
{
    public class WarshipsGameRenderer : IGameRenderer
    {
        public void DisplayMessage(string message, MessageLevel level)
        {
            switch (level)
            {
                case MessageLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case MessageLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case MessageLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Render<T>(IGameMap<T> map)
        {
            if (map is not WarshipsBoard)
                throw new NotSupportedException($"Provided map of type {map.GetType().Name} is not supported");

            Console.Write("  ");
            for (int i = 1; i <= map.Cols; i++)
            {
                if (i < 10)
                    Console.Write($" {i} ");
                else
                    Console.Write($"{i} ");
            }
            Console.WriteLine();

            for (int row = 0; row < map.Rows; row++)
            {
                string colName = WarshipsBoard.GetColName(row);
                if (colName.Length == 1)
                    Console.Write($"{colName} ");
                else
                    Console.Write(colName);

                for (int col = 0; col < map.Cols; col++)
                {
                    Console.Write($" {map[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

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

        public void Render(IGameMap map)
        {
            Board board = (Board)map;
            for (int row = 0; row < board.Rows; row++)
            {
                for (int col = 0; col < board.Cols; col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

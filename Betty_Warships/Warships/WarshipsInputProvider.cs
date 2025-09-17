using Betty_Games.Interfaces;

namespace Betty_Games.Warships
{
    public class WarshipsInputProvider : IGameInputProvider
    {
        public object ReadInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}

namespace Betty_Games.Interfaces
{
    public interface IGameEngine
    {
        public IGameRenderer GameRenderer { get; }
        public bool IsGameOver { get; }

        void MakeMove();
        void Reset();
    }
}

namespace Betty_Games.Interfaces
{
    public interface IGameEngine
    {
        public IGameRenderer GameRenderer { get; }
        public bool IsGameOver { get; }
        public IGameInputProvider GameInputProvider { get; }

        void MakeMove();
        void Reset();
    }
}

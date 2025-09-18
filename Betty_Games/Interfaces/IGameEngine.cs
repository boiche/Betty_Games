namespace Betty_Games.Interfaces
{
    /// <summary>
    /// The core of a game
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Holds the specific rendering capability for the game
        /// </summary>
        public IGameRenderer GameRenderer { get; }
        /// <summary>
        /// Indicates if game has finished
        /// </summary>
        public bool IsGameOver { get; }
        /// <summary>
        /// Holds the specific input source for the game
        /// </summary>
        public IGameInputProvider GameInputProvider { get; }

        /// <summary>
        /// Defines a single cycle of user input and following game actions
        /// </summary>
        void MakeMove();
        /// <summary>
        /// Resets game stats to initial
        /// </summary>
        void Reset();
    }
}

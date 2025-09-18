namespace Betty_Games.Interfaces
{
    /// <summary>
    /// Wrapper of a game. Hosts a game and manages it state
    /// </summary>
    public interface IGameController
    {
        /// <summary>
        /// Starts the game
        /// </summary>
        void Run();
        /// <summary>
        /// Stops and starts the game
        /// </summary>
        void Restart();
        /// <summary>
        /// Stops the game
        /// </summary>
        void Stop();
    }
}

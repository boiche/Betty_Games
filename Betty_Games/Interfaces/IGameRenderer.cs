namespace Betty_Games.Interfaces
{
    /// <summary>
    /// Defines the rendering capabilities for the game.
    /// </summary>
    public interface IGameRenderer
    {
        /// <summary>
        /// Renders the current state of the game to the display.
        /// </summary>
        void Render<T>(IGameMap<T> gameMap);
        /// <summary>
        /// Displays a message to the player
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        void DisplayMessage(string message, MessageLevel level);
    }
}

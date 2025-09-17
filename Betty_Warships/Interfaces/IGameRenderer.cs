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
        void Render(IGameMap gameMap);
        void DisplayMessage(string message, MessageLevel level);
    }
}

namespace Betty_Games.Interfaces
{
    /// <summary>
    /// Provides input for the users
    /// </summary>
    public interface IGameInputProvider
    {
        /// <summary>
        /// Prompts the user to provide an input
        /// </summary>
        /// <returns></returns>
        object ReadInput();
    }
}

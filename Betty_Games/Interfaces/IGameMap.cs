namespace Betty_Games.Interfaces
{
    /// <summary>
    /// Defines a map used in a game
    /// </summary>
    /// <typeparam name="T">The type of objects placed on the map</typeparam>
    public interface IGameMap<T>
    {
        public int Rows { get; }
        public int Cols { get; }
        public T this[int row, int col] { get; set; }
    }
}

namespace Betty_Games.Interfaces
{
    public interface IGameMap<T>
    {
        public int Rows { get; }
        public int Cols { get; }
        public T this[int row, int col] { get; set; }
    }
}

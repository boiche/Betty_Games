using Betty_Games.Warships;

namespace Betty_Games.Tests.Warships
{
    [TestClass]
    public sealed class WarshipsBoardTests
    {
        [TestMethod]
        public void InitialiseBoard_ValidBoardWithShips()
        {
            WarshipsBoard board = new(10, 10);

            Assert.AreEqual(10, board.Rows);
            Assert.AreEqual(10, board.Cols);
        }
    }
}

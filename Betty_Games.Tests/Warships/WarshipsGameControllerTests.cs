using Betty_Games.Warships;

namespace Betty_Games.Tests.Warships
{
    [TestClass]
    public class WarshipsGameControllerTests : WarshipsTestBase
    {
        [TestMethod]
        public void WarshipsGameController_Run_InvalidMapCols()
        {
            MockConfiguration.Setup(x => x.BoardCols).Returns(4);
            WarshipsGameController gameController = new(MockGameEngine.Object, MockConfiguration.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(gameController.Run);
        }

        [TestMethod]
        public void WarshipsGameController_Run_InvalidMapRows()
        {
            MockConfiguration.Setup(x => x.BoardRows).Returns(4);
            WarshipsGameController gameController = new(MockGameEngine.Object, MockConfiguration.Object);

            Assert.ThrowsException<ArgumentOutOfRangeException>(gameController.Run);
        }
    }
}

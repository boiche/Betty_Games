using Betty_Games.Interfaces;
using Betty_Games.Warships;

namespace Betty_Games.Tests.Warships
{
    [TestClass]
    public class WarshipsGameEngineTests : WarshipsTestBase
    {
        [TestMethod]
        public void MyTestMethod()
        {
            WarshipsGameEngine gameEngine = new(MockGameRenderer.Object, MockGameInputProvider.Object, MockConfiguration.Object);

            Assert.IsInstanceOfType<IGameRenderer>(gameEngine.GameRenderer);            
            Assert.IsInstanceOfType<IGameInputProvider>(gameEngine.GameInputProvider);
            Assert.IsFalse(gameEngine.IsGameOver);
        }
    }
}

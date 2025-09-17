#nullable disable
using Betty_Games.Configuration;
using Betty_Games.Interfaces;
using Moq;

namespace Betty_Games.Tests.Warships
{
    public class WarshipsTestBase
    {
        protected Mock<IAppConfiguration> MockConfiguration;
        protected Mock<IGameEngine> MockGameEngine;
        protected Mock<IGameRenderer> MockGameRenderer;
        protected Mock<IGameInputProvider> MockGameInputProvider;

        [TestInitialize]
        public void Setup()
        {
            MockConfiguration = new Mock<IAppConfiguration>();
            MockConfiguration.Setup(x => x.BoardCols).Returns(10);
            MockConfiguration.Setup(x => x.BoardRows).Returns(10);

            MockGameEngine = new Mock<IGameEngine>();
            MockGameRenderer = new Mock<IGameRenderer>();
            MockGameInputProvider = new Mock<IGameInputProvider>();
        }
    }
}

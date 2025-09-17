using Betty_Games.Warships;

namespace Betty_Games.Tests.Warships
{
    [TestClass]
    public class WarshipsCommandTests
    {
        [TestMethod]
        public void ParseCommand_ReturnsCommand()
        {
            string[] input = ["A1", "A10", "AA1", "b1", "bb1"];

            foreach (var item in input)
            {
                var result = WarshipsCommand.TryParse(item, out WarshipsCommand? command);
                Assert.IsNotNull(command);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void ParseCommand_InvalidCommand_ReturnsDefault()
        {
            string[] input = ["123", "ABC"];

            foreach (var item in input)
            {
                var result = WarshipsCommand.TryParse(item, out WarshipsCommand? command);

                Assert.IsNull(command);
                Assert.IsFalse(result);
            }
        }
    }
}

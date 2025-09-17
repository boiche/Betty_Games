using Betty_Games.Warships;

namespace Betty_Games.Tests.Warships
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void ParseCommand_ReturnsCommand()
        {
            var result = Command.TryParse("A1", out Command? command);

            Assert.IsNotNull(command);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ParseCommand_InvalidCommand_ReturnsDefault()
        {
            var result = Command.TryParse("123", out Command? numericCommand);
            var result2 = Command.TryParse("ABC", out Command? lettersCommand);

            Assert.IsNull(numericCommand);
            Assert.IsNull(lettersCommand);
            Assert.IsFalse(result);
            Assert.IsFalse(result2);
        }
    }
}

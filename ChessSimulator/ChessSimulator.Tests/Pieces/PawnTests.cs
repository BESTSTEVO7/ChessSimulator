using Moq;
using NUnit.Framework;

namespace ChessSimulator.Tests.Pieces
{
    [TestFixture]
    public class PawnTests
    {
        private Mock<IGameBoard> gameBoard;

        [SetUp]
        public void SetUp()
        {
            gameBoard = new Mock<IGameBoard>(MockBehavior.Strict);
        }
    }
}

using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChessSimulator.Pieces.Tests
{
    [TestFixture]
    public class KingTests
    {
        private Mock<IGameBoard> gameBoard;

        [SetUp]
        public void SetUp()
        {
            gameBoard = new Mock<IGameBoard>(MockBehavior.Strict);
        }

        [Test]
        public void Get_Moves_AllMovesPossible()
        {
            King king = new King(Colour.White);
            var boardStateInfos = new List<BoardStateInfo>
            {
                new BoardStateInfo
                {
                    Position = new Position(0, 0)
                },
                new BoardStateInfo
                {
                    Position = new Position(0, 1)
                },
                new BoardStateInfo
                {
                    Position = new Position(0, 2)
                },
                new BoardStateInfo
                {
                    Position = new Position(1, 0)
                },
                new BoardStateInfo
                {
                    Position = new Position(1, 2)
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 0)
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 1)
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 2)
                }
            };

            gameBoard.Setup(x => x.GetBoardStatesAround(It.Is<Position>(x => x.X == 1 && x.Y == 1))).Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, new Position(1, 1));
        }
    }
}

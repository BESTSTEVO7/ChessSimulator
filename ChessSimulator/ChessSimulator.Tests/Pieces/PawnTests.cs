using ChessSimulator.Pieces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

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

        //| | | |
        //| |P| | 
        [Test]
        public void GetMoves_AllMovesPossible()
        {
            Pawn pawn = new Pawn(Colour.White, Direction.Forward);
            Position pawnPosition = new Position(1, 1);

            var aheadBoardStateInfo = new BoardStateInfo
            {
                Position = new Position(0, 1)
            };

            var diagonalBoardStateInfos = new List<BoardStateInfo>
            {
                new BoardStateInfo
                {
                    Position = new Position(0, 0)
                },
                new BoardStateInfo
                {
                    Position = new Position(0, 2)
                }
            };

            var expectedMoves = new Position[]
            {
                new Position(0,1)
            };

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.Is<Position>(x => x.X == aheadBoardStateInfo.Position.X && x.Y == aheadBoardStateInfo.Position.Y)))
                .Returns(aheadBoardStateInfo);

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(diagonalBoardStateInfos);

            var result = pawn.GetMoves(gameBoard.Object, pawnPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }
    }
}

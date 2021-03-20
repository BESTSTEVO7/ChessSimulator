using ChessSimulator.Pieces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChessSimulator.Tests.Pieces
{
    [TestFixture]
    public class KnightTests
    {
        private Mock<IGameBoard> gameBoard;

        [SetUp]
        public void SetUp()
        {
            gameBoard = new Mock<IGameBoard>(MockBehavior.Strict);
        }

        //| | | | | |
        //| | | | | |
        //| | |K| | |
        //| | | | | |
        //| | | | | |
        [Test]
        public void GetMoves_NoOtherPieces_AllMovesPossible()
        {
            Knight rook = new Knight(Colour.White);
            Position knightPosition = new Position(2, 2);

            gameBoard.Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(3, 0) } ,
                        new BoardStateInfo { Position = new Position(4, 1) } ,
                        new BoardStateInfo { Position = new Position(4, 3) } ,
                        new BoardStateInfo { Position = new Position(3, 4) } ,
                        new BoardStateInfo { Position = new Position(1, 4) } ,
                        new BoardStateInfo { Position = new Position(0, 3) } ,
                        new BoardStateInfo { Position = new Position(0, 1) } ,
                        new BoardStateInfo { Position = new Position(1, 0) } ,
                    });

            var expectedMoves = new Position[]
            {
                new Position(3, 0),
                new Position(4, 1),
                new Position(4, 3),
                new Position(3, 4),
                new Position(1, 4),
                new Position(0, 3),
                new Position(0, 1),
                new Position(1, 0),
            };

            var result = rook.GetMoves(gameBoard.Object, knightPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //| |B| |B| |
        //|B| | | |B|
        //| | |K| | |
        //|B| | | |B|
        //| |B| |B| |
        [Test]
        public void GetMoves_OnlyEnemyPieces_AllMovesPossible()
        {
            Knight rook = new Knight(Colour.White);
            Position knightPosition = new Position(2, 2);

            gameBoard.Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(3, 0), State = Colour.Black } ,
                        new BoardStateInfo { Position = new Position(4, 1), State = Colour.Black } ,
                        new BoardStateInfo { Position = new Position(4, 3), State = Colour.Black } ,
                        new BoardStateInfo { Position = new Position(3, 4), State = Colour.Black } ,
                        new BoardStateInfo { Position = new Position(1, 4), State = Colour.Black } ,
                        new BoardStateInfo { Position = new Position(0, 3), State = Colour.Black } ,
                        new BoardStateInfo { Position = new Position(0, 1), State = Colour.Black } ,
                        new BoardStateInfo { Position = new Position(1, 0), State = Colour.Black } ,
                    });

            var expectedMoves = new Position[]
            {
                new Position(3, 0),
                new Position(4, 1),
                new Position(4, 3),
                new Position(3, 4),
                new Position(1, 4),
                new Position(0, 3),
                new Position(0, 1),
                new Position(1, 0),
            };

            var result = rook.GetMoves(gameBoard.Object, knightPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //| |W| |W| |
        //|W| | | |W|
        //| | |K| | |
        //|W| | | |W|
        //| |W| |W| |
        [Test]
        public void GetMoves_OnlyAlliesPieces_NoMovePossible()
        {
            Knight rook = new Knight(Colour.White);
            Position knightPosition = new Position(2, 2);

            gameBoard.Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(3, 0), State = Colour.White } ,
                        new BoardStateInfo { Position = new Position(4, 1), State = Colour.White } ,
                        new BoardStateInfo { Position = new Position(4, 3), State = Colour.White } ,
                        new BoardStateInfo { Position = new Position(3, 4), State = Colour.White } ,
                        new BoardStateInfo { Position = new Position(1, 4), State = Colour.White } ,
                        new BoardStateInfo { Position = new Position(0, 3), State = Colour.White } ,
                        new BoardStateInfo { Position = new Position(0, 1), State = Colour.White } ,
                        new BoardStateInfo { Position = new Position(1, 0), State = Colour.White } ,
                    });

            var expectedMoves = new Position[] { };

            var result = rook.GetMoves(gameBoard.Object, knightPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }
    }
}

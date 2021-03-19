using ChessSimulator.Pieces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChessSimulator.Tests.Pieces
{
    [TestFixture]
    public class RookTests
    {
        private Mock<IGameBoard> gameBoard;

        [SetUp]
        public void SetUp()
        {
            gameBoard = new Mock<IGameBoard>(MockBehavior.Strict);
        }

        //| | | | | |
        //| | | | | |
        //| | |R| | |
        //| | | | | |
        //| | | | | |
        [Test]
        public void GetMoves_NoOtherPieces_AllMovesPossible()
        {
            Rook rook = new Rook(Colour.White);
            Position rookPosition = new Position(2, 2);

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.North), It.Is<Position>(x => x == rookPosition)))
                .Returns(
                    new List<BoardStateInfo> 
                    { 
                        new BoardStateInfo { Position = new Position(0, 2) } ,
                        new BoardStateInfo { Position = new Position(1, 2) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.East), It.Is<Position>(x => x == rookPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(3, 2) } ,
                        new BoardStateInfo { Position = new Position(4, 2) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.South), It.Is<Position>(x => x == rookPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(2, 3) } ,
                        new BoardStateInfo { Position = new Position(2, 4) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.West), It.Is<Position>(x => x == rookPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(1, 2) } ,
                        new BoardStateInfo { Position = new Position(0, 2) } ,
                    });

            var expectedMoves = new Position[]
            {
                new Position(0,2),
                new Position(1,2),
                new Position(3,2),
                new Position(4,2),
                new Position(2,3),
                new Position(2,4),
                new Position(1,2),
                new Position(0,2),
            };

            var result = rook.GetMoves(gameBoard.Object, rookPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //| | | | | |
        //| | |W| | |
        //| |W|R|W| |
        //| | |W| | |
        //| | | | | |
        [Test]
        public void GetMoves_SurroundedWithAllies_NoMovePossible()
        {
            Rook rook = new Rook(Colour.White);
            Position rookPosition = new Position(2, 2);
        }

        //| | | | | |
        //| | |B| | |
        //| |B|R|B| |
        //| | |B| | |
        //| | | | | |
        [Test]
        public void GetMoves_SurroundedWithEnemies_OneStepInEveryDirectionPossible()
        {
            Rook rook = new Rook(Colour.White);
            Position rookPosition = new Position(2, 2);
        }

        //| | |W| | |
        //| | | | | |
        //| | |R| | |
        //| | | | | |
        //| | | | | |
        [Test]
        public void GetMoves_OneAllyFarFront_ManyMovesPossible()
        {
            Rook rook = new Rook(Colour.White);
            Position rookPosition = new Position(2, 2);
        }

        //| | | | | |
        //| | | | | |
        //|W| |R| | |
        //| | | | | |
        //| | | | | |
        [Test]
        public void GetMoves_OneAllyFarLeft_ManyMovesPossible()
        {
            Rook rook = new Rook(Colour.White);
            Position rookPosition = new Position(2, 2);
        }

        //| | | | | |
        //| | | | | |
        //| | |R| |W|
        //| | | | | |
        //| | | | | |
        [Test]
        public void GetMoves_OneAllyFarRight_ManyMovesPossible()
        {
            Rook rook = new Rook(Colour.White);
            Position rookPosition = new Position(2, 2);
        }

        //| | | | | |
        //| | | | | |
        //| | |R| | |
        //| | | | | |
        //| | |W| | |
        [Test]
        public void GetMoves_OneAllyFarBehind_ManyMovesPossible()
        {
            Rook rook = new Rook(Colour.White);
            Position rookPosition = new Position(2, 2);
        }
    }
}

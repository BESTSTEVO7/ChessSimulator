using ChessSimulator.Enums;
using ChessSimulator.Gameboards;
using ChessSimulator.Pieces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChessSimulator.Tests.Pieces
{
    [TestFixture]
    public class BishopTests
    {
        private Mock<IGameBoard> gameBoard;

        [SetUp]
        public void SetUp()
        {
            gameBoard = new Mock<IGameBoard>(MockBehavior.Strict);
        }

        // P -> Bishop
        // W -> Ally
        // B -> Enemy

        //| | | | | |
        //| | | | | |
        //| | |P| | |
        //| | | | | |
        //| | | | | |
        [Test]
        public void GetMoves_NoOtherPieces_AllMovesPossible()
        {
            Bishop bishop = new Bishop(Colour.White);
            Position bishopPosition = new Position(2, 2);

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.NorthEast), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(3, 1) } ,
                        new BoardStateInfo { Position = new Position(4, 0) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.NorthWest), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(1, 1) } ,
                        new BoardStateInfo { Position = new Position(0, 0) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.SouthEast), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(3, 3) } ,
                        new BoardStateInfo { Position = new Position(4, 4) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.SouthWest), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(1, 3) } ,
                        new BoardStateInfo { Position = new Position(0, 4) } ,
                    });

            var expectedMoves = new Position[]
            {
                new Position(0, 0),
                new Position(1, 1),
                new Position(3, 3),
                new Position(4, 4),
                new Position(0, 4),
                new Position(1, 3),
                new Position(3, 1),
                new Position(4, 0),
            };

            var result = bishop.GetMoves(gameBoard.Object, bishopPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //| | | | | |
        //| |W| |W| |
        //| | |P| | |
        //| |W| |W| |
        //| | | | | |
        [Test]
        public void GetMoves_SurroundedWithAllies_NoMovePossible()
        {
            Bishop bishop = new Bishop(Colour.White);
            Position bishopPosition = new Position(2, 2);

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.NorthEast), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(3, 1), State = Colour.White } ,
                        new BoardStateInfo { Position = new Position(4, 0) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.NorthWest), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(1, 1), State = Colour.White } ,
                        new BoardStateInfo { Position = new Position(0, 0) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.SouthEast), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(3, 3), State = Colour.White } ,
                        new BoardStateInfo { Position = new Position(4, 4) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.SouthWest), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(1, 3), State = Colour.White } ,
                        new BoardStateInfo { Position = new Position(0, 4) } ,
                    });

            var expectedMoves = new Position[] {};

            var result = bishop.GetMoves(gameBoard.Object, bishopPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //| | | | | |
        //| |B| |B| |
        //| | |P| | |
        //| |B| |B| |
        //| | | | | |
        [Test]
        public void GetMoves_SurroundedWithEnemies_OneStepInEveryDirectionPossible()
        {
            Bishop bishop = new Bishop(Colour.White);
            Position bishopPosition = new Position(2, 2);

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.NorthEast), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(3, 1), State = Colour.Black } ,
                        new BoardStateInfo { Position = new Position(4, 0) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.NorthWest), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(1, 1), State = Colour.Black } ,
                        new BoardStateInfo { Position = new Position(0, 0) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.SouthEast), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(3, 3), State = Colour.Black } ,
                        new BoardStateInfo { Position = new Position(4, 4) } ,
                    });

            gameBoard.Setup(x => x.GetBoardStateInfoInDirection(It.Is<Direction>(x => x == Direction.SouthWest), It.Is<Position>(x => x == bishopPosition)))
                .Returns(
                    new List<BoardStateInfo>
                    {
                        new BoardStateInfo { Position = new Position(1, 3), State = Colour.Black } ,
                        new BoardStateInfo { Position = new Position(0, 4) } ,
                    });

            var expectedMoves = new Position[]
            {
                new Position(1, 1),
                new Position(3, 3),
                new Position(3, 1),
                new Position(1, 3)
            };

            var result = bishop.GetMoves(gameBoard.Object, bishopPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }
    }
}

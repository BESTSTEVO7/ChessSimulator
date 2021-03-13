using ChessSimulator.Pieces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChessSimulator.Tests.Pieces
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

        //| | | |
        //| |K| |
        //| | | | 
        [Test]
        public void GetMoves_AllMovesPossible()
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

            var expectedMoves = new Position[]
            {
                new Position(0,0),
                new Position(0,1),
                new Position(0,2),
                new Position(1,0),
                new Position(1,2),
                new Position(2,0),
                new Position(2,1),
                new Position(2,2),
            };

            gameBoard
                .Setup(x => x.GetBoardStateInfo())
                .Returns(boardStateInfos);

            gameBoard.Setup(x => x.GetBoardStatesAround(It.Is<Position>(x => x.X == 1 && x.Y == 1))).Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, new Position(1, 1));
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //|W|W|W|
        //|W|K|W|
        //|W|W|W| 
        [Test]
        public void GetMoves_SurroundedWithFriends_NoMovePossible()
        {
            King king = new King(Colour.White);

            var boardStateInfos = new List<BoardStateInfo>
            {
                new BoardStateInfo
                {
                    Position = new Position(0, 0),
                    State = Colour.White
                },
                new BoardStateInfo
                {
                    Position = new Position(0, 1),
                    State = Colour.White
                },
                new BoardStateInfo
                {
                    Position = new Position(0, 2),
                    State = Colour.White
                },
                new BoardStateInfo
                {
                    Position = new Position(1, 0),
                    State = Colour.White
                },
                new BoardStateInfo
                {
                    Position = new Position(1, 2),
                    State = Colour.White
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 0),
                    State = Colour.White
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 1),
                    State = Colour.White
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 2),
                    State = Colour.White
                }
            };

            var expectedMoves = new Position[] { };

            gameBoard
                .Setup(x => x.GetBoardStateInfo())
                .Returns(boardStateInfos);

            gameBoard.Setup(x => x.GetBoardStatesAround(It.Is<Position>(x => x.X == 1 && x.Y == 1))).Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, new Position(1, 1));
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //|B|B|B|
        //|B|K|B|
        //|B|B|B| 
        [Test]
        public void GetMoves_SurroundedWithEnemies_AllMovesPossible()
        {
            King king = new King(Colour.White);

            var boardStateInfos = new List<BoardStateInfo>
            {
                new BoardStateInfo
                {
                    Position = new Position(0, 0),
                    State = Colour.Black
                },
                new BoardStateInfo
                {
                    Position = new Position(0, 1),
                    State = Colour.Black
                },
                new BoardStateInfo
                {
                    Position = new Position(0, 2),
                    State = Colour.Black
                },
                new BoardStateInfo
                {
                    Position = new Position(1, 0),
                    State = Colour.Black
                },
                new BoardStateInfo
                {
                    Position = new Position(1, 2),
                    State = Colour.Black
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 0),
                    State = Colour.Black
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 1),
                    State = Colour.Black
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 2),
                    State = Colour.Black
                }
            };

            var expectedMoves = new Position[]
            {
                new Position(0,0),
                new Position(0,1),
                new Position(0,2),
                new Position(1,0),
                new Position(1,2),
                new Position(2,0),
                new Position(2,1),
                new Position(2,2),
            };

            gameBoard
                .Setup(x => x.GetBoardStateInfo())
                .Returns(boardStateInfos);

            gameBoard.Setup(x => x.GetBoardStatesAround(It.Is<Position>(x => x.X == 1 && x.Y == 1))).Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, new Position(1, 1));
            result.Should().BeEquivalentTo(expectedMoves);
        }
    }
}

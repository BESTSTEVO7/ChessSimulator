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
        public void GetMoves_NoFront_ForwardPossible()
        {
            Pawn pawn = new Pawn(Colour.White, Direction.North);
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

        //| |B| |
        //| |P| | 
        [Test]
        public void GetMoves_EnemyInFront_NoMovePossible()
        {
            Pawn pawn = new Pawn(Colour.White, Direction.North);
            Position pawnPosition = new Position(1, 1);

            var aheadBoardStateInfo = new BoardStateInfo
            {
                Position = new Position(0, 1),
                State = Colour.Black
            };

            var diagonalBoardStateInfos = new List<BoardStateInfo>{};

            var expectedMoves = new Position[] { };

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.Is<Position>(x => x.X == aheadBoardStateInfo.Position.X && x.Y == aheadBoardStateInfo.Position.Y)))
                .Returns(aheadBoardStateInfo);

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(diagonalBoardStateInfos);

            var result = pawn.GetMoves(gameBoard.Object, pawnPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //| |W| |
        //| |P| | 
        [Test]
        public void GetMoves_AllyInFront_NoMovePossible()
        {
            Pawn pawn = new Pawn(Colour.White, Direction.North);
            Position pawnPosition = new Position(1, 1);

            var aheadBoardStateInfo = new BoardStateInfo
            {
                Position = new Position(0, 1),
                State = Colour.White
            };

            var diagonalBoardStateInfos = new List<BoardStateInfo>{};

            var expectedMoves = new Position[] { };

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.Is<Position>(x => x.X == aheadBoardStateInfo.Position.X && x.Y == aheadBoardStateInfo.Position.Y)))
                .Returns(aheadBoardStateInfo);

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(diagonalBoardStateInfos);

            var result = pawn.GetMoves(gameBoard.Object, pawnPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //|B|W|B|
        //| |P| | 
        [Test]
        public void GetMoves_AllyInFrontTwoEnemiesDiagonal_DiagonalsMovePossible()
        {
            Pawn pawn = new Pawn(Colour.White, Direction.North);
            Position pawnPosition = new Position(1, 1);

            var aheadBoardStateInfo = new BoardStateInfo
            {
                Position = new Position(0, 1),
                State = Colour.White
            };

            var diagonalBoardStateInfos = new List<BoardStateInfo>
            {
                new BoardStateInfo
                {
                    Position = new Position(0, 0),
                    State = Colour.Black
                },
                new BoardStateInfo
                {
                    Position = new Position(0, 2),
                    State = Colour.Black
                }
            };

            var expectedMoves = new Position[]
            {
                new Position(0,0),
                new Position(0,2)
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

        //|B|B|B|
        //| |P| | 
        [Test]
        public void GetMoves_EnemiesInFront_DiagonalsMovePossible()
        {
            Pawn pawn = new Pawn(Colour.White, Direction.North);
            Position pawnPosition = new Position(1, 1);

            var aheadBoardStateInfo = new BoardStateInfo
            {
                Position = new Position(0, 1),
                State = Colour.Black
            };

            var diagonalBoardStateInfos = new List<BoardStateInfo>
            {
                new BoardStateInfo
                {
                    Position = new Position(0, 0),
                    State = Colour.Black
                },
                new BoardStateInfo
                {
                    Position = new Position(0, 2),
                    State = Colour.Black
                }
            };

            var expectedMoves = new Position[]
            {
                new Position(0,0),
                new Position(0,2)
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

        //|B| | |
        //| |P| | 
        [Test]
        public void GetMoves_EnemyDiagonal_DiagonalMovePossible()
        {
            Pawn pawn = new Pawn(Colour.White, Direction.North);
            Position pawnPosition = new Position(1, 1);

            var aheadBoardStateInfo = new BoardStateInfo
            {
                Position = new Position(0, 1)
            };

            var diagonalBoardStateInfos = new List<BoardStateInfo>
            {
                new BoardStateInfo
                {
                    Position = new Position(0, 0),
                    State = Colour.Black
                }
            };

            var expectedMoves = new Position[]
            {
                new Position(0,0),
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

        //| |W|B|
        //| |P| | 
        [Test]
        public void GetMoves_AllyInFrontEnemyDiagonal_DiagonalMovePossible()
        {
            Pawn pawn = new Pawn(Colour.White, Direction.North);
            Position pawnPosition = new Position(1, 1);

            var aheadBoardStateInfo = new BoardStateInfo
            {
                Position = new Position(0, 1),
                State = Colour.White
            };

            var diagonalBoardStateInfos = new List<BoardStateInfo>
            {
                new BoardStateInfo
                {
                    Position = new Position(0, 2),
                    State = Colour.Black
                }
            };

            var expectedMoves = new Position[]
            {
                new Position(0,2)
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

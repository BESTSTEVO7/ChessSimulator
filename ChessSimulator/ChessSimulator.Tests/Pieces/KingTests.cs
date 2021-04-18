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
            Position kingPosition = new Position(1, 1);

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
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, kingPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //|W|W|W|
        //|W|K|W|
        //|W|W|W| 
        [Test]
        public void GetMoves_SurroundedWithFriends_NoMovePossible()
        {
            King king = new King(Colour.White);
            Position kingPosition = new Position(1, 1);

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
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, kingPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //|B|B|B|
        //|B|K|B|
        //|B|B|B| 
        [Test]
        public void GetMoves_SurroundedWithEnemies_AllMovesPossible()
        {
            King king = new King(Colour.White);
            Position kingPosition = new Position(1, 1);

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
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, kingPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //| |K| |
        //| | | | 
        [Test]
        public void GetMoves_ForwardsWall_AllBackwardMovesPossible()
        {
            King king = new King(Colour.White);
            Position kingPosition = new Position(0, 1);

            var boardStateInfos = new List<BoardStateInfo>
            {
                new BoardStateInfo
                {
                    Position = new Position(0, 0)
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
                    Position = new Position(1, 1)
                },
                new BoardStateInfo
                {
                    Position = new Position(1, 2)
                }
            };

            var expectedMoves = new Position[]
            {
                new Position(0,0),
                new Position(0,2),
                new Position(1,0),
                new Position(1,1),
                new Position(1,2)
            };

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, kingPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //| | | |
        //| |K| | 
        [Test]
        public void GetMoves_BackwardsWall_AllForwardMovesPossible()
        {
            King king = new King(Colour.White);
            Position kingPosition = new Position(1, 1);

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
                }
            };

            var expectedMoves = new Position[]
            {
                new Position(0, 0),
                new Position(0, 1),
                new Position(0, 2),
                new Position(1, 0),
                new Position(1, 2)
            };

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, kingPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //| | |
        //|K| |
        //| | |
        [Test]
        public void GetMoves_LeftWall_AllRightMovesPossible()
        {
            King king = new King(Colour.White);
            Position kingPosition = new Position(1, 0);

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
                    Position = new Position(1, 1)
                },
                 new BoardStateInfo
                {
                    Position = new Position(2, 0)
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 1)
                }
            };

            var expectedMoves = new Position[]
            {
                new Position(0, 0),
                new Position(0, 1),
                new Position(1, 1),
                new Position(2, 0),
                new Position(2, 1)
            };

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, kingPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //| | |
        //| |K|
        //| | |
        [Test]
        public void GetMoves_RightWall_AllLeftMovesPossible()
        {
            King king = new King(Colour.White);
            Position kingPosition = new Position(1, 1);

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
                    Position = new Position(1, 0)
                },
                 new BoardStateInfo
                {
                    Position = new Position(2, 0)
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 1)
                }
            };

            var expectedMoves = new Position[]
            {
                new Position(0, 0),
                new Position(0, 1),
                new Position(1, 0),
                new Position(2, 0),
                new Position(2, 1)
            };

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, kingPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //|B|B|
        //|B|K|
        //|B|B|
        [Test]
        public void GetMoves_RightWallAndAllEnemies_AllLeftMovesPossible()
        {
            King king = new King(Colour.White);
            Position kingPosition = new Position(1, 1);

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
                    Position = new Position(1, 0),
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
                }
            };

            var expectedMoves = new Position[]
            {
                new Position(0, 0),
                new Position(0, 1),
                new Position(1, 0),
                new Position(2, 0),
                new Position(2, 1)
            };

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, kingPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //|W|W|
        //|W|K|
        //|W|W|
        [Test]
        public void GetMoves_RightWallAndAllAllies_NoLeftMovesPossible()
        {
            King king = new King(Colour.White);
            Position kingPosition = new Position(1, 1);

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
                    Position = new Position(1, 0),
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
                }
            };

            var expectedMoves = new Position[] { };

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, kingPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }

        //|W| |B
        //| |K|W
        //|W|B|
        [Test]
        public void GetMoves_MixedStates_SomeMovesPossible()
        {
            King king = new King(Colour.White);
            Position kingPosition = new Position(1, 1);

            var boardStateInfos = new List<BoardStateInfo>
            {
                new BoardStateInfo
                {
                    Position = new Position(0, 0),
                    State = Colour.White
                },
                new BoardStateInfo
                {
                    Position = new Position(0, 1)
                },
                new BoardStateInfo
                {
                    Position = new Position(0, 2),
                    State = Colour.Black
                },
                new BoardStateInfo
                {
                    Position = new Position(1, 0)
                },
                new BoardStateInfo
                {
                    Position = new Position(1, 1),
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
                    State = Colour.Black
                },
                new BoardStateInfo
                {
                    Position = new Position(2, 2)
                }
            };

            var expectedMoves = new Position[]
             {
                new Position(0, 1),
                new Position(0, 2),
                new Position(1, 0),
                new Position(2, 1),
                new Position(2, 2)
             };

            gameBoard
                .Setup(x => x.GetBoardStateInfo(It.IsAny<Position[]>()))
                .Returns(boardStateInfos);

            var result = king.GetMoves(gameBoard.Object, kingPosition);
            result.Should().BeEquivalentTo(expectedMoves);
        }
    }
}

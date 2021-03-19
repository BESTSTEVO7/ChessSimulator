using ChessSimulator.Pieces;
using Moq;
using NUnit.Framework;

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

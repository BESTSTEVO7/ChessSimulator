using System.Drawing;

namespace ChessSimulator.Pieces
{
    public interface IPiece
    {
        public string Name { get; }

        public Point Position { get; }

        public Colour Colour { get; }

        public Point[] GetMoves(IGameBoard gameBoard);
    }
}

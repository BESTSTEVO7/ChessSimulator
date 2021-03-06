using System.Drawing;

namespace ChessSimulator.Pieces
{
    public interface IPiece
    {
        public string Name { get; }

        public Position Position { get; }

        public Colour Colour { get; }

        public Position[] GetMoves(IGameBoard gameBoard);
    }
}

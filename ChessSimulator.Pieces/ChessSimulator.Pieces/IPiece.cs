using System.Drawing;

namespace ChessSimulator.Pieces
{
    public interface IPiece
    {
        public string Name { get; set; }

        public Point Position { get; }

        public Colors Color { get; }

        public Point[] GetMoves();
    }
}

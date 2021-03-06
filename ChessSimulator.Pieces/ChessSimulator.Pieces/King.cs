using System.Collections.Generic;
using System.Drawing;

namespace ChessSimulator.Pieces
{
    public class King : IPiece
    {
        public string Name { get => PieceNames.King; }

        public Point Position { get; set; }

        public Colour Colour { get; }

        public King(Point startPosition, Colour colour)
        {
            Position = startPosition;
            Colour = colour;
        }

        public Point[] GetMoves(IGameBoard gameBoard)
        {
            var result = new List<Point>();
            
            return result.ToArray();
        }
    }
}

using System;

namespace ChessSimulator.Pieces
{
    public class Queen : IPiece
    {
        public string Name { get => PieceNames.Queen; }

        public Colour Colour { get; }

        public Queen(Colour colour)
        {
            Colour = colour;
        }

        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            throw new NotImplementedException();
        }
    }
}

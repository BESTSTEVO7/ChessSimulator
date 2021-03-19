using System;

namespace ChessSimulator.Pieces
{
    public class Rook : IPiece
    {
        public string Name { get => PieceNames.Rook; }

        public Colour Colour { get; }

        public Rook(Colour colour)
        {
            Colour = colour;
        }

        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            throw new NotImplementedException();
        }
    }
}

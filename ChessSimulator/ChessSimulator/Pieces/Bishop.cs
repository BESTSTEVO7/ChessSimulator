using System;

namespace ChessSimulator.Pieces
{
    class Bishop : IPiece
    {
        public string Name { get => PieceNames.Bishop; }

        public Colour Colour { get; }

        public Bishop(Colour colour)
        {
            Colour = colour;
        }

        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            throw new NotImplementedException();
        }
    }
}

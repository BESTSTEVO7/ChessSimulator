using System;

namespace ChessSimulator.Pieces
{
    class Knight : IPiece
    {
        public string Name { get => PieceNames.Knight; }

        public Colour Colour { get; }

        public Knight(Colour colour)
        {
            Colour = colour;
        }

        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            throw new NotImplementedException();
        }
    }
}

namespace ChessSimulator.Pieces
{
    class Pawn : IPiece
    {
        public string Name { get => PieceNames.Pawn; }

        public Colour Colour { get; }

        public Pawn(Colour colour)
        {
            Colour = colour;
        }

        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            throw new System.NotImplementedException();
        }
    }
}

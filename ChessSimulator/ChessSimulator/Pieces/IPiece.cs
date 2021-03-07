namespace ChessSimulator.Pieces
{
    public interface IPiece
    {
        public string Name { get; }

        public Colour Colour { get; }

        // Not sure this logic should be on the logic
        public Position[] GetMoves(IGameBoard gameBoard, Position position);
    }
}

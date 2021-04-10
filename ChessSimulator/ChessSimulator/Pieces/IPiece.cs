namespace ChessSimulator.Pieces
{
    public interface IPiece
    {
        public string Name { get; }

        public Colour Colour { get; }

        public Position[] GetMoves(IGameBoard gameBoard, Position position);
    }
}

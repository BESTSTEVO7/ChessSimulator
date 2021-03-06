using System.Linq;

namespace ChessSimulator.Pieces
{
    public class King : IPiece
    {
        public string Name { get => PieceNames.King; }

        public Position Position { get; set; }

        public Colour Colour { get; }

        public King(Position startPosition, Colour colour)
        {
            Position = startPosition;
            Colour = colour;
        }

        public Position[] GetMoves(IGameBoard gameBoard)
        {
            var boardStateInfos = gameBoard.GetBoardStatesAround(Position);
            return boardStateInfos.Where(x => !x.State.HasValue || x.State != Colour).Select(x => x.Position).ToArray();
        }
    }
}

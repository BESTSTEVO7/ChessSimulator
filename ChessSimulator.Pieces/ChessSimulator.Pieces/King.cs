using System.Linq;

namespace ChessSimulator.Pieces
{
    public class King : IPiece
    {
        public string Name { get => PieceNames.King; }

        public Colour Colour { get; }

        public King(Colour colour)
        {
            Colour = colour;
        }

        public Position[] GetMoves(IGameBoard gameBoard, Position position)
        {
            var boardStateInfos = gameBoard.GetBoardStatesAround(position);
            return boardStateInfos.Where(x => !x.State.HasValue || x.State != Colour).Select(x => x.Position).ToArray();
        }
    }
}

using System.Drawing;

namespace ChessSimulator.Pieces
{
    public interface IGameBoard
    {
        public BoardState GetBoardState(Point point);
    }
}

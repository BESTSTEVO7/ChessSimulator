using System.Collections.Generic;
using System.Drawing;

namespace ChessSimulator.Pieces
{
    public interface IGameBoard
    {
        public BoardStateInfo GetBoardState(Point point);

        public IEnumerable<BoardStateInfo> GetBoardStatesAround(Point point);
    }
}

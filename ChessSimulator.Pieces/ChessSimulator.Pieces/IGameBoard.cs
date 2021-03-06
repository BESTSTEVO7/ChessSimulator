using System.Collections.Generic;

namespace ChessSimulator.Pieces
{
    public interface IGameBoard
    {
        public BoardStateInfo GetBoardState(Position point);

        public IEnumerable<BoardStateInfo> GetBoardStatesAround(Position point);
    }
}

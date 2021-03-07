using System.Collections.Generic;

namespace ChessSimulator.Pieces
{
    public interface IGameBoard
    {
        public BoardStateInfo GetBoardStateInfo(Position point);

        public void AddPiece(IPiece piece, Position position);

        public void RemovePiece(Position position);

        public IEnumerable<BoardStateInfo> GetBoardStatesAround(Position point);
    }
}

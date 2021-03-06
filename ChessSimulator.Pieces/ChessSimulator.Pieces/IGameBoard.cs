using System.Collections.Generic;

namespace ChessSimulator.Pieces
{
    public interface IGameBoard
    {
        public BoardStateInfo GetBoardState(Position point);

        public void AddPiece(IPiece piece, Position position);

        public IPiece RemovePiece(Position position);

        public IEnumerable<BoardStateInfo> GetBoardStatesAround(Position point);
    }
}

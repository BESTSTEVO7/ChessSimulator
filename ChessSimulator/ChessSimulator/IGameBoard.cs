using ChessSimulator.Pieces;
using System.Collections.Generic;

namespace ChessSimulator
{
    public interface IGameBoard
    {
        public BoardStateInfo GetBoardStateInfo(Position point);

        public BoardStateInfo GetBoardStateInfo(int x, int y);

        public IEnumerable<BoardStateInfo> GetBoardStateInfo(params Position[] positions);

        public void AddPiece(IPiece piece, Position position);

        public void RemovePiece(Position position);
    }
}

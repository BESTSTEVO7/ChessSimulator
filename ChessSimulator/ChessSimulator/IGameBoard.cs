using ChessSimulator.Enums;
using System.Collections.Generic;

namespace ChessSimulator
{
    public interface IGameBoard
    {
        public MoveResult Move(Position from, Position to);

        public IEnumerable<Position> GetMoves(Position position);

        public IEnumerable<BoardStateInfo> GetBoard();

        public BoardStateInfo? GetBoardStateInfo(Position position);

        public IEnumerable<BoardStateInfo> GetBoardStateInfo(params Position[] positions);

        public IEnumerable<BoardStateInfo> GetBoardStateInfoInDirection(Direction direction, Position position);
    }
}

using ChessSimulator.Exceptions;
using ChessSimulator.Extensions;
using ChessSimulator.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace ChessSimulator
{
    public class GameBoard : IGameBoard
    {
        private readonly IPiece?[,] board;

        public bool Move(Position from, Position to)
        {
            if (!IsOnBoard(from))
            {
                throw new NotOnBoardException($"Position with x:{from.X} and y:{from.Y} is not a field on the board");
            }

            if (!IsOnBoard(to))
            {
                throw new NotOnBoardException($"Position with x:{to.X} and y:{to.Y} is not a field on the board");
            }

            var possibleMoves = this[from]?.GetMoves(this, from);
            if (possibleMoves is not null && possibleMoves.Contains(to)) 
            {
                var piece = this[from];
                this[from] = null;
                this[to] = piece;
                if (piece is IMoveInfo pieceMove)
                {
                    pieceMove.Move();
                } 

                return true;
            }

            return false;

            // TODO
        }

        public IEnumerable<Position> GetMoves(Position position)
        {
            if (!IsOnBoard(position)) 
            {
                throw new NotOnBoardException($"Position with x:{position.X} and y:{position.Y} is not a field on the board");
            }

            var piece = this[position];

            return 
                piece is not null 
                    ? piece.GetMoves(this, position) 
                    : new List<Position>();
        }

        public IEnumerable<BoardStateInfo> GetBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Position currentPosition = new Position(i, j);
                    var boardStateInfo = GetBoardStateInfo(currentPosition);
                    if (boardStateInfo is not null) 
                    {
                        var piece = this[currentPosition];
                        if (piece is not null) 
                        {
                            boardStateInfo.Representation = piece.Name;
                            
                        }    yield return boardStateInfo;
                    }
                }
            }
        }

        public BoardStateInfo? GetBoardStateInfo(Position position)
        {
            if (!IsOnBoard(position))
            {
                return null;
            }

            return new BoardStateInfo { State = this[position]?.Colour, Position = position };
        }

        public IEnumerable<BoardStateInfo> GetBoardStateInfo(params Position[] positions)
        {
            foreach (var position in positions)
            {
                if (GetBoardStateInfo(position) is { } boardStateInfo)
                {
                    yield return boardStateInfo;
                }
            }
        }

        public IEnumerable<BoardStateInfo> GetBoardStateInfoInDirection(Direction direction, Position position)
        {
            position += DirectionDeltas.Get(direction);

            while (IsOnBoard(position))
            {
                if (GetBoardStateInfo(position) is { } boardStateInfo)
                {
                    yield return boardStateInfo;
                }

                position += DirectionDeltas.Get(direction);
            }
        }

        public static GameBoard GenerateStandardBoard()
        {
            return new GameBoard(DefaultGameBoardExtensions.GenerateNewBoard());
        }

        private GameBoard(IPiece?[,] board)
        {
            this.board = board;
        }

        private IPiece? this[Position position]
        {
            get { return board[position.X, position.Y]; }
            set { board[position.X, position.Y] = value; }
        }

        private bool IsOnBoard(Position position)
        {
            return
                -1 < position.X && position.X < board.GetLength(0) 
                    &&
                -1 < position.Y && position.Y < board.GetLength(1);
        }
    }
}
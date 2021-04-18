using ChessSimulator.Enums;
using ChessSimulator.Exceptions;
using ChessSimulator.Extensions;
using ChessSimulator.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessSimulator
{
    public class GameBoard : IGameBoard
    {
        private readonly IPiece?[,] board;

        public MoveResult Move(Position from, Position to)
        {
            ValidatePosition(from);
            ValidatePosition(to);

            var possibleMoves = this[from]?.GetMoves(this, from);
            if (possibleMoves is not null && possibleMoves.Contains(to)) 
            {
                var currentTo = this[to];

                var piece = this[from];
                this[from] = null;
                this[to] = piece;

                if (IsCheck(piece!.Colour)) 
                {
                    piece = this[to];
                    this[to] = currentTo;
                    this[from] = piece;

                    return MoveResult.SetMySelfToCheck;
                }

                // Did I set the enemy to check?
                if (IsCheck(piece.Colour.GetEnemy())) 
                {
                    return MoveResult.SetEnemyToCheck;
                }

                if (piece is IMoveInfo pieceMove)
                {
                    pieceMove.Move();
                }

                return MoveResult.Valid;
            }

            return MoveResult.Invalid;
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

        private Position this[IPiece piece] 
        {
            get { return GetPosition(piece); }
        }

        private Position GetPosition(IPiece piece)
        {
            int w = board.GetLength(0);
            int h = board.GetLength(1);

            var result = new Position(-1, -1);

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (board[x,y] is not null && board[x, y]!.Equals(piece))
                    {
                        result = new Position(x, y);
                    }
                }
            }

            return result;
        }

        private bool IsOnBoard(Position position)
        {
            return
                -1 < position.X && position.X < board.GetLength(0) 
                    &&
                -1 < position.Y && position.Y < board.GetLength(1);
        }

        private void ValidatePosition(Position position)
        {
            if (!IsOnBoard(position))
            {
                throw new NotOnBoardException($"Position with x:{position.X} and y:{position.Y} is not a field on the board");
            }
        }

        private bool IsCheck(Colour colour) 
        {
            var enemyColour = colour.GetEnemy();
            var enemies = board.Cast<IPiece>().Where(piece => piece?.Colour == enemyColour);
            var positions = enemies.SelectMany(piece => piece.GetMoves(this, this[piece])).Distinct().ToList();
            var king = board.Cast<IPiece>().Where(piece => piece is King && piece?.Colour == colour).First();
            var kingPosition = this[king];

            return (positions.Contains(kingPosition));
        }
    }
}
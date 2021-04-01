using ChessSimulator.Exceptions;
using ChessSimulator.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace ChessSimulator
{
    public class GameBoard : IGameBoard
    {
        private readonly IPiece?[,] board;

        private static readonly IReadOnlyDictionary<Direction, Position> directionDeltas =
            new Dictionary<Direction, Position>
            {
                // TODO
                [Direction.North] = new Position(0, -1),
                [Direction.East] = new Position(1, 0),
                [Direction.South] = new Position(0, 1),
                [Direction.West] = new Position(-1, 0),
                [Direction.NorthEast] = new Position(1, -1),
                [Direction.NorthWest] = new Position(-1, -1),
                [Direction.SouthEast] = new Position(1, 1),
                [Direction.SouthWest] = new Position(-1, 1),
            };

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
            position += directionDeltas[direction];

            while (IsOnBoard(position))
            {
                if (GetBoardStateInfo(position) is { } boardStateInfo)
                {
                    yield return boardStateInfo;
                }

                position += directionDeltas[direction];
            }
        }

        // TODO rethink this and check if Builder pattern would be more appropriate
        // something like builder.AddPiece(...).AddPiece(...).AddPiece(...).BuildBoard();
        public static GameBoard GenerateStandardBoard()
        {
            int rows = 8;
            int columns = 8;
            IPiece[,] newBoard = new IPiece[rows, columns];
            var gameBoard = new GameBoard(newBoard);

            gameBoard.AddPiece(new Rook(Colour.Black), new Position(0, 0));
            gameBoard.AddPiece(new Knight(Colour.Black), new Position(1, 0));
            gameBoard.AddPiece(new Bishop(Colour.Black), new Position(2, 0));
            gameBoard.AddPiece(new Queen(Colour.Black), new Position(3, 0));
            gameBoard.AddPiece(new King(Colour.Black), new Position(4, 0));
            gameBoard.AddPiece(new Bishop(Colour.Black), new Position(5, 0));
            gameBoard.AddPiece(new Knight(Colour.Black), new Position(6, 0));
            gameBoard.AddPiece(new Rook(Colour.Black), new Position(7, 0));

            gameBoard.AddPiece(new Pawn(Colour.Black, Direction.East), new Position(0, 1));
            gameBoard.AddPiece(new Pawn(Colour.Black, Direction.East), new Position(1, 1));
            gameBoard.AddPiece(new Pawn(Colour.Black, Direction.East), new Position(2, 1));
            gameBoard.AddPiece(new Pawn(Colour.Black, Direction.East), new Position(3, 1));
            gameBoard.AddPiece(new Pawn(Colour.Black, Direction.East), new Position(4, 1));
            gameBoard.AddPiece(new Pawn(Colour.Black, Direction.East), new Position(5, 1));
            gameBoard.AddPiece(new Pawn(Colour.Black, Direction.East), new Position(6, 1));
            gameBoard.AddPiece(new Pawn(Colour.Black, Direction.East), new Position(7, 1));

            gameBoard.AddPiece(new Rook(Colour.White), new Position(0, 7));
            gameBoard.AddPiece(new Knight(Colour.White), new Position(1, 7));
            gameBoard.AddPiece(new Bishop(Colour.White), new Position(2, 7));
            gameBoard.AddPiece(new Queen(Colour.White), new Position(3, 7));
            gameBoard.AddPiece(new King(Colour.White), new Position(4, 7));
            gameBoard.AddPiece(new Bishop(Colour.White), new Position(5, 7));
            gameBoard.AddPiece(new Knight(Colour.White), new Position(6, 7));
            gameBoard.AddPiece(new Rook(Colour.White), new Position(7, 7));

            gameBoard.AddPiece(new Pawn(Colour.White, Direction.North), new Position(0, 6));
            gameBoard.AddPiece(new Pawn(Colour.White, Direction.North), new Position(1, 6));
            gameBoard.AddPiece(new Pawn(Colour.White, Direction.North), new Position(2, 6));
            gameBoard.AddPiece(new Pawn(Colour.White, Direction.North), new Position(3, 6));
            gameBoard.AddPiece(new Pawn(Colour.White, Direction.North), new Position(4, 6));
            gameBoard.AddPiece(new Pawn(Colour.White, Direction.North), new Position(5, 6));
            gameBoard.AddPiece(new Pawn(Colour.White, Direction.North), new Position(6, 6));
            gameBoard.AddPiece(new Pawn(Colour.White, Direction.North), new Position(7, 6));

            return gameBoard;
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
                -1 < position.X && position.X < board.GetLength(0) &&
                -1 < position.Y && position.Y < board.GetLength(1);
        }

        private void AddPiece(IPiece piece, Position position)
        {
            this[position] = piece;
        }
    }
}
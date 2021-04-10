using System.Collections.Generic;

namespace ChessSimulator.Extensions
{
    internal static class DirectionDeltas
    {
        private static readonly IReadOnlyDictionary<Direction, Position> deltas =
            new Dictionary<Direction, Position>
            {
                [Direction.North] = new Position(0, -1),
                [Direction.East] = new Position(1, 0),
                [Direction.South] = new Position(0, 1),
                [Direction.West] = new Position(-1, 0),
                [Direction.NorthEast] = new Position(1, -1),
                [Direction.NorthWest] = new Position(-1, -1),
                [Direction.SouthEast] = new Position(1, 1),
                [Direction.SouthWest] = new Position(-1, 1),
            };

        internal static Position Get(Direction direction) 
        {
            return deltas[direction];
        }
    }
}

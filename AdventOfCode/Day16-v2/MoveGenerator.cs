using AdventOfCode.Shared;

namespace AdventOfCode.Day16_v2;

public class MoveGenerator
{
    private readonly LavaGrid _grid;

    public MoveGenerator(LavaGrid grid)
    {
        _grid = grid;
    }

    public IEnumerable<Move> NextMoves(Move current)
    {
        var currentValue = _grid[current.Coord].Value;
        var nextPossibleDirections = MoveMap(currentValue, current.Direction);
        
        var moves = new List<Move>();

        foreach (var direction in nextPossibleDirections)
        {
            var nextCord = current.Coord.NextCoord(direction);
            var nextMove = new Move(nextCord, direction);
            
            if (_grid.InBounds(nextMove.Coord) && !_grid.Visited(nextMove))
            {
                moves.Add(nextMove);
            }
        }

        return moves;

    }

    public Direction[] MoveMap(Value value, Direction direction)
    {
        switch (value)
        {
            case Value.Empty: // .
                return new[]{direction};
            case Value.DownSplitter: // |
                return direction switch
                {
                    Direction.Up => new[] { Direction.Up },
                    Direction.Down => new[] { Direction.Down },
                    Direction.Left => new[] { Direction.Up, Direction.Down, },
                    Direction.Right => new[] { Direction.Up, Direction.Down, },
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
                };
            case Value.RightSplitter: // -
            {
                return direction switch
                {
                    Direction.Up => new[] { Direction.Right, Direction.Left },
                    Direction.Down => new[] { Direction.Right, Direction.Left },
                    Direction.Left => new[] { Direction.Left },
                    Direction.Right => new[] { Direction.Right },
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
                };
            }
            case Value.RightMirror:  // /
                return direction switch
                {
                    Direction.Up => new[] { Direction.Right },
                    Direction.Down => new[] { Direction.Left },
                    Direction.Left => new[] { Direction.Down },
                    Direction.Right => new[] { Direction.Up },
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
                };
            case Value.LeftMirror: // \
                return direction switch
                {
                    Direction.Up => new[] { Direction.Left },
                    Direction.Down => new[] { Direction.Right },
                    Direction.Left => new[] { Direction.Up },
                    Direction.Right => new[] { Direction.Down },
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
                };
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }

        
        throw new Exception("I shouldnt be here");
    }
    
}
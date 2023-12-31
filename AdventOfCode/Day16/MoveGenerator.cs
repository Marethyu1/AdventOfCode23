using AdventOfCode.Shared;

namespace AdventOfCode.Day16;

public static class MoveGenerator
{

    public static Move NextMove(Move currentMove, Direction targetDirection)
    {
        var nextCoord = NextCoord(new Move(currentMove.Coord, targetDirection));
        return new Move(nextCoord, targetDirection);
    }
    
    public static Coord NextCoord(Move move)
    {
        return move.Direction switch
        {
            Direction.Up => new Coord(move.Coord.R - 1, move.Coord.C),
            Direction.Down => new Coord(move.Coord.R + 1, move.Coord.C),
            Direction.Left => new Coord(move.Coord.R, move.Coord.C - 1),
            Direction.Right => new Coord(move.Coord.R, move.Coord.C + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(move.Direction), move.Direction, null)
        };
    }
}
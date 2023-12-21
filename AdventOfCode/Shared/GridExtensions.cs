namespace AdventOfCode.Shared;

public static class GridExtensions
{
    public static Coord NextCoord(this Coord coord, Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Coord(coord.R - 1, coord.C),
            Direction.Down => new Coord(coord.R + 1, coord.C),
            Direction.Left => new Coord(coord.R, coord.C - 1),
            Direction.Right => new Coord(coord.R, coord.C + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}
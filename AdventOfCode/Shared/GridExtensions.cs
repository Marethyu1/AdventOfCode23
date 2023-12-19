namespace AdventOfCode.Shared;

public static class GridExtensions
{
    public static Coord NextCoord(this Coord coord, Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Coord(coord.X - 1, coord.Y),
            Direction.Down => new Coord(coord.X + 1, coord.Y),
            Direction.Left => new Coord(coord.X, coord.Y - 1),
            Direction.Right => new Coord(coord.X, coord.Y + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}
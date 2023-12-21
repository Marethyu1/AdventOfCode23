namespace AdventOfCode.Shared;

public static class GridExtensions
{
    private static Dictionary<Coord, Dictionary<Direction, Coord>> _map =
        new Dictionary<Coord, Dictionary<Direction, Coord>>();
    
    public static Coord NextCoord(this Coord coord, Direction direction)
    {
        Coord nextCoordC;
        if (_map.TryGetValue(coord, out var nextMap))
        {
            if (nextMap.TryGetValue(direction, out var nextCoord))
            {
                return nextCoord;
            }
            else
            {
                nextCoordC = NextCoordCalc(coord, direction);
                _map[coord][direction] = nextCoordC;
                return nextCoordC;
            }
        }
        else
        {
            _map[coord] = new Dictionary<Direction, Coord>();
            _map[coord][direction] = NextCoordCalc(coord, direction);
            return _map[coord][direction];
        }
    }

    private static Coord NextCoordCalc(Coord coord, Direction direction)
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
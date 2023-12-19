namespace AdventOfCode.Shared;

public class CoordinateOutOfGridException : Exception
{
    public CoordinateOutOfGridException(Coord coord) : base(coord.ToString())
    {

    }
}

public class Grid<T>
{
    private readonly T[][] _input;
    public long Width => _input[0].Length;
    public long Height => _input.Length;

    public T this[Coord coord]
    {
        get
        {
            try
            {
                return _input[coord.X][coord.Y];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new CoordinateOutOfGridException(coord);
            }
        }
    }

    public Grid(T[][] input)
    {
        _input = input;
    }

    public override string ToString()
    {
        var rows = _input.Select(x => string.Join("", x));
        return string.Join("\r\n", rows);
    }
}
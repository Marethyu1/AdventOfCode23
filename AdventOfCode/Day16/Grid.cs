

using AdventOfCode.Shared;

namespace AdventOfCode.Day16;

public class CoordinateOutOfGridException : Exception
{
    public CoordinateOutOfGridException(Coord coord) : base(coord.ToString())
    {

    }
}

public class Grid<T>
{
    public readonly T[][] Input;

    public T this[Coord coord]
    {
        get
        {
            try
            {
                return Input[coord.R][coord.C];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new CoordinateOutOfGridException(coord);
            }
        }
    }

    public Grid(T[][] input)
    {
        Input = input;
    }

    public override string ToString()
    {
        var rows = Input.Select(x => string.Join("", x));
        return string.Join("\r\n", rows);
    }

    public string Debug(Func<T, string> transform)
    {
        var rows = Input.Select(x => string.Join("", x.Select(transform)));
        return string.Join("\r\n", rows);
    }
}
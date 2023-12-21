namespace AdventOfCode.Shared;

public class CoordinateOutOfGridException : Exception
{
    public CoordinateOutOfGridException(Coord coord) : base(coord.ToString())
    {

    }
}

public class Grid<T>
{
    internal readonly T[][] Input;
    public long Width => Input[0].Length;
    public long Height => Input.Length;

    public T this[int r, int c]
    {
        get
        {
            try
            {
                return Input[r][c];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new CoordinateOutOfGridException(new Coord(r, c));
            }
        }
    }

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
        protected set => Input[coord.R][coord.C] = value;
    }

    public bool InBounds(Coord coord)
    {
        return coord.R >= 0 && coord.R < Input.Length && coord.C >=0 && coord.C < Input[0].Length; 
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
}
namespace AdventOfCode.Day18;

public enum SpaceType
{
    RoundRock = 'O',
    SquareRock = '#',
    Empty = '.'
}

public class Cell
{
    private readonly char _value;
    public SpaceType SpaceType { get; }

    public Cell(char value)
    {
        _value = value;
        SpaceType = (SpaceType) value;
    }

    public override string ToString()
    {
        return $"{_value}";
    }
}
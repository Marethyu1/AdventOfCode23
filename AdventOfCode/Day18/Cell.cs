namespace AdventOfCode.Day18;

public enum SpaceType
{
    RoundRock = 'O',
    SquareRock = '#',
    Empty = '.'
}

public class Cell
{
    public char Value { get; set; }
    public SpaceType SpaceType => (SpaceType) Value;

    public Cell(char value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"{Value}";
    }
}
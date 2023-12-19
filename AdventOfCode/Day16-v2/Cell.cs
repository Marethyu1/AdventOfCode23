namespace AdventOfCode.Day16_v2;

public class Cell
{
    public Value Value { get; }

    public Cell(Value value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"{(char) Value}";
    }
}
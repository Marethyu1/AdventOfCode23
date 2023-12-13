namespace AdventOfCode.Day11;

public class Location
{
    public readonly char Value;
    public Guid Id;
    public bool Empty => Value == '.';

    public override string ToString()
    {
        return $"{Value}";
    }

    public Location(char value)
    {
        Value = value;
        Id = Guid.NewGuid();
    }
}
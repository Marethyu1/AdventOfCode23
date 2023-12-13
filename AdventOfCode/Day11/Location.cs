namespace AdventOfCode.Day11;

public class Location
{
    public readonly char Value;
    public Guid Id;
    public bool Empty => Value == '.';
    
    public bool IsExtraEmpty => Amount > 1;

    public int Amount;

    public override string ToString()
    {
        return IsExtraEmpty ? "*" : Value.ToString();
    }
    

    public Location(char value)
    {
        Value = value;
        Id = Guid.NewGuid();
        Amount = 1;
    }
}
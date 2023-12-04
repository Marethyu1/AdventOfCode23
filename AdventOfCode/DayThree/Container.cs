namespace AdventOfCode.DayThree;

public class Container
{
    public char Value { get; set; }
    public bool Marked { get; set; } = false;

    public bool HasInt()
    {
        return int.TryParse(Value.ToString(), out _);
    }

    public bool HasSymbol()
    {
        return !HasInt() && Value != '.';
    }
}
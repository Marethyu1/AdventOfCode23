namespace AdventOfCode.Day10;

public enum Value
{
    NorthSouth = '|',
    EastWest = '-',
    NorthEast = 'L',
    NorthWest = 'J',
    SouthWest = '7',
    SouthEast = 'F',
    Ground = '.',
    Start = 'S',
    
}

public class Node
{
    public Value Value;
    public Node? Next;
    public bool Visited = false;
    public int Counter = -1;
    public bool IsStartingNode => Value == Value.Start;
    public bool Transitional;
    public Node(char value)
    {
        Value = (Value) value;
        Transitional = TransitionalNodes.Contains(Value);
    }

    private static readonly HashSet<Value> TransitionalNodes = new()
    {
        Value.NorthSouth,
        Value.EastWest,
        Value.NorthEast,
        Value.NorthWest,
        Value.SouthWest,
        Value.SouthEast
    };
}
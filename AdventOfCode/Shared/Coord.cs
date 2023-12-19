namespace AdventOfCode.Shared;

public record Coord(int X, int Y)
{
    public readonly int X = X;
    public readonly int Y = Y;

    public override string ToString()
    {
        return $"({X},{Y})";
    }
    
}
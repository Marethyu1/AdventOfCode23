namespace AdventOfCode.Shared;

public record Coord(int R, int C)
{
    public readonly int R = R;
    public readonly int C = C;

    public override string ToString()
    {
        return $"({R},{C})";
    }
}
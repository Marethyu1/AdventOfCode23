namespace AdventOfCode.Day21;

public class Plot
{
    public char Input { get; }

    public bool Walkable => Input == '.';

    public Plot(char input)
    {
        Input = input;
    }

    public override string ToString()
    {
        return $"{Input}";
    }
}
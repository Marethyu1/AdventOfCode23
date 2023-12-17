using System.Collections;

namespace AdventOfCode.Day13;

public class MirrorGrid
{
    public readonly char[][] Chars;

    public MirrorGrid(char[][] chars)
    {
        Chars = chars;
    } 
    public override string ToString()
    {
        var rows = Chars.Select(x => string.Join("", x));
        var output = string.Join("\n", rows);
        return output;
    }

    public static MirrorGrid Parse(IEnumerable<string> input)
    {
        return new MirrorGrid(input.Select(x => x.ToCharArray()).ToArray());
    }
}
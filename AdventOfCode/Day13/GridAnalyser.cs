namespace AdventOfCode.Day13;

public static class GridAnalyser
{
    public static IEnumerable<long> AnalyseRows(MirrorGrid grid)
    {
        var chars = grid.Chars;
        for (var i = 0; i < chars.Length; i++)
        {
            var lhs = i;
            var rhs = i + 1;
            while (lhs > 0)
            {
                var leftRow = chars[i];
                var rightRow = chars[i];
            }

        }

        return new List<long>();
    }
}
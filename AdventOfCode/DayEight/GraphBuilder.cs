namespace AdventOfCode.DayEight;

public class GraphBuilder
{
    private readonly IEnumerable<string> _rawGraph;

    public GraphBuilder(IEnumerable<string> rawGraph)
    {
        _rawGraph = rawGraph;
    }

    public Graph Build()
    {
        var nodes = new Dictionary<string, Tuple<string, string>>();
        
        foreach (var rawLine in _rawGraph)
        {
            var line = ParseLine(rawLine);
            nodes[line.Item1] = new Tuple<string, string>(line.Item2, line.Item3);
        }

        return new Graph(nodes);
    }

    private static Tuple<string, string, string> ParseLine(string line)
    {
        var items = line.Split("=")
            .Select(x => x.Trim())
            .ToArray();

        var root = items[0];

        var values = items[1].Replace(
                "(", string.Empty)
            .Replace(")", string.Empty)
            .Split(",")
            .Select(x => x.Trim())
            .ToArray();

        var lhs = values[0];
        var rhs = values[1];

        return new Tuple<string, string, string>(root, lhs, rhs);
    } 
}
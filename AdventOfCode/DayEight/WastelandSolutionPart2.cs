namespace AdventOfCode.DayEight;

public class WastelandSolutionPart2: ISolution<long>
{
    private readonly Graph _graph;
    private readonly char[] _input;
    
    public WastelandSolutionPart2(string path)
    {
        var lines = File.ReadAllLines(path)
            .Select(x => x.Trim())
            .ToArray();
        _input = lines[0].ToArray();
        var graphInput = lines.Skip(2);

        var builder = new GraphBuilder(graphInput);

        _graph = builder.Build();
    }
    public long Solve()
    {
        var nodes = _graph.Nodes(key => key.EndsWith("A"))
            .ToList();

        var cycles = new List<long>();

        foreach (var node in nodes)
        {
            var currentNode = node;
            var counter = 0;

            while (!currentNode.Current.EndsWith("Z"))
            {
                var nextMove = _input[counter % _input.Length];
                Func<char, Node, Node> next = (c, n) => c == 'L' ? _graph.Lookup(n.Lhs) : _graph.Lookup(n.Rhs);
                currentNode = next(nextMove, currentNode);
                counter++;
            }
            cycles.Add(counter);
        }

        var lcm = cycles[0];
        for (var i = 1; i < cycles.Count; i++)
        {
            lcm = Lcm(lcm, cycles[i]);
        }
        
        return cycles.Aggregate(Lcm);
    }
    
    private static long Gcf(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private static long Lcm(long a, long b)
    {
        return (a / Gcf(a, b)) * b;
    }
}
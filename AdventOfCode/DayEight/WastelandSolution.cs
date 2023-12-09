namespace AdventOfCode.DayEight;

public class WastelandSolution: ISolution<int>
{
    private readonly Graph _graph;
    private readonly char[] _input;
    
    
    public WastelandSolution(string path)
    {
        var lines = File.ReadAllLines(path)
            .Select(x => x.Trim())
            .ToArray();
        _input = lines[0].ToArray();
        var graphInput = lines.Skip(2);

        var builder = new GraphBuilder(graphInput);

        _graph = builder.Build();
    }
    
    public int Solve()
    {
        var current = _graph.StartNode;
        var counter = 0;
        while (!Equals(current, _graph.EndNode))
        {
            var nextMove = _input[counter % _input.Length];

            var next = current.Item1;
            if (nextMove == 'R')
            {
                next = current.Item2;
            }

            current = _graph.Lookup(next);
            counter++;
        }
        return counter;
    }
}
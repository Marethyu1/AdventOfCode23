namespace AdventOfCode.DayEight;

public class Graph
{
    private Dictionary<string, Node> _map;
    
    private const string Start = "AAA";
    private const string End = "ZZZ";

    public Node StartNode => _map[Start];
    public Node EndNode => _map[End];
    
    public Graph(Dictionary<string, Tuple<string, string>> map)
    {
        _map =  map.Keys.Select(x => new Node(x, map[x].Item1, map[x].Item2))
            .ToDictionary(x => x.Current, node => node);
    }
    
    public List<Tuple<string, string>> Nodes(Func<string, bool> filter)
    {
        throw new NotImplementedException();
        // return _map.Keys
        //     .Where(filter)
        //     .Select(x => _map[x])
        //     .ToList();
    }

    public Node Lookup(string next)
    {
        return _map[next];
    }
}

public record Node(string Current, string Lhs, string Rhs);
namespace AdventOfCode.DayEight;

public class Graph
{
    private Dictionary<string, Tuple<string, string>> _map;
    
    private const string Start = "AAA";
    private const string End = "ZZZ";

    public Tuple<string, string> StartNode => _map[Start];
    public Tuple<string, string> EndNode => _map[End];
    

    public Graph(Dictionary<string, Tuple<string, string>> map)
    {
        _map = map;
    }

    public Tuple<string, string> Lookup(string next)
    {
        return _map[next];
    }
}
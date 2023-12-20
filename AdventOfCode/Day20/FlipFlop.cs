namespace AdventOfCode.Day20;

public class FlipFlop: IModule
{
    public IEnumerable<string> OutPutModules { get; }
    public string Key { get; }
    
    public FlipFlop(string key, IEnumerable<string> outPutModules)
    {
        OutPutModules = outPutModules;
        Key = key;
    }

    public void Process(Pulse pulse)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"[FF]: {Key} -> {string.Join(",", OutPutModules)}";
    }
}
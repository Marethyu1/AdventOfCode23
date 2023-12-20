namespace AdventOfCode.Day20;

public class Conjunction: IModule
{
    public IEnumerable<string> OutPutModules { get; }
    public string Key { get; }

    public Conjunction(string key, IEnumerable<string> outPutModules)
    {
        Key = key;
        OutPutModules = outPutModules;
    }
    
    public void Process(Pulse pulse)
    {
        throw new NotImplementedException();
    }
    
    public override string ToString()
    {
        return $"[CJ]: {Key} -> {string.Join(",", OutPutModules)}";
    }
}
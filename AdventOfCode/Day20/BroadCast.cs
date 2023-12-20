namespace AdventOfCode.Day20;

public class BroadCast: IModule
{
    public IEnumerable<string> OutPutModules { get; }
    public string Key { get; }
    
    public BroadCast(string key, IEnumerable<string> outPutModules)
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
        return $"[BC]: {Key} -> {string.Join(",", OutPutModules)}";
    }
}
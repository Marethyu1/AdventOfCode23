namespace AdventOfCode.Day20;

public class Conjunction: IModule
{
    public IEnumerable<string> OutPutModules { get; }
    private Dictionary<string, Pulse> _memory = new();
    
    public string Key { get; }

    public Conjunction(string key, IEnumerable<string> outPutModules)
    {
        Key = key;
        OutPutModules = outPutModules;
    }
    
    public Pulse Process(string currentModuleKey, Pulse pulse)
    {
        if (currentModuleKey == "tf" && pulse == Pulse.High)
        {
            throw new Exception("ohno");
        }
        _memory[currentModuleKey] = pulse;
        return _memory.Values.All(p => p == Pulse.High) ? Pulse.Low : Pulse.High;
    }
    
    //vq 4006
    // ln 4090
    // db 3928
    // tf 3922

    public void Link(string key)
    {
        _memory.Add(key, Pulse.Low);
    }
    
    public override string ToString()
    {
        // return $"[CJ]: {string.Join(",", _memory.Keys)} ->  {Key} -> {string.Join(",", OutPutModules)}";
        return $"[CJ]: {Key} -> {string.Join(",", OutPutModules)}";
    }
}
namespace AdventOfCode.Day20;

public class Terminal: IModule
{
    public IEnumerable<string> OutPutModules { get; }
    public string Key { get; }

    public Terminal(string key)
    {
        OutPutModules = new List<string>();
        Key = key;
    }
    public Pulse Process(string currentModuleKey, Pulse pulse)
    {
        // if (pulse == Pulse.Low)
        // {
        //     throw new Exception();
        // }
        return Pulse.NoSignal;
    }
}
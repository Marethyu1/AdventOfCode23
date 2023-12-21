namespace AdventOfCode.Day20;

public class Terminal: IModule
{
    public IEnumerable<string> OutPutModules { get; }

    public Func<Pulse, Pulse> CustomProcess = pulse => Pulse.NoSignal;
    public string Key { get; }

    public Terminal(string key)
    {
        OutPutModules = new List<string>();
        Key = key;
    }
    public Pulse Process(string currentModuleKey, Pulse pulse)
    {
        return CustomProcess(pulse);
    }
}
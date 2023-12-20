namespace AdventOfCode.Day20;

public interface IModule
{
    public IEnumerable<string> OutPutModules { get; }
    public string Key { get; }
    public void Process(Pulse pulse);
}
namespace AdventOfCode.Day20;

public interface IModuleFactory
{
    public string Type { get; }
    public IModule Create(string key, IEnumerable<string> values);
}
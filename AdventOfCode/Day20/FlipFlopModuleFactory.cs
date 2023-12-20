namespace AdventOfCode.Day20;

public class FlipFlopModuleFactory: IModuleFactory
{
    public string Type => "%";
    public IModule Create(string key, IEnumerable<string> values)
    {
        return new FlipFlop(key, values);
    }
}
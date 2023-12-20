namespace AdventOfCode.Day20;

public class ConjunctionFactory: IModuleFactory
{
    public string Type => "&";
    public IModule Create(string key, IEnumerable<string> values)
    {
        return new Conjunction(key, values);
    }
}
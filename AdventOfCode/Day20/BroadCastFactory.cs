namespace AdventOfCode.Day20;

public class BroadCastFactory: IModuleFactory
{
    public string Type => "broadcaster";
    public IModule Create(string key, IEnumerable<string> values)
    {
        return new BroadCast(key, values);
    }
}
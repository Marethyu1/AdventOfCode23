namespace AdventOfCode.Day20;

public class PulseSolution: ISolution<long>
{

    public PulseSolution(string filePath)
    {
        var modules = File.ReadAllLines(filePath)
            .Select(ModuleFactory.ToModule);

        foreach (var module in modules)
        {
            Console.WriteLine(module);
        }
    }
    
    public long Solve()
    {
        throw new NotImplementedException();
    }
}
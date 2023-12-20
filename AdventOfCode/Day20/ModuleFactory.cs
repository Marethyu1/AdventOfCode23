using System.Diagnostics;

namespace AdventOfCode.Day20;

public static class ModuleFactory
{
    public const string BroadCast = "broadcaster";
    public const string FlipFlop = "%";
    public const string Conjunction = "&";

    public static Dictionary<string, IModuleFactory> Factories = new Dictionary<string, IModuleFactory>()
    {
        [FlipFlop] = new FlipFlopModuleFactory(),
        [Conjunction] = new ConjunctionFactory(),
        [BroadCast] = new BroadCastFactory(),
    };
    
    public static IModule ToModule(string input)
    {
        foreach (var key in Factories.Keys)
        {
            var factory = Factories[key];
            if (!input.StartsWith(key)) continue;
            
            var restOfInput = input[key.Length..];
            var sides = restOfInput.Split("->")
                .Select(x => x.Trim()).ToArray();

            var moduleKey = sides[0];
            var outPutModules = sides[1].Split(",")
                .Select(x => x.Trim());

            return factory.Create(moduleKey, outPutModules);
        }

        throw new UnreachableException();
    }
}
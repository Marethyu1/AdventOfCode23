using System.Text;

namespace AdventOfCode.DayFive;

public class SeedSolution: ISolution<long>, IParsable<SeedSolution>
{
    private readonly List<long> _startingSeeds;
    private readonly List<SeedMap> _seedMaps;
    public SeedSolution(List<long> startingSeeds, List<SeedMap> seedMaps)
    {
        _startingSeeds = startingSeeds;
        _seedMaps = seedMaps;
    }
    
    public long Solve()
    {
        var lowest = long.MaxValue;
        foreach (var seed in _startingSeeds)
        {
            var output = seed;
            foreach (var seedMap in _seedMaps)
            {
                output = seedMap.Evaluate(output);
            }

            if (output < lowest)
            {
                lowest = output;
            }
        }

        return lowest;
    }


    public static SeedSolution Parse(string s, IFormatProvider? provider)
    {
        var lines = s.Split(Environment.NewLine);
        var starter = lines.First(x => x.Length > 1);
        var seedLine = starter.Split(":");
        var seeds = seedLine[1].Trim()
            .Split(" ")
            .Select(long.Parse);

        var seedMaps = new List<SeedMap>();


        var fromMapStart = lines.Skip(1).SkipWhile(x => !x.Contains("map:"))
            .ToArray();
        var sb = new StringBuilder();
        foreach (var line in fromMapStart)
        {
            if (line.Length <= 3)
            {
                seedMaps.Add(SeedMap.Parse(sb.ToString(), null));
                sb = new StringBuilder();
            }
            else
            {
                sb.AppendLine(line);
            }
        }

        seedMaps.Add(SeedMap.Parse(sb.ToString(), null));
        return new SeedSolution(seeds.ToList(), seedMaps);
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out SeedSolution result)
    {
        throw new NotImplementedException();
    }
}
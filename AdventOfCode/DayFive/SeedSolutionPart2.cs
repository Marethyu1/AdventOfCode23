using System.Text;

namespace AdventOfCode.DayFive;

public class SeedSolutionPart2: ISolution<long>, IParsable<SeedSolutionPart2>
{
    private readonly List<long> _startingSeeds;
    private readonly List<SeedMap> _seedMaps;
    private readonly Queue<SeedMap> _seedMaps2;
    
    public SeedSolutionPart2(List<long> startingSeeds, List<SeedMap> seedMaps)
    {
        _startingSeeds = startingSeeds;
        _seedMaps = seedMaps;

        var reference = new Queue<SeedMap>();
        
        foreach (var seedMap in _seedMaps)
        {
            reference.Enqueue(seedMap);
        }

        _seedMaps2 = reference;

    }
    
    public long Solve()
    {
        var lowest = long.MaxValue;
        
        var current = _seedMaps2.Dequeue();

        var seeds = new List<long>();
        
        seeds = _startingSeeds;
        for (var i = 0; i < _startingSeeds.Count; i += 2)
        {
            var startIndex = seeds[i];
            var range = seeds[i + 1];

            var values = current.GetValues(startIndex, range);
            seeds.AddRange(values);
            current = _seedMaps2.Dequeue();
        }

        // for (var i = 0; i < _startingSeeds.Count; i+=2)
        // {
        //     Console.WriteLine(i);
        //     var startIndex = _startingSeeds[i];
        //     var range = _startingSeeds[i + 1];
        //     
        //     for (var j = startIndex; j < startIndex + range; j++)
        //     {
        //         if (j % 100000 == 0)
        //         {
        //             Console.WriteLine(j);
        //         }
        //         var output = j;
        //         foreach (var seedMap in _seedMaps)
        //         {
        //             output = seedMap.Evaluate(output);
        //         }
        //
        //         if (output < lowest)
        //         {
        //             lowest = output;
        //         }
        //     }
        // }

        return lowest;
    }

    public static SeedSolutionPart2 Parse(string s, IFormatProvider? provider)
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
        return new SeedSolutionPart2(seeds.ToList(), seedMaps);
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out SeedSolutionPart2 result)
    {
        throw new NotImplementedException();
    }
}
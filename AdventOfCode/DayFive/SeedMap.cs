namespace AdventOfCode.DayFive;

public class SeedMap: IParsable<SeedMap>
{
    private readonly string _name;
    private readonly List<MapRange> _ranges;

    public SeedMap(string name, List<MapRange> ranges)
    {
        _name = name;
        _ranges = ranges.OrderBy(o => o.SourceRangeStart).ToList();
    }

    public long Evaluate(long i)
    {
        foreach (var mapRange in _ranges)
        {
            if (mapRange.InRange(i))
            {
                return mapRange.Map(i);
            }
        }

        return i;
    }

    public List<long> GetValues(long startIndex, long range)
    {
        var values = _ranges.Where(x => x.SourceRangeStart >= startIndex && x.SourceRangeStart <= startIndex + range)
            .Select(x => x.SourceRangeStart)
            .ToArray();

        if (values.Length == 0)
        {
            values = values.Append(startIndex).ToArray();
        }
        else if (values[0] > startIndex)
        {
            values = values.Prepend(startIndex).ToArray();
        }
        
        if (values.Length > 0 && values[^1] < startIndex + range)
        {
            var add = _ranges.First(x => x.SourceRangeStart == values[^1]);
            values = values.Append(values[^1] + add.RangeLength + 1).ToArray();
        }

        return values.ToList();
    }

    public override string ToString()
    {
        return $"{_name.Split(":")[0]}";
    }

    public static SeedMap Parse(string s, IFormatProvider? provider)
    {
        var lines = s.Split(Environment.NewLine)
            .Where(x => x.Length > 2).ToArray();
        var mapName = lines[0];

        var mapRanges = lines.Skip(1)
            .Select(x => MapRange.Parse(x, null));

        return new SeedMap(mapName, mapRanges.ToList());
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out SeedMap result)
    {
        result = null;
        if (s == null) { return false; }
        try {
            result = Parse(s, provider);
            return true;
        } catch { return false; }
    }
}
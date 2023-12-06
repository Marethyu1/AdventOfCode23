namespace AdventOfCode.DayFive;

public class SeedMap: IParsable<SeedMap>
{
    private readonly string _name;
    private readonly List<MapRange> _ranges;

    public SeedMap(string name, List<MapRange> ranges)
    {
        _name = name;
        _ranges = ranges;
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
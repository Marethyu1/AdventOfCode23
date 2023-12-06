namespace AdventOfCode.DayFive;

public class MapRange: IParsable<MapRange>
{
    public long DestinationRangeStart { get; }
    public long SourceRangeStart { get; }
    public long RangeLength { get; }

    public MapRange(long destinationRangeStart, long sourceRangeStart, long rangeLength)
    {
        DestinationRangeStart = destinationRangeStart;
        SourceRangeStart = sourceRangeStart;
        RangeLength = rangeLength;
    }

    public override string ToString()
    {
        return $"{DestinationRangeStart}-{SourceRangeStart}-{RangeLength}";
    }

    public static MapRange Parse(string s, IFormatProvider? provider)
    {
        var ints = s
            .Split(' ')
            .Select(long.Parse).ToArray();
        return new MapRange(ints[0], ints[1], ints[2]);
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out MapRange result)
    {
        result = null;
        if (s == null) { return false; }
        try {
            result = Parse(s, provider);
            return true;
        } catch { return false; }
    }

    public bool InRange(long i)
    {
        return i >= SourceRangeStart && i <= SourceRangeStart + RangeLength;
    }

    public long Map(long i)
    {
        return i - SourceRangeStart + DestinationRangeStart;
    }
}
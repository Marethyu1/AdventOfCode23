namespace AdventOfCode.DayNine;

public class Pyramid
{
    private readonly IEnumerable<long> _topRow;
    private readonly List<List<long>> _rows;

    public Pyramid(IEnumerable<long> topRow)
    {
        _topRow = topRow;
        _rows = new List<List<long>>()
        {
            _topRow.ToList()
        };
    }

    public Pyramid Build()
    {
        var currentRow = _rows[0];

        while (!currentRow.TrueForAll(x => x == 0))
        {
            var nextRow = new List<long>();
            for (var i = 0; i < currentRow.Count -1; i++)
            {
                var lhs = currentRow[i];
                var rhs = currentRow[i + 1];
                nextRow.Add(rhs - lhs);
            }

            _rows.Add(nextRow);
            currentRow = _rows[^1];
        }

        foreach (var row in _rows)
        {
            Console.WriteLine(string.Join(" ", row));
        }
        
        return this;
    }

    public long PredictNextValue()
    {
        return _rows.Sum(x => x[^1]);
    }

    public long PredictFirstValue()
    {
        
        foreach (var longs in _rows)
        {
            longs.Insert(0, 0);
        }

        var start = 0;
        for (var i = _rows.Count - 1; i > 0; i--)
        {
            var current = _rows[i][0];
            var prev = _rows[i-1][1];
            _rows[i - 1][0] = prev - current;

        }

        return _rows[0][0];
    }

    public static Pyramid Parse(string line)
    {
        var nums = line.Split(" ")
            .Select(long.Parse);

        return new Pyramid(nums);
    }
}
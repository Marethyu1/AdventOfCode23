namespace AdventOfCode.DayNine;

public class MirageSolution2: ISolution<long>
{
    private IEnumerable<Pyramid> _pyramids;
    
    public MirageSolution2(string filePath)
    {
        _pyramids = File.ReadAllLines(filePath)
            .Select(x => x.Trim())
            .Select(Pyramid.Parse);
    }
    
    
    public long Solve()
    {
        return _pyramids.Select(x => x.Build())
            .Sum(x => x.PredictFirstValue());
    }
}
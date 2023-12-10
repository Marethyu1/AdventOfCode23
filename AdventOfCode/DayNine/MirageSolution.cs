namespace AdventOfCode.DayNine;

public class MirageSolution: ISolution<long>
{
    private IEnumerable<Pyramid> _pyramids;
    
    public MirageSolution(string filePath)
    {
        _pyramids = File.ReadAllLines(filePath)
            .Select(x => x.Trim())
            .Select(Pyramid.Parse);
    }
    
    
    public long Solve()
    {
        return _pyramids.Select(x => x.Build())
            .Select(x =>
            {
                Console.WriteLine(x.PredictNextValue());
                return x;
            })
            .Sum(x => x.PredictNextValue());
    }
}
namespace AdventOfCode.Day11;

public abstract class BaseGalaxy: ISolution<long>
{
    private readonly Galaxy _galaxy;
    
    public BaseGalaxy(string filePath, int expansionAmount)
    {
        var lines = File.ReadAllText(filePath);
        var galaxy = Galaxy.ToGalaxy(lines);
        _galaxy = galaxy.Expand(expansionAmount);
        
    }

    public long Solve()
    {
        Console.WriteLine(_galaxy);
        var pairs = _galaxy.DeterminePairsOfGalaxies();
        return pairs.Sum(x => _galaxy.DetermineDistance(x));
    }
}
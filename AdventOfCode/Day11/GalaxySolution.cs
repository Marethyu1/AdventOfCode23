namespace AdventOfCode.Day11;

public class GalaxySolution: ISolution<int>
{
    private Galaxy _galaxy;
    public GalaxySolution(string filePath)
    {
        var lines = File.ReadAllText(filePath);
        var galaxy = Galaxy.ToGalaxy(lines);
        _galaxy = galaxy.Expand();
        
    }

    public int Solve()
    {
        Console.WriteLine(_galaxy);
        var pairs = _galaxy.DeterminePairsOfGalaxies();
        return pairs.Sum(x => x.DetermineDistance());
    }
}
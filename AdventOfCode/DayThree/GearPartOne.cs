namespace AdventOfCode.DayThree;

public class GearPartOne: ISolution<int>
{
    private readonly Grid _grid;
    public GearPartOne(string input)
    {
        _grid = GridParser.ParseLines(input);
    }
    
    public int Solve()
    {
        return _grid.Solve();
    }
}
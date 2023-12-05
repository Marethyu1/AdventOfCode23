namespace AdventOfCode.DayThree;

public class GearPartTwo: ISolution<int>
{
    private readonly Grid _grid;
    public GearPartTwo(string input)
    {
        _grid = GridParser.ParseLines(input);
    }
    
    public int Solve()
    {
        return _grid.SolvePartTwo();
    }
}
namespace AdventOfCode.DayTwo;

public class CubePartTwo: ISolution<int>
{
    private readonly List<Game> _games;
    
    public CubePartTwo(string input)
    {
        _games = GameParser.Parse(input);
    }

    public int Solve()
    {
        var powers = _games.Select(PowerCalculator.Power);

        return powers.Sum();
    }
}
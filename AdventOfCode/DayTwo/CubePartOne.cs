namespace AdventOfCode.DayTwo;

public class CubePartOne: ISolution<int>
{
    private readonly List<Game> _games;
    private readonly GameValidator _gameValidator;
    private static readonly List<GameRule> Rules = new()
    {
        new GameRule
        {
            Colour = "red",
            MaxAmount = 12,
        },
        new GameRule
        {
            Colour = "green",
            MaxAmount = 13,
        },
        new GameRule
        {
            Colour = "blue",
            MaxAmount = 14,
        }
    };

    public CubePartOne(string input)
    {
        _games = GameParser.Parse(input);
        _gameValidator = new GameValidator(Rules);
    }
    
    public int Solve()
    {
        return _games
            .Where(x => _gameValidator.IsPossible(x))
            .Select(x => x.Id)
            .Sum();
    }
}
namespace AdventOfCode.TwoSolution;

public class TwoSolution: ISolution<int>
{
    private readonly string _lines;
    public static readonly List<Token> Tokens = new()
    {
        new Token("0", 0),
        new Token("1", 1),
        new Token("2", 2),
        new Token("3", 3),
        new Token("4", 4),
        new Token("5", 5),
        new Token("6", 6),
        new Token("7", 7),
        new Token("8", 8),
        new Token("9", 9),

        new Token("one", 1),
        new Token("two", 2),
        new Token("three", 3),
        new Token("four", 4),
        new Token("five", 5),
        new Token("six", 6),
        new Token("seven", 7),
        new Token("eight", 8),
        new Token("nine", 9),
    };

    private readonly Tokeniser _tokeniser;

    public TwoSolution(string lines)
    {
        _lines = lines;
        _tokeniser = new Tokeniser(Tokens);
    }
    
    public int Solve()
    {
        return _lines.Split(Environment.NewLine)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => _tokeniser.Tokenise(x))
            .Select(Tokeniser.ToDigit)
            .Sum();
    }
}
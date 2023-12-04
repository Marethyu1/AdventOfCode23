using AdventOfCode.TwoSolution;

namespace AdventOfCode;

public class One: ISolution<int>
{
    private readonly string _lines;
    private Tokeniser _tokeniser;

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
    };
    public One(string lines)
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
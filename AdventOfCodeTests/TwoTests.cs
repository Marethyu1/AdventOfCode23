using AdventOfCode.TwoSolution;
using Xunit.Abstractions;

namespace AdventOfCodeTests;

public class TwoTests
{
    private readonly ITestOutputHelper _testOutputHelper;
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

    private Tokeniser _tokeniser = new(Tokens);

    public TwoTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void SolvesBigBoy()
    {
        var lines = File.ReadAllText("one.txt");
        var one = new TwoSolution(lines);
        var output = one.Solve();
        Assert.Equal(53515, output);
        _testOutputHelper.WriteLine(output.ToString());
    }
    
    [Fact]
    public void CanDoBasicExample()
    {
        var lines = """
                    "two1nine
                    eightwothree
                    abcone2threexyz
                    xtwone3four
                    4nineeightseven2
                    zoneight234
                    7pqrstsixteen"
                    """;

        var one = new TwoSolution(lines);
        Assert.Equal(281, one.Solve());

    }
    
    [Fact]
    public void CanTokenise1()
    {
        var line = "1";
        
        var tokenised = _tokeniser.Tokenise(line);
        Assert.Equal(1, tokenised.First());
    }
    
    [Fact]
    public void CanTokenise9()
    {
        var line = "9";

        var tokenised = _tokeniser.Tokenise(line);
        Assert.Equal(9, tokenised.First());
    }
    
    [Fact]
    public void CanTokeniseOne()
    {
        var line = "one";

        var tokenised = _tokeniser.Tokenise(line);
        Assert.Equal(1, tokenised.First());
    }
    
    [Fact]
    public void CanTokeniseTwo()
    {
        var line = "two";

        var tokenised = _tokeniser.Tokenise(line);
        Assert.Equal(2, tokenised.First());
    }
}
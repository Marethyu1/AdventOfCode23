using AdventOfCode;
using AdventOfCode.TwoSolution;
using Xunit.Abstractions;

namespace AdventOfCodeTests;

public class OneTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private Tokeniser Tokeniser = new Tokeniser(new List<Token>()
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
    });

    public OneTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void SolvesBigBoy()
    {
        var lines = File.ReadAllText("one.txt");
        var one = new One(lines);
        var output = one.Solve();
        Assert.Equal(54388, output);
    }

    [Fact]
    public void CanDoBasicExample()
    {
        var lines = """
                   "1abc2
                   pqr3stu8vwx
                   a1b2c3d4e5f
                   treb7uchet"
                   """;

        var one = new One(lines);
        Assert.Equal(142, one.Solve());

    }

    [Fact]
    public void CanSolveALine()
    {
        var line = "123";

        var tokenised = Tokeniser.Tokenise(line);
        var digit = Tokeniser.ToDigit(tokenised);
        
        Assert.Equal(13, digit);
    }
    
    [Fact]
    public void CanSolveALineWithOneNumber()
    {
        var line = "aaaaaa3";
        var tokenised = Tokeniser.Tokenise(line);
        var digit = Tokeniser.ToDigit(tokenised);
        Assert.Equal(33, digit);
    }
}
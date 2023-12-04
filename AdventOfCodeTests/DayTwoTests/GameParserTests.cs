using AdventOfCode.DayTwo;

namespace AdventOfCodeTests.DayTwoTests;

public class GameParserTests
{
    private readonly Game _game = GameParser.ParseLine("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
    
    [Fact]
    public void CanParseAId()
    {
        Assert.Equal(1, _game.Id);
    }
    
    [Fact]
    public void CanParseTurn()
    {
        var firstTime = _game.Turns.First();
        Assert.Equal(3, firstTime.Combos["blue"]);
    }
}
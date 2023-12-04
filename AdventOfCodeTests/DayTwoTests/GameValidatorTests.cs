using AdventOfCode.DayTwo;

namespace AdventOfCodeTests.DayTwoTests;

public class GameValidatorTests
{
    private static List<GameRule> _rules = new()
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
    
    [Fact]
    public void CanValidateGame()
    {
        var validator = new GameValidator(_rules);
        var game = GameParser.ParseLine("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

        Assert.True(validator.IsPossible(game));
    }

    [Fact]
    public void CanValidateBadGame()
    {
        var validator = new GameValidator(_rules);
        var game = GameParser.ParseLine("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red");

        Assert.False(validator.IsPossible(game));
    }
}
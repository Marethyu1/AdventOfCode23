using AdventOfCode.DayTwo;

namespace AdventOfCodeTests.DayTwoTests;

public class PowerCalculatorTests
{
    [Fact]
    public void CanDeterminePowerFromGame()
    {
        var game = GameParser.ParseLine("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

        Assert.Equal(48, PowerCalculator.Power(game));

    }
    
    [Fact]
    public void CanDeterminePowerFromGame2()
    {
        var game = GameParser.ParseLine("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue");

        Assert.Equal(12, PowerCalculator.Power(game));

    }
    
    [Fact]
    public void CanDeterminePowerFromGame3()
    {
        var game = GameParser.ParseLine("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red");

        Assert.Equal(1560, PowerCalculator.Power(game));

    }
    
    [Fact]
    public void CanDeterminePowerFromGame4()
    {
        var game = GameParser.ParseLine("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");

        Assert.Equal(630, PowerCalculator.Power(game));

    }
    
    [Fact]
    public void CanDeterminePowerFromGame5()
    {
        var game = GameParser.ParseLine("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");

        Assert.Equal(36, PowerCalculator.Power(game));

    }
}
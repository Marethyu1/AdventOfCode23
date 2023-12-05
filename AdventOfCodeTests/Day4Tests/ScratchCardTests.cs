using AdventOfCode.DayFour;

namespace AdventOfCodeTests.Day4Tests;

public class ScratchCardTests
{
    [Fact]
    public void CanSolve1Card()
    {
        var cards = new ScratchCards("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53");
        Assert.Equal(8, cards.Solve());
    }

    [Fact]
    public void CanSolveBigBoy()
    {
        var input = File.ReadAllText("Day4Tests/cards.txt");
        var cards = new ScratchCards(input);
        Assert.Equal(20855, cards.Solve());
    }
}
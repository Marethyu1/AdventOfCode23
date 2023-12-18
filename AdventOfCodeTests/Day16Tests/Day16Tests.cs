using AdventOfCode.Day16;

namespace AdventOfCodeTests.Day16Tests;

public class Day16Tests
{
    [Fact]
    public void CanSolvePartOneBasic()
    {
        var lava = new Lava("Day16Tests/16-1.txt");
        Assert.Equal(46, lava.Solve());
    }
    
    [Fact]
    public void CanSolvePartOneBig()
    {
        var lava = new Lava("Day16Tests/16-1-big.txt");
        Assert.Equal(6361, lava.Solve());
    }

    [Fact]
    public void CanSolvePart2()
    {
        var lava = new LavaPart2("Day16Tests/16-1.txt");
        Assert.Equal(51, lava.Solve());
    }
}
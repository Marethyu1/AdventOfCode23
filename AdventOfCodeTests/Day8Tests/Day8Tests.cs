using AdventOfCode.DayEight;

namespace AdventOfCodeTests.Day8Tests;

public class Day8Tests
{
    [Fact]
    public void CanSolveBasic()
    {
        var solution = new WastelandSolution("Day8Tests/8-1.txt");
        Assert.Equal(2, solution.Solve());
    }
    
    [Fact]
    public void CanSolveRepeating()
    {
        var solution = new WastelandSolution("Day8Tests/8-1-2.txt");
        Assert.Equal(6, solution.Solve());
    }
    
    [Fact]
    public void CanSolveBigBoy()
    {
        var solution = new WastelandSolution("Day8Tests/8-1-3.txt");
        Assert.Equal(13301, solution.Solve());
    }
}
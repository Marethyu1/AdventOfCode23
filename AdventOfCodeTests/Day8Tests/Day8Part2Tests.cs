using AdventOfCode.DayEight;

namespace AdventOfCodeTests.Day8Tests;

public class Day8Part2Tests
{
    [Fact]
    public void CanSolveBasic()
    {
        var solution = new WastelandSolutionPart2("Day8Tests/8-1-4.txt");
        Assert.Equal(6, solution.Solve());
    }
    
    [Fact]
    public void CanSolveBigBoy()
    {
        var solution = new WastelandSolutionPart2("Day8Tests/8-1-3.txt");
        Assert.Equal(7309459565207, solution.Solve());
    }
}
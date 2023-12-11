using AdventOfCode.Day10;

namespace AdventOfCodeTests.Day10Tests;

public class MazeTests
{
    [Fact]
    public void CanSolveBasicMaze()
    {
        var s = new MazeSolution("Day10Tests/10-1.txt");
        Assert.Equal(8, s.Solve());
    }
}
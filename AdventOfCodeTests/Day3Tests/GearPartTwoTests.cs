using AdventOfCode.DayThree;

namespace AdventOfCodeTests.Day3Tests;

public class GearPartTwoTests
{
    [Fact]
    public void GetsGearedUp()
    {
        var grid = @"""
467..114..
...*....12
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..
""";
        var gear = new GearPartTwo(grid);
        Assert.Equal(467835, gear.Solve());

    }

    [Fact]
    public void SolvesBigBoy()
    {
        var engine = File.ReadAllText("Day3Tests/engine.txt");
        var gear = new GearPartTwo(engine);
        Assert.Equal(1, gear.Solve());

    }
}
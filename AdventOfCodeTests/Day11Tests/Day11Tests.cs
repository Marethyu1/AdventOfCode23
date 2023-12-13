using AdventOfCode.Day11;
using AdventOfCode.DayEight;
using Xunit.Abstractions;

namespace AdventOfCodeTests.Day11Tests;

public class Day11Tests
{
    private readonly ITestOutputHelper _testOutputHelper;
    
    private const string defaultInput = """
        ...#......
        .......#..
        #.........
        ..........
        ......#...
        .#........
        .........#
        ..........
        .......#..
        #...#.....
        """;

    public Day11Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void CanDoubleAGalaxy()
    {
        var input = """
                    ...#......
                    .......#..
                    #.........
                    ..........
                    ......#...
                    .#........
                    .........#
                    ..........
                    .......#..
                    #...#.....
                    """;

        var output = """
....#........
.........#...
#............
.............
.............
........#....
.#...........
............#
.............
.............
.........#...
#....#.......
""";

        var galaxy = Galaxy.ToGalaxy(input);

        var newGalaxy = galaxy.Expand();
        
        
        Assert.Equal(output.ReplaceLineEndings(), newGalaxy.ToString().ReplaceLineEndings().Trim());
    }

    [Fact]
    public void CanFindCoords()
    {
        var g = Galaxy.ToBigBrainGalaxy(defaultInput);
        Assert.Equal(9, g.DetermineCoordsWithGalaxies().Count);
    }
    
    [Fact]
    public void CanFindPairs()
    {
        var g = Galaxy.ToBigBrainGalaxy(defaultInput);
        var cp = g.DeterminePairsOfGalaxies();
        Assert.Equal(36, cp.Count);
    }

    [Fact]
    public void CanFindSumOfDistances()
    {
        var g = Galaxy.ToBigBrainGalaxy(defaultInput);
        var cp = g.DeterminePairsOfGalaxies();
        Assert.Equal(374, cp.Sum(x => x.DetermineDistance()));
    }
}
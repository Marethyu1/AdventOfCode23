using AdventOfCode.DayFive;

namespace AdventOfCodeTests.Day5Tests;

public class Day5Tests
{
    private SeedMap _seedMap;

    public Day5Tests()
    {
        var seedMap = """
                      "
                      seed-to-soil map:
                      50 98 2
                      52 50 48
                      "
                      """;
        _seedMap = SeedMap.Parse(seedMap, null);
    }
    
    [Theory]
    [InlineData( 51, 53)]
    [InlineData( 96,98)]
    [InlineData( 98, 50)]
    [InlineData( 99, 51)]
    [InlineData( 100, 52)]
    [InlineData( 101, 101)]
    public void GivenASampleMapEvaluatesAsExpected(int input, int expected)
    {
        Assert.Equal(expected, _seedMap.Evaluate(input));
    }


    [Fact]
    public void CanSoleBasicSeedMap()
    {
        var solution  = SeedSolution.Parse(File.ReadAllText("Day5Tests/basic.txt"), null);
        Assert.Equal(35,solution.Solve());
        
    }
    
    
    [Fact]
    public void CanSolveBigBoy()
    {
        var solution  = SeedSolution.Parse(File.ReadAllText("Day5Tests/big.txt"), null);
        Assert.Equal(174137457,solution.Solve());
        
    }
    
}
using AdventOfCode.DayNine;

namespace AdventOfCodeTests.Day9Tests;

public class MirageTests
{
    private const string Line = "0 3 6 9 12 15";
    
    [Fact]
    public void CanParseLine()
    {
        Assert.NotNull(Pyramid.Parse(Line));
    }

    [Fact]
    public void CanSolveLine()
    {
        var pyramid = Pyramid.Parse(Line);
        Assert.Equal(18, pyramid.Build().PredictNextValue());
    }

    [Fact]
    public void CanSolveThisOne()
    {
        var pyramid = Pyramid.Parse("9 7 1 5 44 158 415 938 1963 3961 7872 15505 30140 57314 105708 188096 322752 537022 877598 1436960 2412475");
        Assert.Equal(4222181, pyramid.Build().PredictNextValue());
    }

    [Fact]
    public void CanSolveBasic()
    {
        var solution = new MirageSolution("Day9Tests/9-1.txt");
        Assert.Equal(114, solution.Solve());
    }

    [Fact]
    public void CanSolveBigBoy()
    {
        var solution = new MirageSolution("Day9Tests/9-2.txt");
        Assert.Equal(114, solution.Solve());
    }
}
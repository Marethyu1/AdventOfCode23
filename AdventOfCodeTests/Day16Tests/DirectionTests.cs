using System.Text;
using AdventOfCode.Day16;
using AdventOfCode.Shared;
using Xunit.Abstractions;

namespace AdventOfCodeTests.Day16Tests;

public class DirectionTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    private static readonly Move StartMove = new(new Coord(0, 0), Direction.Right);

    public DirectionTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void CanMoveRight()
    {
        const string input = "..........";
        const string expectedOutput = "##########";
        
        Assert.Equal(expectedOutput, SolveForOutput(input));
    }

    [Fact]
    public void CanMoveRightAndUp()
    {
        var input = """
                    ..........
                    ....|.....
                    """;


        var expectedOutput = """
                             ....#.....
                             #####.....
                             """;

        var output = SolveForOutput(input, new Move(new Coord(1, 0), Direction.Right));
        
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void CanSplitBar()
    {
        var input = """
                    ..........
                    ....|.....
                    ..........
                    """;


        var expectedOutput = """
                             ....#.....
                             #####.....
                             ....#.....
                             """;

        var output = SolveForOutput(input, new Move(new Coord(1, 0), Direction.Right));
        
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void CanMoveUpOnSlash()
    {
        var input = """
                    ..........
                    ..../.....
                    ..........
                    """;


        var expectedOutput = """
                             ....#.....
                             #####.....
                             ..........
                             """;

        var output = SolveForOutput(input, new Move(new Coord(1, 0), Direction.Right));
        
        Assert.Equal(expectedOutput, output);
    }
    
    
    [Fact]
    public void CanMoveDown()
    {
        var input = """
                    ..........
                    ..../.....
                    ..........
                    """;


        var expectedOutput = """
                             ..........
                             ....######
                             ....#.....
                             """;

        var output = SolveForOutput(input, new Move(new Coord(1, 9), Direction.Left));
        
        Assert.Equal(expectedOutput, output);
    }
    
    

    private static string SolveForOutput(string input)
    {
        return SolveForOutput(input, StartMove);
    }
    
    private static string SolveForOutputSmart(string input)
    {
        var builder  =new StringBuilder();
        var lines = input.Split(Environment.NewLine);
        
        input.Split(Environment.NewLine);
        return SolveForOutput(input, StartMove);
    }

    private static string SolveForOutput(string input, Move startMove)
    {
        return Solve(input, startMove).ToString();
    }

    private static AdventOfCode.Day16.Grid<Container> Solve(string input, Move startMove)
    {
        var lava = LavaPart2.Create(input.Split(Environment.NewLine));
        LavaSolver.Solve(lava, startMove);
        return lava;
    }
}
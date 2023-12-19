using System.Text;
using AdventOfCode.Day16;
using AdventOfCode.Shared;
using Xunit.Abstractions;

namespace AdventOfCodeTests.Day16Tests;

public class LargeDirectionTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    private List<Tuple<List<string>, List<string>, string>> _groupedInputs;

    public LargeDirectionTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        var lines = File.ReadAllLines("Day16Tests/big-test.txt");

        var inputGroupings = new List<List<string>>();
        var currentInput = new List<string>();
        var currentName = "";
        
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (line.StartsWith("*"))
            {
                inputGroupings.Add(currentInput);
                currentInput = new List<string>()
                {
                    line
                };
            }
            else
            {
                currentInput.Add(line);
            }
        }

        var groupedInputs = new List<Tuple<List<string>, List<string>, string>>();
        var counter = 0;
        while (counter < inputGroupings.Count)
        {
            var currentN = "";
            var current = inputGroupings[counter];
            var input = new List<string>();
            var output = new List<string>();
            var hasPassedNewLine = false;
            var doubleCounter = 0;
            foreach (var t in current)
            {
                if (t.StartsWith("*"))
                {
                    currentN = t;
                }
                else if (t.Length < 2)
                {
                    hasPassedNewLine = true;
                } 
                else if (!hasPassedNewLine)
                {
                    input.Add(t);
                }
                else
                {
                    output.Add(t);
                }
                doubleCounter++;
            }
            groupedInputs.Add(new Tuple<List<string>, List<string>, string>(input, output, currentN));
            counter++;
        }

        _groupedInputs = groupedInputs;
    }
    
    [Fact]
    public void CanValidateManyDirections()
    {
        foreach (var input in _groupedInputs)
        {
            var (grid, startMove) = GetReady(input.Item1);
            var expectedOutPut = string.Join("\r\n", input.Item2);
            var startGrid = grid.ToString();
            LavaSolver.Solve(grid, startMove);

            var actualOutput = grid.Debug(x => x.Debug()); 
            var arEqual =  actualOutput == expectedOutPut;
            if (!arEqual)
            {
                _testOutputHelper.WriteLine(input.Item3);
                _testOutputHelper.WriteLine(startGrid);
                _testOutputHelper.WriteLine("\nEvaluation:");
                _testOutputHelper.WriteLine(actualOutput);
                _testOutputHelper.WriteLine("\nExpected:");
                _testOutputHelper.WriteLine(expectedOutPut);
            }

            Assert.Equal(expectedOutPut, actualOutput);
        }
    }

    private static (AdventOfCode.Day16.Grid<Container> grid, Move move) GetReady(List<string> input)
    {
        var parsedInput = new List<string>();
        Move move = new Move(new Coord(0, 0), Direction.Up);

        var d = new Dictionary<char, Direction>()
        {
            ['v'] = Direction.Down,
            ['>'] = Direction.Right,
            ['^'] = Direction.Up,
            ['<'] = Direction.Left,
        };
        
        for (var i = 0; i < input.Count; i++)
        {
            var row = new StringBuilder();
            for (int j = 0; j < input[i].Length; j++)
            {
                var currentChar = input[i][j];
                if (d.TryGetValue(currentChar, out var value))
                {
                    move = new Move(new Coord(i, j), value);
                    row.Append('.');
                }
                else
                {
                    row.Append(currentChar);
                }
            }

            parsedInput.Add(row.ToString());
        }

        return (LavaPart2.Create(parsedInput), move);
    }
}
using AdventOfCode.Shared;

namespace AdventOfCode.Day16;

public class Lava: ISolution<int>
{
    private readonly Grid<Container> _grid;
    private readonly Coord _start = new Coord(0, 0);
    private string[] _lines;
    
    public Lava(string filePath)
    {
        _lines = File.ReadAllLines(filePath);
        _grid = Create(_lines);

    }
    
    public int Solve()
    {
        var firstMove = new Move(_start, Direction.Right);
        return LavaSolver.Solve(_grid, firstMove);
    }
    
    private static Grid<Container> Create(string[] lines)
    {
        var parsedLines = lines.Select(x => x.Select(y => new Container(y))
                .ToArray())
            .ToArray();
        
        return new Grid<Container>(parsedLines);
    }
    
    
}
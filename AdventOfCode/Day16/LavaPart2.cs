namespace AdventOfCode.Day16;

public class LavaPart2: ISolution<int>
{
    private readonly string[] _lines;

    public LavaPart2(string filePath)
    {
        _lines = File.ReadAllLines(filePath);
    }
    
    public int Solve()
    {
        var baseGrid = Create(_lines);
        var moves = new List<Move>();

        var startRow = baseGrid.Input[0];

        for (var i = 0; i < startRow.Length; i++)
        {
            var move = new Move(new Coord(0, i), Direction.Down);
            moves.Add(move);
        }
        
        for (var i = 0; i < startRow.Length; i++)
        {
            var move = new Move(new Coord(baseGrid.Input.Length-1, i), Direction.Up);
            moves.Add(move);
        }
        
        for (var i = 0; i < baseGrid.Input.Length; i++)
        {
            var move = new Move(new Coord(0, i), Direction.Right);
            moves.Add(move);
        }
        
        for (var i = 0; i < baseGrid.Input.Length; i++)
        {
            var move = new Move(new Coord(i, startRow.Length-1), Direction.Left);
            moves.Add(move);
        }
        
        

        var min = int.MinValue;
        foreach (var move in moves)
        {
            
            var grid = Create(_lines);
            var count = LavaSolver.Solve(grid, move);
            if (count == 51)
            {
                Console.WriteLine(grid);
            }
            if (count > min)
            {
                min = count;
            }
        }
        
        
        Console.WriteLine(min);
        return min;
    }
    
    private static Grid<Container> Create(string[] lines)
    {
        var parsedLines = lines.Select(x => x.Select(y => new Container(y))
                .ToArray())
            .ToArray();
        
        return new Grid<Container>(parsedLines);
    }
    
}
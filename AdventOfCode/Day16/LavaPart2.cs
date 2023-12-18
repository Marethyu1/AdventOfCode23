namespace AdventOfCode.Day16;

public class LavaPart2: ISolution<int>
{
    private readonly string[] _lines;

    public static HashSet<char> ValidChars = new()
    {
        '.',
        '/',
        '\\',
        '|',
        '-'
    };

    public LavaPart2(string filePath)
    {
        _lines = File.ReadAllLines(filePath);
    }
    
    public int Solve()
    {
        var baseGrid = Create(_lines);
        var moves = GenerateStartingMoves(baseGrid);
        // var moves = new List<Move>()
        // {
            // new Move(new Coord(0, 74), Direction.Down)
        // };

        var min = int.MinValue;
        foreach (var move in moves)
        {
            
            var grid = Create(_lines);
            var count = LavaSolver.Solve(grid, move);
            
            if (count > min)
            {
                min = count;
            }
            
        }

        return min;
    }


    private static List<Move> GenerateStartingMoves(Grid<Container> grid)
    {
        var moves = new List<Move>();

        var startRow = grid.Input[0];
        
        for (var i = 0; i < startRow.Length; i++)
        {
            var move = new Move(new Coord(0, i), Direction.Down);
            moves.Add(move);
        }
        
        for (var i = 0; i < startRow.Length; i++)
        {
            var move = new Move(new Coord(grid.Input.Length-1, i), Direction.Up);
            moves.Add(move);
        }
        
        for (var i = 0; i < grid.Input.Length; i++)
        {
            var move = new Move(new Coord(0, i), Direction.Right);
            moves.Add(move);
        }
        
        for (var i = 0; i < grid.Input.Length; i++)
        {
            var move = new Move(new Coord(i, startRow.Length-1), Direction.Left);
            moves.Add(move);
        }

        return moves;
    }
    
    public static Grid<Container> Create(IEnumerable<string> lines)
    {

        var parsedLines = lines.Where(x => x.Length > 2)
            .Select(x => x.Where(c => ValidChars.Contains(c))
                .Select(y => new Container(y)).ToArray())
            .ToArray();
        return new Grid<Container>(parsedLines);
    }
    
}
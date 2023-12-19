using AdventOfCode.Shared;

namespace AdventOfCode.Day16_v2;

public class LavaSolution: ISolution<long>
{
    private readonly LavaGrid _grid;
    private static Move _start = new(new Coord(0, 0), Direction.Right);
    

    public LavaSolution(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        _grid = ToGrid(lines);
        Console.WriteLine(_grid);
    }
    
    public long Solve()
    {
        var moveGenerator = new MoveGenerator(_grid);
        var stack = new Stack<Move>();
        stack.Push(_start);
        var count = 0;
        while (stack.Any() && count < 1000000)
        {
            var current = stack.Pop();
            _grid.Visit(current);
            
            var nextMoves = moveGenerator.NextMoves(current);
            
            foreach (var move in nextMoves)
            {
                stack.Push(move);
            }

            count++;

        }
        
        Console.WriteLine(_grid.VisitedCoords());
        return 1;
    }

    public long SolvePart2()
    {
        var v = $"{_grid.Width},{_grid.Height}";
        Console.WriteLine(v);

        var moves = new List<Move>();
        
        for (var i = 0; i < _grid.Width; i++)
        {
            moves.Add(new Move(new Coord(0, i), Direction.Down));
            moves.Add(new Move(new Coord(0, i), Direction.Right));
            moves.Add(new Move(new Coord((int) _grid.Width-1, i), Direction.Up));
            moves.Add(new Move(new Coord( i, (int) _grid.Width-1), Direction.Left));
        }


        var max = long.MinValue;
        foreach (var startMove in moves)
        {
            Console.WriteLine(startMove);
            _grid.Reset();
            var moveGenerator = new MoveGenerator(_grid);
            var stack = new Stack<Move>();
            stack.Push(startMove);
            var count = 0;
            while (stack.Any() && count < 1000000)
            {
                var current = stack.Pop();
                _grid.Visit(current);
            
                var nextMoves = moveGenerator.NextMoves(current);
            
                foreach (var move in nextMoves)
                {
                    stack.Push(move);
                }

                count++;
            }

            if (max < _grid.VisitedCoords())
            {
                max = _grid.VisitedCoords();
            }
        }
        
        Console.WriteLine(max);
        return 1;
    }

    private static LavaGrid ToGrid(IEnumerable<string> lines)
    {
        var values = lines.Select(line => line.Select(c => new Cell((Value) c)).ToArray()).ToArray();
        return new LavaGrid(values, _start);
    }
}
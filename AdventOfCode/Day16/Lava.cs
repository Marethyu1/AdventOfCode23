namespace AdventOfCode.Day16;

public class Lava: ISolution<int>
{
    private readonly Grid<Container> _grid;
    private readonly Coord _start = new Coord(0, 0);
    
    public Lava(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var parsedLines = lines.Select(x => x.Select(y => new Container(y))
            .ToArray())
            .ToArray();
        
        _grid = new Grid<Container>(parsedLines);
    }
    
    public int Solve()
    {
        Console.WriteLine(_grid);
        var firstMove = new Move(_start, Direction.Right);
        var queue = new Queue<Move>();
        queue.Enqueue(firstMove);
        
        while (queue.Any())
        {
            var currentMove = queue.Dequeue();
            var currentLocation = _grid[currentMove.Coord];
            if (currentLocation.IsVisited(currentMove))
            {
                continue;
            }
            currentLocation.Visit(currentMove);

            if (currentLocation.Value == '.')
            {
                QueueInDirection(queue, _grid, currentMove, currentMove.Direction);
            }

            if (currentLocation.Value == '|')
            {
                if (currentMove.Direction is Direction.Right or Direction.Left)
                {
                    QueueInDirection(queue, _grid, currentMove, Direction.Down);
                    QueueInDirection(queue, _grid, currentMove, Direction.Up);
                }
                
                if (currentMove.Direction is Direction.Up or Direction.Down)
                {
                    QueueInDirection(queue, _grid, currentMove, currentMove.Direction);
                }
            }

            if (currentLocation.Value == '-')
            {
                if (currentMove.Direction is Direction.Right or Direction.Left)
                {
                    QueueInDirection(queue, _grid, currentMove, currentMove.Direction);
                }
                if (currentMove.Direction is Direction.Down or Direction.Up)
                {
                    QueueInDirection(queue, _grid, currentMove, Direction.Left);
                    QueueInDirection(queue, _grid, currentMove, Direction.Right);
                }
            }

            if (currentLocation.Value == '/')
            {
                if (currentMove.Direction is Direction.Right)
                {
                    QueueInDirection(queue, _grid, currentMove, Direction.Up);
                }

                if (currentMove.Direction is Direction.Left)
                {
                    QueueInDirection(queue, _grid, currentMove, Direction.Down);
                }
                
                if (currentMove.Direction is Direction.Up)
                {
                    QueueInDirection(queue, _grid, currentMove, Direction.Right);
                }
                
                if (currentMove.Direction is Direction.Down)
                {
                    QueueInDirection(queue, _grid, currentMove, Direction.Left);
                }

            }
            
            if (currentLocation.Value == '\\')
            {
                if (currentMove.Direction is Direction.Right)
                {
                    QueueInDirection(queue, _grid, currentMove, Direction.Down);
                }

                if (currentMove.Direction is Direction.Left)
                {
                    QueueInDirection(queue, _grid, currentMove, Direction.Up);
                }
                
                if (currentMove.Direction is Direction.Up)
                {
                    QueueInDirection(queue, _grid, currentMove, Direction.Left);
                }
                
                if (currentMove.Direction is Direction.Down)
                {
                    QueueInDirection(queue, _grid, currentMove, Direction.Right);
                }

            }
            
            // Console.WriteLine(_grid);
            // Console.WriteLine();

        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(_grid);
        Console.WriteLine(_grid.Input.SelectMany(x => x).Count(x => x.VisitCount));
        return 1;
    }

    private static void QueueInDirection(Queue<Move> queue, Grid<Container> grid, Move move, Direction direction)
    {
        var nextMove = MoveGenerator.NextMove(move, direction);
        QueueIfInBounds(queue, grid, nextMove);
    }

    private static void QueueIfInBounds(Queue<Move> queue, Grid<Container> container, Move move)
    {
        try
        {
            var nextMove = container[move.Coord];
            if (!nextMove.Visited) queue.Enqueue(move);
        }
        catch (CoordinateOutOfGridException e)
        {
            
        }
    }
    
    
}
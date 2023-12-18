namespace AdventOfCode.Day16;

public static class LavaSolver
{
    public static int Solve(Grid<Container> grid, Move startMove)
    {
        var queue = new DfsQeue();
        queue.Add(startMove);
        var c = 0;
        while (queue.Any())
        {
            var currentMove = queue.Next();

            // if (c < 100)
            // {
            //     Console.WriteLine(currentMove);
            //     Console.WriteLine(grid.Debug(v => v));
            //     Console.WriteLine(); 
            // }
            //
            // c++;
            
            

            var currentLocation = grid[currentMove.Coord];

            if (currentLocation.IsVisited(currentMove))
            {
                continue;
            }
            currentLocation.Visit(currentMove);
            
            // if (currentLocation.Visits == 2)
            // {
            //     Console.WriteLine("woa");
            // }

            if (currentLocation.Value == '.')
            {
                QueueInDirection(queue, grid, currentMove, currentMove.Direction);
            }

            if (currentLocation.Value == '|')
            {
                if (currentMove.Direction is Direction.Right or Direction.Left)
                {
                    QueueInDirection(queue, grid, currentMove, Direction.Down);
                    QueueInDirection(queue, grid, currentMove, Direction.Up);
                }
                
                if (currentMove.Direction is Direction.Up or Direction.Down)
                {
                    QueueInDirection(queue, grid, currentMove, currentMove.Direction);
                }
            }

            if (currentLocation.Value == '-')
            {
                if (currentMove.Direction is Direction.Right or Direction.Left)
                {
                    QueueInDirection(queue, grid, currentMove, currentMove.Direction);
                }
                if (currentMove.Direction is Direction.Down or Direction.Up)
                {
                    QueueInDirection(queue, grid, currentMove, Direction.Left);
                    QueueInDirection(queue, grid, currentMove, Direction.Right);
                }
            }

            if (currentLocation.Value == '/')
            {
                if (currentMove.Direction is Direction.Right)
                {
                    QueueInDirection(queue, grid, currentMove, Direction.Up);
                }

                if (currentMove.Direction is Direction.Left)
                {
                    QueueInDirection(queue, grid, currentMove, Direction.Down);
                }
                
                if (currentMove.Direction is Direction.Up)
                {
                    QueueInDirection(queue, grid, currentMove, Direction.Right);
                }
                
                if (currentMove.Direction is Direction.Down)
                {
                    QueueInDirection(queue, grid, currentMove, Direction.Left);
                }

            }
            
            if (currentLocation.Value == '\\')
            {
                if (currentMove.Direction is Direction.Right)
                {
                    QueueInDirection(queue, grid, currentMove, Direction.Down);
                }

                if (currentMove.Direction is Direction.Left)
                {
                    QueueInDirection(queue, grid, currentMove, Direction.Up);
                }
                
                if (currentMove.Direction is Direction.Up)
                {
                    QueueInDirection(queue, grid, currentMove, Direction.Left);
                }
                
                if (currentMove.Direction is Direction.Down)
                {
                    QueueInDirection(queue, grid, currentMove, Direction.Right);
                }

            }
        }
        
        Console.WriteLine(grid.Debug(x => x.Debug()));

        var count = grid.Input.SelectMany(x => x).Count(x => x.VisitCount);
        return count;
    }
    
    private static void QueueInDirection(ILavalQueue queue, Grid<Container> grid, Move move, Direction direction)
    {
        var nextMove = MoveGenerator.NextMove(move, direction);
        QueueIfInBounds(queue, grid, nextMove);
    }

    private static void QueueIfInBounds(ILavalQueue queue, Grid<Container> grid, Move move)
    {
        try
        {
            var nextMove = grid[move.Coord];
            if (!nextMove.IsVisited(move)) queue.Add(move);
        }
        catch (CoordinateOutOfGridException e)
        {
            
        }
    }
}
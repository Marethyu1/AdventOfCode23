namespace AdventOfCode.Day10;

public static class CoordHelper
{
    public static (int x, int y) Next((int x, int y) current, (int x, int y) next, Node[][] nodes)
    {
        var nextNode = nodes[next.x][next.y];
        switch (nextNode.Value)
        {
            case Value.NorthSouth:
                if (current.x > next.x)
                {
                    return Up(next);
                }
                return Down(next);
            case Value.EastWest:
                if (current.y > next.y)
                {
                    return (next.x, next.y - 1);
                }
                return (next.x, next.y + 1);
            case Value.NorthEast:
                if (current.x >= next.x)
                {
                    return Up(next);
                }
                return Right(next);
            case Value.NorthWest:
                if (current.y >= next.y)
                {
                    return Left(next);
                }
                //(4,0) (4,1) -> (3,1)
                return Up(next);
                break;
            case Value.SouthWest:
                if (current.x > next.x)
                {
                    return Left(next);
                }
                return Down(next);
                break;
            case Value.SouthEast:
                if (current.x > next.x)
                {
                    return Right(next);
                }
                return Down(next);
                break;
            case Value.Ground:
                return (-1, -1);
                break;
            case Value.Start:
                return (-2, -2);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return (-1, -1);
    }
    
    public static (int x, int y) Left((int x, int y) current)
    {
        return (current.x, current.y - 1);
    }

    public static (int x, int y) Right((int x, int y) current)
    {
        return (current.x, current.y + 1);
    }
    
    public static (int x, int y) Up((int x, int y) current)
    {
        return (current.x - 1, current.y);
    }
    
    public static (int x, int y) Down((int x, int y) current)
    {
        return (current.x + 1, current.y);
    }
}
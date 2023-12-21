using AdventOfCode.Shared;

namespace AdventOfCode.Day18;

public class Mountain: Grid<Cell>
{
    private readonly Dictionary<Direction, Coord[]> _lookup;

    private readonly Coord[,] _nextUp;
    private readonly Coord[,] _nextLeft;
    private readonly Coord[,] _nextRight;
    private readonly Coord[,] _nextDown;
    public Mountain(Cell[][] input) : base(input)
    {
        var upCoords = new List<Coord>();
        var leftCords = new List<Coord>();
        for (var r = 0; r < input.Length; r++)
        {
            for (var c = 0; c < input[0].Length; c++)
            {
                upCoords.Add(new Coord(r, c));
                leftCords.Add(new Coord(c, r));
            }
        }
        
        var downCords = new List<Coord>();
        var rightCords = new List<Coord>();
        for (var r = input.Length -1; r >= 0; r--)
        {
            for (var c = input[0].Length -1; c >= 0 ; c--)
            {
                downCords.Add(new Coord(r, c));
                rightCords.Add(new Coord(c, r));
            }
        }
        

        _lookup = new()
        {
            [Direction.Up] = upCoords.ToArray(),
            [Direction.Right] = rightCords.ToArray(),
            [Direction.Left] = leftCords.ToArray(),
            [Direction.Down] = downCords.ToArray(),
        };


        _nextRight = new Coord[Input.Length, Input.Length];
        _nextLeft = new Coord[Input.Length, Input.Length];
        _nextUp = new Coord[Input.Length, Input.Length];
        _nextDown = new Coord[Input.Length, Input.Length];
        
        
        foreach (var cord in upCoords)
        {
            _nextRight[cord.R, cord.C] = cord.NextCoord(Direction.Right);
            _nextLeft[cord.R, cord.C] = cord.NextCoord(Direction.Left);
            _nextUp[cord.R, cord.C] = cord.NextCoord(Direction.Up);
            _nextDown[cord.R, cord.C] = cord.NextCoord(Direction.Down);
        }

        
        
    }

    public void Tilt(Direction direction)
    {

        foreach (var coord in _lookup[direction])
        {
            var currentCoord = coord;
            var cell = this[currentCoord];
            if (cell.SpaceType is SpaceType.RoundRock)
            {
                var nextCord = Next(currentCoord, direction);
                while (InBounds(nextCord) && this[nextCord].SpaceType == SpaceType.Empty)
                {
                    this[nextCord] = cell;
                    this[currentCoord] = new Cell((char)SpaceType.Empty);
                    currentCoord = nextCord;
                    nextCord = Next(nextCord, direction);
                }
            }
        }
        return;
        
        var startRow = 0;
        var startCol = 0;
        var endRow = Input.Length;
        var endCol = Input[0].Length;
        var dir = 1;

        var toCoord = (int r, int c) => new Coord(r, c);

        if (direction is Direction.Down)
        {
            startRow = Input.Length - 2;
            startCol = Input[0].Length -2;
            endRow = -1;
            endCol = -1;
            dir = -1;
        }

        if (direction is Direction.Right)
        {
            toCoord = (int r, int c) => new Coord(c, r);
            startRow = Input.Length - 1;
            startCol = Input[0].Length -1;
            endRow = -1;
            endCol = -1;
            dir = -1;
        }
        
        if (direction is Direction.Left)
        {
            toCoord = (int r, int c) => new Coord(c, r);
            startRow = 1;
            startCol = 1;
            endRow = Input.Length;
            endCol = Input[0].Length;
            dir = 1;
        }

        var r = startRow;
        var c = startCol;
        while (r != endRow)
        {
            while (c != endCol)
            {
                var currentCoord = toCoord(r, c);
                
                
                c += dir;
            }
            r += dir;
            c = startCol;
        }
        
       
    }

    private Coord Next(Coord coord, Direction direction)
    {
        if (direction == Direction.Down)
        {
            return _nextDown[coord.R, coord.C];
        }
        if (direction == Direction.Up)
        {
            return _nextRight[coord.R, coord.C];
        }
        if (direction == Direction.Left)
        {
            return _nextLeft[coord.R, coord.C];
        }
        if (direction == Direction.Right)
        {
            return _nextRight[coord.R, coord.C];
        }

        throw new Exception("uhoh");
    }

    public long Load()
    {
        long count = 0;
        for (var r = 0; r < this.Input.Length; r++)
        {
            for (var c = 0; c < this.Input[0].Length; c++)
            {
                var current = this[r, c];
                if (current.SpaceType is SpaceType.RoundRock)
                {
                    count += Input.Length - r;
                }
            }
            
        }

        return count;
    }
}
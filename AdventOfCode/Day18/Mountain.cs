using AdventOfCode.Shared;

namespace AdventOfCode.Day18;

public class Mountain: Grid<Cell>
{
    public Mountain(Cell[][] input) : base(input)
    {
        
    }

    public void Tilt(Direction direction)
    {
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
                var cell = this[currentCoord];
                if (cell.SpaceType is SpaceType.RoundRock)
                {
                    
                    var nextCord = currentCoord.NextCoord(direction);
                    while (InBounds(nextCord) && this[nextCord].SpaceType == SpaceType.Empty)
                    {
                        this[nextCord] = cell;
                        this[currentCoord] = new Cell((char)SpaceType.Empty);
                        currentCoord = nextCord;
                        nextCord = nextCord.NextCoord(direction);
                    }
                }
                
                c += dir;
            }
            r += dir;
            c = startCol;
        }
        
       
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